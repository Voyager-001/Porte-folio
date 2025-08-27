using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static GridCombatSystem;

public class GridCombatSystem : MonoBehaviour
{
    public static GridCombatSystem Instance { get; private set; }

    public UnitGridCombat unitGridCombat;
    public UnitGridCombat[] unitGridCombatArray;
    public Dictionary<string,UnitGridCombat> unitGridCombatDictionary = new Dictionary<string, UnitGridCombat>();

    public GameObject attackMenuToAppearGoblin;
    public GameObject attackMenuToAppearBat;
    public GameObject currentTurnText;
    public GameObject pauseText;
    public GameObject defeatText;
    public GameObject victoryText;
    public GameObject menuEnd;
    public GameObject changeTurnText;
    public GameObject changeTurn;
    public GameObject ButtonRePlay;
    public GameObject ButtonContinus;
    public GameObject statEnemyUI;

    public State state;
    public WhoPlay whoPlay;
    private int maxTurn;
    private int currentTurn;
    public int index;
    public int _turnBased;
    private List<UnitGridCombat> allieTeamList = new List<UnitGridCombat>();
    private List<UnitGridCombat> enemyTeamList = new List<UnitGridCombat>();
    private int _testindexPosition;
    private int _testindexCanAttack;
    private int _testindexCanMove;
    private int _testindexHealth;
    private int _testindexDamage;

    public bool order;
    public enum State
    {
        Normal,
        Waiting
    }

    public enum WhoPlay
    {
        Allie,
        Enemy
    }

    private void Awake()
    {
        Instance = this;
        state = State.Normal;
        whoPlay = /*WhoPlay.Allie;*/GameManager.whoPlayThisTurn;

        foreach(UnitGridCombat unitGridCombat in unitGridCombatArray)
        {
            if (!unitGridCombatDictionary.ContainsKey(unitGridCombat.indexString))
            {
                unitGridCombatDictionary.Add(unitGridCombat.indexString, unitGridCombat);
            }
        }

        foreach (var _unitGridCombat in unitGridCombatDictionary)
        {
            if (!GameManager.unitDictionaryPosition.ContainsKey(_unitGridCombat.Value.indexString))
            {
                GameManager.unitDictionaryPosition.Add(_unitGridCombat.Value.indexString, _unitGridCombat.Value.GetPosition());
            }
            if (!GameManager.unitDictionaryCanAttack.ContainsKey(_unitGridCombat.Value.indexString))
            {
                GameManager.unitDictionaryCanAttack.Add(_unitGridCombat.Value.indexString, _unitGridCombat.Value.canAttackThisTurn);
            }
            if (!GameManager.unitDictionaryCanMove.ContainsKey(_unitGridCombat.Value.indexString))
            {
                GameManager.unitDictionaryCanMove.Add(_unitGridCombat.Value.indexString, _unitGridCombat.Value.canMoveThisTurn);
            }
            if (!GameManager.unitDictionaryHealth.ContainsKey(_unitGridCombat.Value.indexString))
            {
                GameManager.unitDictionaryHealth.Add(_unitGridCombat.Value.indexString, _unitGridCombat.Value.health);
            }
            if (!GameManager.unitDictionaryDamage.ContainsKey(_unitGridCombat.Value.indexString))
            {
                GameManager.unitDictionaryDamage.Add(_unitGridCombat.Value.indexString, _unitGridCombat.Value.damage);
            }
        }

        if (GameManager.unitDictionaryPosition != null)
        {
            _testindexPosition = 0;
            foreach (var unitGridCombatPosition in GameManager.unitDictionaryPosition)
            {
                unitGridCombatArray[_testindexPosition].transform.position = unitGridCombatPosition.Value;
                _testindexPosition++;
            }
        }
        if (GameManager.unitDictionaryCanAttack != null)
        {
            _testindexCanAttack = 0;
            foreach (var unitGridCombatCanAttack in GameManager.unitDictionaryCanAttack)
            {
                unitGridCombatArray[_testindexCanAttack].canAttackThisTurn = unitGridCombatCanAttack.Value;
                _testindexCanAttack++;
            }
        }
        if (GameManager.unitDictionaryCanMove != null)
        {
            _testindexCanMove = 0;
            foreach (var unitGridCombatCanMove in GameManager.unitDictionaryCanMove)
            {
                unitGridCombatArray[_testindexCanMove].canMoveThisTurn = unitGridCombatCanMove.Value;
                _testindexCanMove++;
            }
        }
        if(GameManager.unitDictionaryHealth != null)
        {
            _testindexHealth = 0;
            foreach (var unitGridCombatHealth in GameManager.unitDictionaryHealth)
            {
                unitGridCombatArray[_testindexHealth].SetHealth(unitGridCombatHealth.Value);
                _testindexHealth++;
            }
        }
        if (GameManager.unitDictionaryDamage != null)
        {
            _testindexDamage = 0;
            foreach (var unitGridCombatDamage in GameManager.unitDictionaryDamage)
            {
                unitGridCombatArray[_testindexDamage].damage = unitGridCombatDamage.Value;
                _testindexDamage++;
            }
        }
    }

