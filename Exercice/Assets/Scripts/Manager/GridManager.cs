using UnityEngine;
using Unity.Netcode;

public class GridManager : NetworkBehaviour
{
    [Header("Grid")]
    public int width = 6;
    public int height = 6;
    public float cellSize = 1f;
    public Transform gridRoot;
    public GameObject tilePrefab;
    
    private TileCell[,] _cells;
    private Vector2Int _secretPos;

    public override void OnNetworkSpawn()
    {
        if (_cells == null) BuildGrid();
    }

    void BuildGrid()
    {
        _cells = new TileCell[width, height];
        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
        {
            var go = Instantiate(tilePrefab, gridRoot);
            go.transform.localPosition = new Vector3(x * cellSize, 0, y * cellSize);
            var cell = go.GetComponent<TileCell>();
            cell.Init(this, new Vector2Int(x, y));
            _cells[x, y] = cell;
        }
    }

    public void ServerSetupNewRound()
    {
        if (!IsServer) return;
        BroadcastAllColorsClientRpc();
        _secretPos = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        SpawnPointsHelper.ServerRespawnPlayers(width, height, cellSize);
    }
    
    int Manhattan(Vector2Int a, Vector2Int b) => Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);

    [ServerRpc(RequireOwnership = false)]
    public void TryRevealServerRpc(Vector2Int gridPos, ulong requesterClientId)
    {
        if (GameManager.Instance.state.Value != GameState.Playing) return;
        if (GameManager.Instance.currentTurnClientId.Value != requesterClientId) return;
        
        var dist = Manhattan(gridPos, _secretPos);

        var color = Color.red;
        if (dist == 0) color = Color.green;
        else if (dist == 1) color = Color.yellow;
        else if (dist <= 2) color = new Color(1, 0.5f, 0);
        
        PaintCellClientRpc(gridPos.x, gridPos.y, color.r, color.g, color.b);
        
        if (dist == 0)
            GameManager.Instance.WinServer(requesterClientId, " (found)");
        else
            GameManager.Instance.NextTurnServer();
    }

    [ClientRpc]
    void PaintCellClientRpc(int x, int y, float r, float g, float b)
    {
        if (_cells != null & _cells[x, y] != null)
            _cells[x, y].SetColor(new Color(r, g, b));
    }

    [ClientRpc]
    void BroadcastAllColorsClientRpc()
    {
        if (_cells == null) return;
        for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                _cells[x, y].SetColor(Color.white);
    }
}