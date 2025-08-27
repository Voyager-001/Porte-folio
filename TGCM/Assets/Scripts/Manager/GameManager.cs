using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static GridCombatSystem;
using TMPro;

public class GameManager : MonoBehaviour{

    public GameObject goblin;
    public GameObject bat;
    public GameObject metalman;
    public GameObject jazzman;
    public GameObject electronicman;
    public GameObject classicman;
    public GameObject attackMenuToAppearGoblin;
    public GameObject attackMenuToAppearBat;
    public GameObject statEnemyUI;
    public GameObject statEnemyText;
    public GameObject statPlayerUI;
    public GameObject statPlayerText;

    public static GameObject healMenuToAppearMetalman;
    public static GameObject healMenuToAppearJazzman;
    public static GameObject healMenuToAppearElectronicman;

    public int goblinHealthMax;
    public int batHealthMax;

    public static int whoAttack;
    public static int whoEnemy;
    public static int fight;
    public static int unitWhoTarget;
    public static int currentTurn;
    public static int metalmanHealthMax;
    public static int jazzmanHealthMax;
    public static int electronicmanHealthMax;
    public static int classicmanHealthMax;
    public static int unitWhoHeal;

    public static Dictionary<string, Vector3> unitDictionaryPosition = new Dictionary<string, Vector3>();
    public static Dictionary<string, int> unitDictionaryHealth = new Dictionary<string, int>();
    public static Dictionary<string, int> unitDictionaryDamage = new Dictionary<string, int>();
    public static Dictionary<string, bool> unitDictionaryCanAttack = new Dictionary<string, bool>();
    public static Dictionary<string, bool> unitDictionaryCanMove = new Dictionary<string, bool>();
    
    public static List<string> neighbourList = new List<string>();

    public static string whoFight;
    public static string selection;

    public static bool indexScene;
    public static bool delayReplay;

    public static bool heal = false;

    public static WhoPlay whoPlayThisTurn;

    private void Awake(){

        DontDestroyOnLoad(gameObject);

        var a = FindObjectsOfType<GameManager>();

        if(a.Length > 1){

            Destroy(gameObject);

            return;
        }
        indexScene = true;
        delayReplay = false;

        goblinHealthMax = goblin.GetComponent<UnitGridCombat>().health;
        batHealthMax = bat.GetComponent<UnitGridCombat>().health;
        metalmanHealthMax = metalman.GetComponent<UnitGridCombat>().health;
        jazzmanHealthMax = jazzman.GetComponent<UnitGridCombat>().health;
        electronicmanHealthMax = electronicman.GetComponent<UnitGridCombat>().health;
        classicmanHealthMax = classicman.GetComponent<UnitGridCombat>().health;
    }