    private void Start()
    {
        order = true;
        index = 0;
        maxTurn = 20;
        currentTurn = GameManager.currentTurn;

        TeamList();

        currentTurnText.GetComponent<TextMeshProUGUI>().text = currentTurn.ToString() + "/" + maxTurn;

        if (unitGridCombat != null)
            UpdateValidMovePosition();
    }

    public void TeamList()
    {
        allieTeamList.Clear();
        enemyTeamList.Clear();
        int indexenemy = 0;
        foreach (var unitGridCombat in unitGridCombatDictionary)
        {
            GameHandler_GridCombatSystem.Instance.GetGrid().GetGridObject(unitGridCombat.Value.GetPosition()).SetUnitGridCombat(unitGridCombat.Value);

            if (unitGridCombat.Value.GetTeam() == UnitGridCombat.Team.Allie)
            {
                allieTeamList.Add(unitGridCombat.Value);
            }
            else
            {
                enemyTeamList.Add(unitGridCombat.Value);
                unitGridCombat.Value.Index = indexenemy;
                indexenemy++;
            }
        }
        _turnBased = enemyTeamList.Count;
    }

    public void IsDead(string indexUnit)
    {
        unitGridCombatDictionary.Remove(indexUnit);
        TeamList();
    }

    public void ConditionDefeat()
    {
        if (allieTeamList.Count <= 0 || currentTurn >= maxTurn)
        {
            state = State.Waiting;
            defeatText.SetActive(true);
            ButtonRePlay.SetActive(true);
            menuEnd.SetActive(true);
        }
    }

    public void MenuPause()
    {
        pauseText.GetComponent<TextMeshProUGUI>().text = "Pause";
        ButtonContinus.SetActive(true);
        menuEnd.SetActive(true);
        Time.timeScale = 0;
        state = State.Waiting;
        /*
        GameManager.currentTurn = currentTurn;

        foreach (var _unitGridCombat in unitGridCombatDictionary)
        {
            GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();
            GameManager.unitDictionaryCanAttack[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canAttackThisTurn;
            GameManager.unitDictionaryCanMove[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canMoveThisTurn;
            GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
            GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;
        }
        GameManager.whoPlayThisTurn = whoPlay;*/
    }

    public void Continus()
    {
        ButtonContinus.SetActive(false);
        menuEnd.SetActive(false);
        Time.timeScale = 1;
        state = State.Normal;
    }

