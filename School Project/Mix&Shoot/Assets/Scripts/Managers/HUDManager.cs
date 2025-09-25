using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUDManager : MonoBehaviour
{
    private static HUDManager s_instance;
    public static HUDManager Instance { get { return s_instance; } }
    [SerializeField] private Slider _doorHealthBar;
    public Slider DoorHealthBar => _doorHealthBar;
    [SerializeField] private TMP_Text scoreField;
    [SerializeField] private TMP_Text finalScoreField;
    [SerializeField] private TMP_Text timerField;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject HUDScreen;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private GameObject endGameVictoryField;
    [SerializeField] private GameObject endGameDefeatField;
    [SerializeField] private Button pauseDefaultBtn;
    [SerializeField] private Button endGameBtn;
    [SerializeField] private bool showRecipe;
    [SerializeField] private RectTransform recipeTransform;
    private Vector2 defaultRecipePos;
    [SerializeField] private float recipeMaxDownOffset;
    [SerializeField] private AnimationCurve recipeTravellingCurve;
    [SerializeField] private float recipeTravellingSpeed;
    private float currentRecipeTime;

    private void Awake()
    {
        if(s_instance != null)
        {
            Destroy(gameObject);
        } 
        else
        {
            s_instance = this;
        }

        TogglePauseMenu(false);
        defaultRecipePos = recipeTransform.anchoredPosition;
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null && pauseScreen.activeSelf) pauseDefaultBtn.Select();

        if(recipeTransform != null)
        {
            currentRecipeTime += (showRecipe ? -recipeTravellingSpeed : recipeTravellingSpeed) * Time.deltaTime;
            currentRecipeTime = Mathf.Clamp(currentRecipeTime, 0.0f, 1.0f);

            recipeTransform.anchoredPosition = Vector2.Lerp(defaultRecipePos, defaultRecipePos - new Vector2(0, recipeMaxDownOffset), recipeTravellingCurve.Evaluate(currentRecipeTime));
        }
    }

    public void UpdateScore()
    {
        if(GameManager.Instance != null)
        {
            scoreField.text = GameManager.Instance.Score.ToString();
            finalScoreField.text = "Score: " + scoreField.text;
        }
        else
        {
            Debug.LogWarning("Score couldn't be updated, there is no game manager...");
        }
    }

    public void UpdateScore(int newScoreDisplayed)
    {
        scoreField.text = newScoreDisplayed.ToString();
    }

    public void UpdateTimer()
    {
        if (GameManager.Instance != null)
        {
            print("le hud dans le code n'a pas �t� link au game manager");
        }
        else
        {
            Debug.LogWarning("Score couldn't be updated, there is no game manager...");
        }
    }

    public void UpdateTimer(float timer)
    {
        timerField.text = ProjectUtilities.FormatTimeToString(timer);
    }

    public void ToggleRecipe()
    {
        showRecipe = !showRecipe;
    }

    public void TogglePauseMenu(bool pauseState)
    {
        pauseScreen.SetActive(pauseState);
        HUDScreen.SetActive(!pauseState);
    }
    
    public void ToggleEndGameVictoryMenu(bool endGameState)
    {
        endGameScreen.SetActive(endGameState);
        endGameVictoryField.SetActive(endGameState);
        HUDScreen.SetActive(!endGameState);
    }
    
    public void ToggleEndGameDefeatMenu(bool endGameState)
    {
        endGameScreen.SetActive(endGameState);
        endGameDefeatField.SetActive(endGameState);
        HUDScreen.SetActive(!endGameState);
    }

}