    void Update(){

        if (delayReplay)
        {
            delayReplay = false;
            StartCoroutine(DelayReplay());
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game") && indexScene)
        {
            indexScene = false;

            goblin = GameObject.Find("Ennemy (Goblin)");
            bat = GameObject.Find("Ennemy (Chauve-Souris)");
            metalman = GameObject.Find("Player(Metalleux)");
            jazzman = GameObject.Find("Player(Jazz)");
            electronicman = GameObject.Find("Player(Electro)");
            classicman = GameObject.Find("Player(Classic)");
            attackMenuToAppearGoblin = GameObject.Find("AttackMenuGobin");
            attackMenuToAppearBat = GameObject.Find("AttackMenuBat");
            healMenuToAppearMetalman = GameObject.Find("HealMenuMetalman");
            healMenuToAppearJazzman = GameObject.Find("HealMenuJazzman");
            healMenuToAppearElectronicman = GameObject.Find("HealMenuElectronicman");
            statEnemyUI = GameObject.Find("StatEnemy");
            statPlayerUI = GameObject.Find("StatPlayer");
            statEnemyText = GameObject.Find("StatEnemyText");
            statPlayerText = GameObject.Find("StatPlayerText");

            if(attackMenuToAppearGoblin != null)
                attackMenuToAppearGoblin.SetActive(false);
            if(attackMenuToAppearBat != null)
                attackMenuToAppearBat.SetActive(false);
            if(healMenuToAppearMetalman != null)
                healMenuToAppearMetalman.SetActive(false);
            if(healMenuToAppearJazzman != null)
                healMenuToAppearJazzman.SetActive(false);
            if(healMenuToAppearElectronicman != null)
                healMenuToAppearElectronicman.SetActive(false);

            statEnemyUI.SetActive(false);
            statPlayerUI.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0)){

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            Vector3 mouseWorldPosition = GetMousePosition.GetMouseWorldPosition();
            Grid<GridObject> grid = GameHandler_GridCombatSystem.Instance.GetGrid();
            GridObject gridObject = grid.GetGridObject(mouseWorldPosition);
            if(grid.GetGridObject(mouseWorldPosition) != null)
            {
                if (gridObject.GetUnitGridCombat() != null)
                {
                    if (GridCombatSystem.Instance.unitGridCombat != null)
                    {
                        if (GridCombatSystem.Instance.unitGridCombat.IsEnemy(gridObject.GetUnitGridCombat()))
                        {
                            if (gridObject.GetIsValidMovePosition())
                            {
                                if (hit.collider != null && hit.collider.gameObject == goblin)
                                {
                                    if(attackMenuToAppearGoblin != null)
                                        attackMenuToAppearGoblin.SetActive(true);
                                    if (attackMenuToAppearBat != null)
                                        attackMenuToAppearBat.SetActive(false);
                                    GridCombatSystem.Instance.state = State.Waiting;
                                }

                                if (hit.collider != null && hit.collider.gameObject == bat)
                                {
                                    if(attackMenuToAppearBat != null)
                                        attackMenuToAppearBat.SetActive(true);
                                    if (attackMenuToAppearGoblin != null)
                                        attackMenuToAppearGoblin.SetActive(false);
                                    GridCombatSystem.Instance.state = State.Waiting;
                                }
                            }
                            else
                            {
                                // Cannot attack enemy
                            }

                        }
                        else
                        {
                            // Not an enemy
                        }
                    }
                    //break;//empeche l'uniter d'aller sur la position d'un allier ou un enemy
                }
                else
                {
                    // No unit here
                }
            }
            if(hit.collider != null && hit.collider.gameObject == goblin){

                whoEnemy = 1;

                statEnemyUI.SetActive(true);

                statEnemyText.GetComponent<TextMeshProUGUI>().text = "Goblin\nHP: " + goblin.GetComponent<UnitGridCombat>().health + " / " + goblinHealthMax + "\nAttack: " + goblin.GetComponent<UnitGridCombat>().damage + "\nSpeed: " + goblin.GetComponent<UnitGridCombat>().reach;
            }

            if(hit.collider != null && hit.collider.gameObject == bat){

                whoEnemy = 2;

                statEnemyUI.SetActive(true);

                statEnemyText.GetComponent<TextMeshProUGUI>().text = "Bat\nHP: " + bat.GetComponent<UnitGridCombat>().health + " / "+ batHealthMax + "\nAttack: " + bat.GetComponent<UnitGridCombat>().damage + "\nSpeed: " + bat.GetComponent<UnitGridCombat>().reach;
            }

            if(hit.collider != null && hit.collider.gameObject == metalman){

                whoAttack = 1;

                statPlayerUI.SetActive(true);

                statPlayerText.GetComponent<TextMeshProUGUI>().text = "Metalman\nHP: " + metalman.GetComponent<UnitGridCombat>().health + " / " + metalmanHealthMax + "\nAttack: " + metalman.GetComponent<UnitGridCombat>().damage + "\nSpeed: " + metalman.GetComponent<UnitGridCombat>().reach;
            }

            if(hit.collider != null && hit.collider.gameObject == jazzman){

                whoAttack = 2;

                statPlayerUI.SetActive(true);

                statPlayerText.GetComponent<TextMeshProUGUI>().text = "Jazzman\nHP: " + jazzman.GetComponent<UnitGridCombat>().health + " / " + jazzmanHealthMax + "\nAttack: " + jazzman.GetComponent<UnitGridCombat>().damage + "\nSpeed: " + jazzman.GetComponent<UnitGridCombat>().reach;
            }

            if(hit.collider != null && hit.collider.gameObject == electronicman){

                whoAttack = 3;

                statPlayerUI.SetActive(true);

                statPlayerText.GetComponent<TextMeshProUGUI>().text = "Electronicman\nHP: " + electronicman.GetComponent<UnitGridCombat>().health + " / " + electronicmanHealthMax + "\nAttack: " + electronicman.GetComponent<UnitGridCombat>().damage + "\nSpeed: " + electronicman.GetComponent<UnitGridCombat>().reach;
            }

            if(hit.collider != null && hit.collider.gameObject == classicman){

                whoAttack = 4;

                statPlayerUI.SetActive(true);

                statPlayerText.GetComponent<TextMeshProUGUI>().text = "Classicman\nHP: " + classicman.GetComponent<UnitGridCombat>().health + " / " + classicmanHealthMax + "\nAttack: " + classicman.GetComponent<UnitGridCombat>().damage + "\nSpeed: " + classicman.GetComponent<UnitGridCombat>().reach;
            }
        }
    }

    
IEnumerator DelayReplay()
    {
        yield return new WaitForSeconds(0.1f);
        indexScene = true;
    }
}
