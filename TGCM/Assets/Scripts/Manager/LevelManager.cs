using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{

    public void OnPlayButtonClicked(){

        SceneManager.LoadScene(2);
    }

    public void OnOptionsButtonClicked(){

        SceneManager.LoadScene(1);
    }

    public void OnMenuButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnReturnButtonClicked(){

        if(Time.timeScale == 0)
        {
            GameManager.delayReplay = true;
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnAttackButtonClicked(){

        GameManager.fight = 1;
        
        if (GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn == true)
        {
            GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn = false;
            GridCombatSystem.Instance.unitGridCombat.canMoveThisTurn = false;
            GameManager.neighbourList = GridCombatSystem.Instance.GetNeighboursList(GridCombatSystem.Instance.unitGridCombat);
            foreach (var _unitGridCombat in GridCombatSystem.Instance.unitGridCombatDictionary)
            {
                GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();
                GameManager.unitDictionaryCanAttack[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canAttackThisTurn;
                GameManager.unitDictionaryCanMove[_unitGridCombat.Value.indexString] =_unitGridCombat.Value.canMoveThisTurn;
                GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
                GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;

            }
            GameManager.whoPlayThisTurn = GridCombatSystem.Instance.whoPlay;
            SceneManager.LoadScene(3);
        }
    }

    public void OnQuitButtonClicked(){

        Application.Quit();
    }

    public void OnRePlayButtonClicked()
    {
        GameManager.unitDictionaryPosition.Clear();
        GameManager.unitDictionaryCanAttack.Clear();
        GameManager.unitDictionaryCanMove.Clear();
        GameManager.unitDictionaryHealth.Clear();
        GameManager.unitDictionaryDamage.Clear();
        GameManager.whoPlayThisTurn = GridCombatSystem.WhoPlay.Allie;
        GameManager.currentTurn = 0;
        GameManager.delayReplay = true;
        SceneManager.LoadScene(2);
    }

    public void OnHealButton1Clicked(){

        GameManager.fight = 2;
        GameManager.unitWhoHeal = 1;

        GameManager.heal = true;
        
        if (GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn == true){

            GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn = false;
            GridCombatSystem.Instance.unitGridCombat.canMoveThisTurn = false;

            GameManager.neighbourList = GridCombatSystem.Instance.GetNeighboursList(GridCombatSystem.Instance.unitGridCombat);

            foreach (var _unitGridCombat in GridCombatSystem.Instance.unitGridCombatDictionary){

                GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();

                GameManager.unitDictionaryCanAttack[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canAttackThisTurn;
                GameManager.unitDictionaryCanMove[_unitGridCombat.Value.indexString] =_unitGridCombat.Value.canMoveThisTurn;
                GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
                GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;

            }

            GameManager.whoPlayThisTurn = GridCombatSystem.Instance.whoPlay;

            SceneManager.LoadScene(3);
        }
    }

    public void OnHealButton2Clicked(){

        GameManager.fight = 2;
        GameManager.unitWhoHeal = 2;

        GameManager.heal = true;
        
        if (GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn == true){

            GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn = false;
            GridCombatSystem.Instance.unitGridCombat.canMoveThisTurn = false;

            GameManager.neighbourList = GridCombatSystem.Instance.GetNeighboursList(GridCombatSystem.Instance.unitGridCombat);

            foreach (var _unitGridCombat in GridCombatSystem.Instance.unitGridCombatDictionary){

                GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();

                GameManager.unitDictionaryCanAttack[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canAttackThisTurn;
                GameManager.unitDictionaryCanMove[_unitGridCombat.Value.indexString] =_unitGridCombat.Value.canMoveThisTurn;
                GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
                GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;

            }

            GameManager.whoPlayThisTurn = GridCombatSystem.Instance.whoPlay;

            SceneManager.LoadScene(3);
        }
    }

    public void OnHealButton3Clicked(){

        GameManager.fight = 2;
        GameManager.unitWhoHeal = 3;

        GameManager.heal = true;
        
        if (GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn == true){

            GridCombatSystem.Instance.unitGridCombat.canAttackThisTurn = false;
            GridCombatSystem.Instance.unitGridCombat.canMoveThisTurn = false;

            GameManager.neighbourList = GridCombatSystem.Instance.GetNeighboursList(GridCombatSystem.Instance.unitGridCombat);

            foreach (var _unitGridCombat in GridCombatSystem.Instance.unitGridCombatDictionary){

                GameManager.unitDictionaryPosition[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.GetPosition();

                GameManager.unitDictionaryCanAttack[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.canAttackThisTurn;
                GameManager.unitDictionaryCanMove[_unitGridCombat.Value.indexString] =_unitGridCombat.Value.canMoveThisTurn;
                GameManager.unitDictionaryHealth[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.health;
                GameManager.unitDictionaryDamage[_unitGridCombat.Value.indexString] = _unitGridCombat.Value.damage;

            }

            GameManager.whoPlayThisTurn = GridCombatSystem.Instance.whoPlay;

            SceneManager.LoadScene(3);
        }
    }
}