    public void ClearValidMovePosition()
    {
        Grid<GridObject> grid = GameHandler_GridCombatSystem.Instance.GetGrid();
        Pathfinding pathfinding = GameHandler_GridCombatSystem.Instance.pathfinding;
        grid.GetXY(unitGridCombat.transform.position, out int unitX, out int unitY);

        GameHandler_GridCombatSystem.Instance.GetTilemap().SetAllTilemapSprite(Tilemap.TilemapObject.TilemapSprite.None);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                grid.GetGridObject(x, y).SetIsValidMovePosition(false);
            }
        }
    }

    private void UpdateValidMovePosition()
    {
        Grid<GridObject> grid = GameHandler_GridCombatSystem.Instance.GetGrid();
        Pathfinding pathfinding = GameHandler_GridCombatSystem.Instance.pathfinding;
        grid.GetXY(unitGridCombat.transform.position, out int unitX, out int unitY);

        ClearValidMovePosition();


        int maxMoveDistance = unitGridCombat.reach;
        for(int x = 0; x < maxMoveDistance; x++)
        {
            for(int y = 0; y < maxMoveDistance - x; y++)
            {
                if(grid.GetGridObject(unitX + x, unitY + y) != null && pathfinding.FindPath(unitX, unitY, unitX + x, unitY + y) != null)
                {
                    if (pathfinding.FindPath(unitX, unitY, unitX + x, unitY + y).Count <= maxMoveDistance)
                    {
                        GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX + x, unitY + y, Tilemap.TilemapObject.TilemapSprite.Move);
                        grid.GetGridObject(unitX + x, unitY + y).SetIsValidMovePosition(true);
                        if(unitGridCombat.indexString == "Classic")
                        {
                            if (grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat() != null)
                            {
                                if (unitGridCombat != null)
                                {
                                    if (unitGridCombat.IsAllie(grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat()))
                                    {
                                        if (grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat().indexString == "Electro" && grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat().health < GameManager.electronicmanHealthMax)
                                        {
                                            GameManager.healMenuToAppearElectronicman.SetActive(true);
                                            state = State.Waiting;
                                        }
                                        if (grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat().indexString == "Jazz" && grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat().health < GameManager.jazzmanHealthMax)
                                        {
                                            GameManager.healMenuToAppearJazzman.SetActive(true);
                                            state = State.Waiting;
                                        }
                                        if (grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat().indexString == "Metalleux" && grid.GetGridObject(unitX + x, unitY + y).GetUnitGridCombat().health < GameManager.metalmanHealthMax)
                                        {
                                            GameManager.healMenuToAppearMetalman.SetActive(true);
                                            state = State.Waiting;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (x != 0)
                {
                    if(grid.GetGridObject(unitX - x, unitY + y) != null && pathfinding.FindPath(unitX, unitY, unitX - x, unitY + y) != null)
                    {
                        if (pathfinding.FindPath(unitX, unitY, unitX - x, unitY + y).Count <= maxMoveDistance)
                        {
                            GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX - x, unitY + y, Tilemap.TilemapObject.TilemapSprite.Move);
                            grid.GetGridObject(unitX - x, unitY + y).SetIsValidMovePosition(true);
                            if(unitGridCombat.indexString == "Classic")
                            {
                                if (grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat() != null)
                                {
                                    if (unitGridCombat != null)
                                    {
                                        if (unitGridCombat.IsAllie(grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat()))
                                        {
                                            if (grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat().indexString == "Electro" && grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat().health < GameManager.electronicmanHealthMax)
                                            {
                                                GameManager.healMenuToAppearElectronicman.SetActive(true);
                                                state = State.Waiting;
                                            }
                                            if (grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat().indexString == "Jazz" && grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat().health < GameManager.jazzmanHealthMax)
                                            {
                                                GameManager.healMenuToAppearJazzman.SetActive(true);
                                                state = State.Waiting;
                                            }
                                            if (grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat().indexString == "Metalleux" && grid.GetGridObject(unitX - x, unitY + y).GetUnitGridCombat().health < GameManager.metalmanHealthMax)
                                            {
                                                GameManager.healMenuToAppearMetalman.SetActive(true);
                                                state = State.Waiting;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    } 
                }
                if (y != 0)
                {
                    if(grid.GetGridObject(unitX + x, unitY - y) != null && pathfinding.FindPath(unitX, unitY, unitX + x, unitY - y) != null)
                    {
                        if (pathfinding.FindPath(unitX, unitY, unitX + x, unitY - y).Count <= maxMoveDistance)
                        {
                            GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX + x, unitY - y, Tilemap.TilemapObject.TilemapSprite.Move);
                            grid.GetGridObject(unitX + x, unitY - y).SetIsValidMovePosition(true);
                            if(unitGridCombat.indexString == "Classic")
                            {
                                if (grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat() != null)
                                {
                                    if (unitGridCombat != null)
                                    {
                                        if (unitGridCombat.IsAllie(grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat()))
                                        {
                                            if (grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat().indexString == "Electro" && grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat().health <GameManager.electronicmanHealthMax)
                                            {
                                                GameManager.healMenuToAppearElectronicman.SetActive(true);
                                                state = State.Waiting;
                                            }
                                            if (grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat().indexString == "Jazz" && grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat().health < GameManager.jazzmanHealthMax)
                                            {
                                                GameManager.healMenuToAppearJazzman.SetActive(true);
                                                state = State.Waiting;
                                            }
                                            if (grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat().indexString == "Metalleux" && grid.GetGridObject(unitX + x, unitY - y).GetUnitGridCombat().health < GameManager.metalmanHealthMax)
                                            {
                                                GameManager.healMenuToAppearMetalman.SetActive(true);
                                                state = State.Waiting;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    if (x != 0)
                    {
                        if(grid.GetGridObject(unitX - x, unitY - y) != null && pathfinding.FindPath(unitX, unitY, unitX - x, unitY - y) != null)
                        {
                            if (pathfinding.FindPath(unitX, unitY, unitX - x, unitY - y).Count <= maxMoveDistance)
                            {
                                GameHandler_GridCombatSystem.Instance.GetTilemap().SetTilemapSprite(unitX - x, unitY - y, Tilemap.TilemapObject.TilemapSprite.Move);
                                grid.GetGridObject(unitX - x, unitY - y).SetIsValidMovePosition(true);
                                if(unitGridCombat.indexString == "Classic")
                                {
                                    if (grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat() != null)
                                    {
                                        if (unitGridCombat != null)
                                        {
                                            if (unitGridCombat.IsAllie(grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat()))
                                            {
                                                if (grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat().indexString == "Electro" && grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat().health < GameManager.electronicmanHealthMax)
                                                {
                                                    GameManager.healMenuToAppearElectronicman.SetActive(true);
                                                    state = State.Waiting;
                                                }
                                                if (grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat().indexString == "Jazz" && grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat().health < GameManager.jazzmanHealthMax)
                                                {
                                                    GameManager.healMenuToAppearJazzman.SetActive(true);
                                                    state = State.Waiting;
                                                }
                                                if (grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat().indexString == "Metalleux" && grid.GetGridObject(unitX - x, unitY - y).GetUnitGridCombat().health < GameManager.metalmanHealthMax)
                                                {
                                                    GameManager.healMenuToAppearMetalman.SetActive(true);
                                                    state = State.Waiting;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public List<string> GetNeighboursList(UnitGridCombat unitGridCombat)
    {
        Grid<GridObject> grid = GameHandler_GridCombatSystem.Instance.GetGrid();
        GridObject gridObject = grid.GetGridObject(unitGridCombat.GetPosition());

        List<string> neighbourList = new List<string>();

        if (gridObject.x - 1 >= 0)
        {
            //Left
            if (grid.GetGridObject(gridObject.x - 1, gridObject.y).GetUnitGridCombat() != null)
            {
                neighbourList.Add(grid.GetGridObject(gridObject.x - 1, gridObject.y).GetUnitGridCombat().indexString);
            }

            //Left Down
            if (gridObject.y - 1 >= 0)
            {
                if(grid.GetGridObject(gridObject.x - 1, gridObject.y - 1).GetUnitGridCombat() != null)
                {
                    neighbourList.Add(grid.GetGridObject(gridObject.x - 1, gridObject.y - 1).GetUnitGridCombat().indexString);
                }
            }
            
            // Left Up
            if (gridObject.y + 1 < grid.GetHeight())
            {
                if(grid.GetGridObject(gridObject.x - 1, gridObject.y + 1).GetUnitGridCombat() != null)
                {
                    neighbourList.Add(grid.GetGridObject(gridObject.x - 1, gridObject.y + 1).GetUnitGridCombat().indexString);
                }
            }
                
        }
        if (gridObject.x + 1 < grid.GetWidth())
        {
            //Righ
            if(grid.GetGridObject(gridObject.x + 1, gridObject.y).GetUnitGridCombat() != null)
            {
                neighbourList.Add(grid.GetGridObject(gridObject.x + 1, gridObject.y).GetUnitGridCombat().indexString);
            }
            
            //Right Down
            if (gridObject.y - 1 >= 0)
            {
                if(grid.GetGridObject(gridObject.x + 1, gridObject.y - 1).GetUnitGridCombat() != null)
                {
                    neighbourList.Add(grid.GetGridObject(gridObject.x + 1, gridObject.y - 1).GetUnitGridCombat().indexString);
                }
            }
                
            //Right Up
            if (gridObject.y + 1 < grid.GetHeight())
            {
                if(grid.GetGridObject(gridObject.x + 1, gridObject.y + 1).GetUnitGridCombat() != null)
                {
                    neighbourList.Add(grid.GetGridObject(gridObject.x + 1, gridObject.y + 1).GetUnitGridCombat().indexString);
                }
            }
                
        }
        //Down
        if (gridObject.y - 1 >= 0)
        {
            if(grid.GetGridObject(gridObject.x, gridObject.y - 1).GetUnitGridCombat() != null)
            {
                neighbourList.Add(grid.GetGridObject(gridObject.x, gridObject.y - 1).GetUnitGridCombat().indexString);
            }
        }
            
        //Up
        if (gridObject.y + 1 < grid.GetHeight())
        {
            if(grid.GetGridObject(gridObject.x, gridObject.y + 1).GetUnitGridCombat() != null)
            {
                neighbourList.Add(grid.GetGridObject(gridObject.x, gridObject.y + 1).GetUnitGridCombat().indexString);
            }
        }
        return neighbourList;
    }

    public void SelecteUnit()
    {
        Vector3 mouseWorldPosition = GetMousePosition.GetMouseWorldPosition();
        Grid<GridObject> grid = GameHandler_GridCombatSystem.Instance.GetGrid();
        GridObject gridObject = grid.GetGridObject(mouseWorldPosition);
        
        if (gridObject.GetUnitGridCombat() != null) 
        {
            if (gridObject.GetUnitGridCombat().GetTeam() == UnitGridCombat.Team.Allie)
            {
                unitGridCombat = gridObject.GetUnitGridCombat();
                GameHandler_GridCombatSystem.Instance.SetCameraFollowPosition(unitGridCombat.GetPosition());
                UpdateValidMovePosition();
                if(attackMenuToAppearGoblin != null)
                    attackMenuToAppearGoblin.SetActive(false);
                if (attackMenuToAppearBat != null)
                    attackMenuToAppearBat.SetActive(false);
                if(unitGridCombat.indexString != "Classic")
                {
                    if(GameManager.healMenuToAppearElectronicman != null)
                    {
                        GameManager.healMenuToAppearElectronicman.SetActive(false);
                    }
                    if(GameManager.healMenuToAppearJazzman != null)
                    {
                        GameManager.healMenuToAppearJazzman.SetActive(false);
                    }
                    if(GameManager.healMenuToAppearMetalman != null)
                    {
                        GameManager.healMenuToAppearMetalman.SetActive(false);
                    }
                }
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.75f);
        changeTurn.SetActive(false);
    }

    public void EndTurn()
    {
        if(whoPlay == WhoPlay.Allie)
        {
            GameManager.whoAttack = 0;
            if (unitGridCombat != null)
            {
                GameManager.selection = unitGridCombat.indexString;
            }
            whoPlay = WhoPlay.Enemy;
            changeTurnText.GetComponent<TextMeshProUGUI>().text = "Turn " + whoPlay;
            changeTurn.SetActive(true);
            StartCoroutine(Wait());
            
            currentTurn++;
            GameManager.currentTurn = currentTurn;

            foreach (var _unitGridCombat in unitGridCombatDictionary)
            {
                GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();
                GameManager.unitDictionaryCanAttack[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canAttackThisTurn;
                GameManager.unitDictionaryCanMove[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canMoveThisTurn;
                GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
                GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;
            }
            GameManager.whoPlayThisTurn = whoPlay;

            foreach (UnitGridCombat unitGridCombat in allieTeamList)
            {
                unitGridCombat.canAttackThisTurn = false;
                unitGridCombat.canMoveThisTurn = false;
            }
        }
    }

    public void TrunBase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndTurn();
        }
        if (whoPlay == WhoPlay.Enemy)
        {
            if(_turnBased > 1)
            {
                if(enemyTeamList[0].FinishThisTurn() && enemyTeamList[1].FinishThisTurn())//a changer car horrible et probablement pas opti
                {
                    foreach (UnitGridCombat unitGridCombat in enemyTeamList)
                    {
                        unitGridCombat.canMoveThisTurn = true;
                        unitGridCombat.canAttackThisTurn = true;
                        unitGridCombat.canMove = true;
                        unitGridCombat.canAttack = true;
                        unitGridCombat.delayX = true;
                        unitGridCombat.delayY = false;
                    }

                    whoPlay = WhoPlay.Allie;
                    currentTurnText.GetComponent<TextMeshProUGUI>().text = currentTurn.ToString() + "/" + maxTurn;
                    if (currentTurn < maxTurn)
                    {
                        changeTurnText.GetComponent<TextMeshProUGUI>().text = "Turn " + whoPlay;
                        changeTurn.SetActive(true);
                        StartCoroutine(Wait());
                    }

                    if (GameManager.selection != null)
                    {
                        if (unitGridCombatDictionary.ContainsKey(GameManager.selection))
                        {
                            GameHandler_GridCombatSystem.Instance.SetCameraFollowPosition(unitGridCombatDictionary[GameManager.selection].GetPosition());
                            if (unitGridCombat != null) 
                                ClearValidMovePosition();
                        }
                        
                    }
                    else
                    {
                        GameHandler_GridCombatSystem.Instance.SetCameraFollowPosition(new Vector3(25,95,0));
                        if (unitGridCombat != null) 
                            ClearValidMovePosition();
                    }
                    order = true;

                    foreach (UnitGridCombat unitGridCombat1 in allieTeamList)
                    {
                        unitGridCombat1.canMoveThisTurn = true;
                        unitGridCombat1.canAttackThisTurn = true;
                        index = 0;
                    }
                }
                if(enemyTeamList[0].FinishThisTurn())
                {
                    if (order)
                    {
                        order = false;
                        index = (index + 1) % enemyTeamList.Count;
                    }  
                }
            }
            if(_turnBased == 1)
            {
                if (enemyTeamList[0].FinishThisTurn())//a changer car horrible et probablement pas opti
                {
                    foreach (UnitGridCombat unitGridCombat in enemyTeamList)
                    {
                        unitGridCombat.canMoveThisTurn = true;
                        unitGridCombat.canAttackThisTurn = true;
                        unitGridCombat.canMove = true;
                        unitGridCombat.canAttack = true;
                        unitGridCombat.delayX = true;
                        unitGridCombat.delayY = false;
                    }

                    whoPlay = WhoPlay.Allie;
                    currentTurnText.GetComponent<TextMeshProUGUI>().text = currentTurn.ToString() + "/" + maxTurn;
                    if (currentTurn < maxTurn)
                    {
                        changeTurnText.GetComponent<TextMeshProUGUI>().text = "Turn " + whoPlay;
                        changeTurn.SetActive(true);
                        StartCoroutine(Wait());
                    }
                    if (GameManager.selection != null)
                    {
                        if (unitGridCombatDictionary.ContainsKey(GameManager.selection))
                        {
                            GameHandler_GridCombatSystem.Instance.SetCameraFollowPosition(unitGridCombatDictionary[GameManager.selection].GetPosition());
                            if (unitGridCombat != null) 
                                ClearValidMovePosition();
                        }
                    }
                    else
                    {
                        GameHandler_GridCombatSystem.Instance.SetCameraFollowPosition(new Vector3(25, 95, 0));
                        if (unitGridCombat != null) 
                            ClearValidMovePosition();
                    }

                    foreach (UnitGridCombat unitGridCombat1 in allieTeamList)
                    {
                        unitGridCombat1.canMoveThisTurn = true;
                        unitGridCombat1.canAttackThisTurn = true;
                        index = 0;
                    }
                }
            }
        }
        if (enemyTeamList.Count == 0)
        {
            whoPlay = WhoPlay.Enemy;
            victoryText.SetActive(true);
            ButtonRePlay.SetActive(true);
            menuEnd.SetActive(true);
        }
    }

    public void ResetButton()
    {
        if (attackMenuToAppearGoblin != null)
            attackMenuToAppearGoblin.SetActive(false);
        if (attackMenuToAppearBat != null)
            attackMenuToAppearBat.SetActive(false);
        statEnemyUI.SetActive(false);
        if (GameManager.healMenuToAppearElectronicman != null)
            GameManager.healMenuToAppearElectronicman.SetActive(false);
        if (GameManager.healMenuToAppearJazzman != null)
            GameManager.healMenuToAppearJazzman.SetActive(false);
        if (GameManager.healMenuToAppearMetalman != null)
            GameManager.healMenuToAppearMetalman.SetActive(false);
        //statPlayerUI.SetActive(false);
        GridCombatSystem.Instance.state = State.Normal;
    }

    public UnitGridCombat WhoTarget(UnitGridCombat enemyUnitGridCombat)
    {
        int indexWhoTarget = 0;
        if (allieTeamList.Count > 0)
        { 
            float distance = Vector3.Distance(allieTeamList[0].GetPosition(), enemyUnitGridCombat.GetPosition());
            for (int x = 0; x < allieTeamList.Count; x++)
            {
                if (distance > Vector3.Distance(allieTeamList[x].GetPosition(), enemyUnitGridCombat.GetPosition()))
                {
                    distance = Vector3.Distance(allieTeamList[x].GetPosition(), enemyUnitGridCombat.GetPosition());
                    indexWhoTarget = x;
                }
            }
            return allieTeamList[indexWhoTarget];
        }
        return enemyUnitGridCombat;
    }

    private void Update()
    {
        if (whoPlay == WhoPlay.Allie) ConditionDefeat();
        if(Input.GetKeyDown(KeyCode.Escape)) MenuPause();
        Vector3 mouseWorldPosition = GetMousePosition.GetMouseWorldPosition();
        switch (state)
        {
            case State.Normal:
                TrunBase();
                if (Input.GetMouseButtonDown(0))
                {
                    Grid<GridObject> grid = GameHandler_GridCombatSystem.Instance.GetGrid();
                    GridObject gridObject = grid.GetGridObject(mouseWorldPosition);

                    if(grid.GetGridObject(mouseWorldPosition) != null)
                    {
                        if (whoPlay == WhoPlay.Allie) SelecteUnit();

                        if (gridObject.GetUnitGridCombat() != null)
                        {
                            if (unitGridCombat != null)
                            {
                                if (unitGridCombat.IsEnemy(gridObject.GetUnitGridCombat()))
                                {
                                    if (gridObject.GetIsValidMovePosition())
                                    {
                                        if (unitGridCombat.canAttackThisTurn)
                                        {
                                            //unitGridCombat.canAttackThisTurn = false;
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
                            break;//empeche l'uniter d'aller sur la position d'un allier ou un enemy
                        }
                        else
                        {
                            // No unit here
                        }

                        if (gridObject.GetIsValidMovePosition())
                        {
                            if(unitGridCombat != null)
                            {
                                if (unitGridCombat.canMoveThisTurn)
                                {
                                    unitGridCombat.canMoveThisTurn = false;
                                    state = State.Waiting;
                                    /*Vector3 moveDir = (mouseWorldPosition - transform.position).normalized;
                                    Debug.Log(moveDir); definir rotation
                                    if (moveDir.x < 1)*/
                                    grid.GetGridObject(unitGridCombat.GetPosition()).CleanUnitGridCombat();
                                    gridObject.SetUnitGridCombat(unitGridCombat);

                                    unitGridCombat.MoveTo(mouseWorldPosition, () =>
                                    {
                                        state = State.Normal;
                                        UpdateValidMovePosition();
                                    });
                                }
                            }
                        }
                    }
                }
                break;
            case State.Waiting:
                break;
        }

        /*if (Input.GetMouseButtonDown(1))//if temporaire
        {
            GameHandler_GridCombatSystem.Instance.pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(x, y).SetIsWalkable(!GameHandler_GridCombatSystem.Instance.pathfinding.GetNode(x, y).isWalkable);
        }*/
    }

    public class GridObject
    {
        private Grid<GridObject> grid;
        public int x;
        public int y;
        private bool isValidMovePosition;
        private UnitGridCombat unitGridCombat;

        public GridObject(Grid<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            
            Vector3 worldPos00 = grid.GetWorldPosition(x, y);
            Vector3 worldPos10 = grid.GetWorldPosition(x + 1, y);
            Vector3 worldPos01 = grid.GetWorldPosition(x, y + 1);
            Vector3 worldPos11 = grid.GetWorldPosition(x + 1, y + 1);

            Debug.DrawLine(worldPos00, worldPos01, Color.white, 999f);
            Debug.DrawLine(worldPos00, worldPos10, Color.white, 999f);
            Debug.DrawLine(worldPos01, worldPos11, Color.white, 999f);
            Debug.DrawLine(worldPos10, worldPos11, Color.white, 999f);
        }

        public void SetIsValidMovePosition(bool set)
        {
            isValidMovePosition = set;
        }

        public bool GetIsValidMovePosition()
        {
            return isValidMovePosition;
        }

        public void SetUnitGridCombat(UnitGridCombat unitGridCombat)
        {
            this.unitGridCombat = unitGridCombat;
        }

        public void CleanUnitGridCombat()
        {
            SetUnitGridCombat(null);
        }

        public UnitGridCombat GetUnitGridCombat()
        {
            return unitGridCombat;
        }
    }
}
