using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public enum EMenuState
    {
        Default,
        PlayerSelection,
        Controls,
        Options
    }
    private EMenuState menuState;

    [SerializeField] private GameObject defaultMenuPannel;
    [SerializeField] private GameObject playerSelectionPannel;
    [SerializeField] private GameObject controlsPannel;
    [SerializeField] private GameObject optionsPannel;

    [SerializeField] private Button defaultButton;
    [SerializeField] private Button defaultPlayerSelectionButton;
    [SerializeField] private Button defaultControlsButton;
    [SerializeField] private Button defaultOptionsButton;

    [SerializeField] private Color playerSelectedColor;
    [SerializeField] private Color playerUnselectedColor;

    [SerializeField] private Image playerIcon1;
    [SerializeField] private Image playerIcon2;
    [SerializeField] private Image playerIcon3;
    [SerializeField] private Image playerIcon4;

    [SerializeField] private Image tutoP1;
    [SerializeField] private Image tutoP2;

    private int currentPlayerNb;
    [SerializeField] private int maxPlayer;

    private Button currentDefaultButton;


    private void Awake()
    {
        currentPlayerNb = 2;
        SetPlayerNb(currentPlayerNb);
        tutoP1.gameObject.SetActive(true);
        tutoP2.gameObject.SetActive(false);
        SwitchState(EMenuState.Default);
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null) currentDefaultButton.Select();
    }

    public void PlayGameBtn()
    {
        SwitchState(EMenuState.PlayerSelection);
    }

    public void ControlsBtn()
    {
        SwitchState(EMenuState.Controls);
    }

    public void OptionsBtn() 
    {
        SwitchState(EMenuState.Options);
    }

    public void QuitBtn()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void ApplyPlayerNumberAndPlay()
    {

    }

    public void ToggleTutoPage()
    {
        tutoP1.gameObject.SetActive(!tutoP1.gameObject.activeSelf);
        tutoP2.gameObject.SetActive(!tutoP2.gameObject.activeSelf);
    }

    public void Return()
    {
        SwitchState(EMenuState.Default);
    }

    public void LaunchScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void SetDefaultButton(Button button)
    {
        currentDefaultButton = button;
    }

    public void AddPlayer()
    {
        SetPlayerNb(++currentPlayerNb);
    }

    public void RemovePlayer()
    {
        SetPlayerNb(currentPlayerNb > 2 ? --currentPlayerNb : maxPlayer);
    }

    public void SetPlayerNb(int playerNb)
    {
        currentPlayerNb = playerNb;
        currentPlayerNb %= maxPlayer + 1;

        if(currentPlayerNb < 2) currentPlayerNb = 2;

        playerIcon1.color = currentPlayerNb >= 1 ? playerSelectedColor : playerUnselectedColor;
        playerIcon2.color = currentPlayerNb >= 2 ? playerSelectedColor : playerUnselectedColor;
        playerIcon3.color = currentPlayerNb >= 3 ? playerSelectedColor : playerUnselectedColor;
        playerIcon4.color = currentPlayerNb >= 4 ? playerSelectedColor : playerUnselectedColor;

    }

    private void ExitState()
    {
        switch (menuState)
        {
            case EMenuState.Default:
                defaultMenuPannel.SetActive(false);
                break;
            case EMenuState.PlayerSelection:
                playerSelectionPannel.SetActive(false);
                break;
            case EMenuState.Controls:
                controlsPannel.SetActive(false);
                break;
            case EMenuState.Options:
                optionsPannel.SetActive(false);
                break;
        } 
    }

    public void SwitchState(EMenuState newState)
    {
        ExitState();
        menuState = newState;
        EnterState();
    }

    private void EnterState()
    {
        switch (menuState)
        {
            case EMenuState.Default:
                defaultMenuPannel.SetActive(true);
                currentDefaultButton = defaultButton;
                break;
            case EMenuState.PlayerSelection:
                playerSelectionPannel.SetActive(true);
                currentDefaultButton = defaultPlayerSelectionButton;
                tutoP1.gameObject.SetActive(true);
                tutoP2.gameObject.SetActive(false);
                break;
            case EMenuState.Controls:
                controlsPannel.SetActive(true);
                currentDefaultButton = defaultControlsButton;
                break;
            case EMenuState.Options:
                optionsPannel.SetActive(true);
                currentDefaultButton = defaultOptionsButton;
                break;
        }

        currentDefaultButton.Select();
    }
}