using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public enum GameState
{
    Waiting,
    Countdown,
    Playing,
    End
}

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;
    
    [Header("UI")]
    public TMP_Text countdownText;
    public TMP_Text turnText;
    public TMP_Text winText;
    public GameObject winPanel;
    public Button newRoundButton;
    
    [Header("Refs")]
    public GridManager grid;

    public NetworkVariable<GameState> state = new(GameState.Waiting, NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server);
    public NetworkVariable<ulong> currentTurnClientId = new(0, NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server);
    public bool IsMyTurn => NetworkManager.Singleton.LocalClientId == currentTurnClientId.Value;
    
    void Awake() => Instance = this;

    public override void OnNetworkSpawn()
    {
        state.OnValueChanged += (_, __) => RefreshUI();
        currentTurnClientId.OnValueChanged += (_, __) => RefreshUI();

        if (IsServer)
        {
            winPanel.SetActive(false);
            newRoundButton.onClick.AddListener(() => ServerStartRound());
            StartCoroutine(ServerWaitForPlayersThenStart());
        }
        else
        {
            newRoundButton.onClick.AddListener(() => RequestNewRoundServerRpc());
        }

        RefreshUI();
    }

    void ServerStartRound()
    {
        if (!IsServer) return;
        winPanel.SetActive(false);
        StartCoroutine(ServerCountdownThenPlay());
    }

    public void NextTurnServer()
    {
        if (!IsServer) return;
        var ids = NetworkManager.Singleton.ConnectedClientsIds;
        if (ids.Count < 2) return;
        currentTurnClientId.Value = (currentTurnClientId.Value == ids[0]) ? ids[1] : ids[0];
    }

    public void WinServer(ulong winnerId, string reason)
    {
        if (!IsServer) return;
        state.Value = GameState.End;
        ShowWinClientRpc(winnerId, reason);
    }

    void RefreshUI()
    {
        if (!turnText) return;
        switch (state.Value)
        {
            case GameState.Waiting:
                turnText.text = "Waiting for players...";
                break;
            case GameState.Countdown:
                turnText.text = "Get ready!";
                break;
            case GameState.Playing:
                var who = (IsMyTurn) ? "Your turn" : "Waiting for your turn";
                turnText.text = who;
                break;
            case GameState.End:
                turnText.text = "Game over";
                break;
        }
    }
    
    [ServerRpc(RequireOwnership = false)]
    void RequestNewRoundServerRpc() => ServerStartRound();

    [ClientRpc]
    void UpdateCountdownClientRpc(string text)
    {
        if(countdownText)
            countdownText.text = text;
    }
    
    [ClientRpc]
    void ShowWinClientRpc(ulong winnerId, string reason)
    {
        winPanel.SetActive(true);
        var iWon = (winnerId == NetworkManager.Singleton.LocalClientId);
        winText.text = (iWon ? "You won!" : "You lost!") + reason;
    }

    IEnumerator ServerWaitForPlayersThenStart()
    {
        while (NetworkManager.Singleton.ConnectedClientsList.Count < 2) yield return null;
        ServerStartRound();
    }

    IEnumerator ServerCountdownThenPlay()
    {
        state.Value = GameState.Countdown;
        for (var i = 3; i >= 1; i--)
        {
            UpdateCountdownClientRpc(i.ToString());
            yield return new WaitForSeconds(1);
        }

        UpdateCountdownClientRpc("");
        grid.ServerSetupNewRound();
        var ids = NetworkManager.Singleton.ConnectedClientsIds;
        if (ids.Count == 0) yield break;
        currentTurnClientId.Value = ids[Random.Range(0, ids.Count)];
        state.Value = GameState.Playing;
    }
}