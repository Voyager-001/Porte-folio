using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class FightManager : MonoBehaviour{

    public GameObject lifeEnemyText;
    public GameObject lifeMetallicText;
    public GameObject lifeJazzText;
    public GameObject lifeElectronicText;
    public GameObject lifeClassicText;
    public GameObject lifeEnemyBar;
    public GameObject lifeMetallicBar;
    public GameObject lifeJazzBar;
    public GameObject lifeElectronicBar;
    public GameObject lifeClassicBar;
    public GameObject goblin;
    public GameObject bat;
    public GameObject metallic;
    public GameObject jazz;
    public GameObject electronic;
    public GameObject classic;
    public GameObject UIEnemy;
    public GameObject UIMetallic;
    public GameObject UIJazz;
    public GameObject UIElectronic;
    public GameObject UIClassic;
    public GameObject UIHeal;
    public GameObject VFXMiss1;
    public GameObject VFXMiss2;
    public GameObject VFXMiss3;
    public GameObject VFXMiss4;
    public GameObject VFXHit1;
    public GameObject VFXHit2;
    public GameObject VFXHit3;
    public GameObject VFXHit4;
    public GameObject VFXFireBall;
    public GameObject fireBall;

    public AudioSource heal;

    public int metallicHealth;
    public int jazzHealth;
    public int electronicHealth;
    public int classicHealth;
    public int goblinHeath;
    public int batHealth;
    public int metallicDamage;
    public int jazzDamage;
    public int electronicDamage;
    public int classicDamage;
    public int goblinDamage;
    public int batDamage;
    public int ally;
    public int whoHeal;

    public static FightManager FMInstance;

    public static bool fightEnd = false;

    public Vector3 positionWithAllyText = new Vector3(-430, -400, 0);
    public Vector3 positionWithAllyBar = new Vector3(-505, -450, 0);
    public Vector3 positionWithAllySprite = new Vector3(-4.5f, -5, 0);
    public Vector3 positionWithAllyUI = new Vector3(-400, -420, 0);
    public Vector3 positionStartUI = new Vector3(-4.5f, -4, 0);
    public Vector3 positionStoptUI = new Vector3(5, -4, 0);

    void Awake(){

        metallicHealth = GameManager.unitDictionaryHealth["Metalleux"];
        jazzHealth = GameManager.unitDictionaryHealth["Jazz"];
        electronicHealth = GameManager.unitDictionaryHealth["Electro"];
        classicHealth = GameManager.unitDictionaryHealth["Classic"];
        goblinHeath = GameManager.unitDictionaryHealth["Goblin"];
        batHealth = GameManager.unitDictionaryHealth["Chauve-Souris"];
        metallicDamage = GameManager.unitDictionaryDamage["Metalleux"];
        jazzDamage = GameManager.unitDictionaryDamage["Jazz"];
        electronicDamage = GameManager.unitDictionaryDamage["Electro"];
        classicDamage = GameManager.unitDictionaryDamage["Classic"];
        goblinDamage = GameManager.unitDictionaryDamage["Goblin"];
        batDamage = GameManager.unitDictionaryDamage["Chauve-Souris"];

        if(GameManager.neighbourList.Contains("Metalleux") && (GameManager.unitWhoHeal != 1 && GameManager.unitWhoHeal != 2 && GameManager.unitWhoHeal != 3)){

            metallicDamage += 2;
            ally = 1;
        }

        if(GameManager.neighbourList.Contains("Jazz") && (GameManager.unitWhoHeal != 1 && GameManager.unitWhoHeal != 2 && GameManager.unitWhoHeal != 3)){

            jazzDamage += 2;
            ally = 2;
        }

        if(GameManager.neighbourList.Contains("Electro") && (GameManager.unitWhoHeal != 1 && GameManager.unitWhoHeal != 2 && GameManager.unitWhoHeal != 3)){

            electronicDamage += 2;
            ally = 3;
        }

        if(GameManager.neighbourList.Contains("Classic") && (GameManager.unitWhoHeal != 1 && GameManager.unitWhoHeal != 2 && GameManager.unitWhoHeal != 3)){

            classicDamage += 2;
            ally = 4;
        }

        if(GameManager.unitWhoHeal == 1 && GameManager.fight == 2){

            whoHeal = 1;

            UIHeal.SetActive(true);
        }

        if(GameManager.unitWhoHeal == 2 && GameManager.fight == 2){

            whoHeal = 2;

            UIHeal.SetActive(true);
        }

        if(GameManager.unitWhoHeal == 3 && GameManager.fight == 2){

            whoHeal = 3;

            UIHeal.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start(){
        
        FMInstance = this;
    }

    // Update is called once per frame
    void Update(){

        if(GameManager.whoEnemy == 1 || GameManager.whoFight == "Goblin"){

            if(goblinHeath == 8){

                lifeEnemyBar.transform.localScale = new Vector3(1, 1, 1);
            }

            if(goblinHeath == 7){

                lifeEnemyBar.transform.localScale = new Vector3(0.875f, 1, 1);
            }

            if(goblinHeath == 6){

                lifeEnemyBar.transform.localScale = new Vector3(0.75f, 1, 1);
            }

            if(goblinHeath == 5){

                lifeEnemyBar.transform.localScale = new Vector3(0.625f, 1, 1);
            }

            if(goblinHeath == 4){

                lifeEnemyBar.transform.localScale = new Vector3(0.5f, 1, 1);
            }

            if(goblinHeath == 3){

                lifeEnemyBar.transform.localScale = new Vector3(0.375f, 1, 1);
            }

            if(goblinHeath == 2){

                lifeEnemyBar.transform.localScale = new Vector3(0.25f, 1, 1);
            }

            if(goblinHeath == 1){

                lifeEnemyBar.transform.localScale = new Vector3(0.125f, 1, 1);
            }

            if(goblinHeath <= 0){

                lifeEnemyBar.transform.localScale = new Vector3(0, 1, 1);
            }

            lifeEnemyText.SetActive(true);
            lifeEnemyBar.SetActive(true);
            goblin.SetActive(true);
            UIEnemy.SetActive(true);

            lifeEnemyText.GetComponent<TextMeshProUGUI>().text = "HP: " + goblinHeath;
        }

        if(GameManager.whoEnemy == 2 || GameManager.whoFight == "Chauve-Souris"){

            if(batHealth == 5){

                lifeEnemyBar.transform.localScale = new Vector3(1, 1, 1);
            }

            if(batHealth == 4){

                lifeEnemyBar.transform.localScale = new Vector3(0.8f, 1, 1);
            }

            if(batHealth == 3){

                lifeEnemyBar.transform.localScale = new Vector3(0.6f, 1, 1);
            }

            if(batHealth == 2){

                lifeEnemyBar.transform.localScale = new Vector3(0.4f, 1, 1);
            }

            if(batHealth == 1){

                lifeEnemyBar.transform.localScale = new Vector3(0.2f, 1, 1);
            }

            if(batHealth <= 0){

                lifeEnemyBar.transform.localScale = new Vector3(0, 1, 1);
            }

            lifeEnemyText.SetActive(true);
            lifeEnemyBar.SetActive(true);
            bat.SetActive(true);
            UIEnemy.SetActive(true);

            lifeEnemyText.GetComponent<TextMeshProUGUI>().text = "HP: " + batHealth;
        }

        if(GameManager.unitWhoTarget == 1 || ally == 1 || GameManager.whoAttack == 1 || whoHeal == 1){

            if(metallicHealth == 11){

                lifeMetallicBar.transform.localScale = new Vector3(1, 1, 1);
            }

            if(metallicHealth == 10){

                lifeMetallicBar.transform.localScale = new Vector3(0.909f, 1, 1);
            }

            if(metallicHealth == 9){

                lifeMetallicBar.transform.localScale = new Vector3(0.818f, 1, 1);
            }

            if(metallicHealth == 8){

                lifeMetallicBar.transform.localScale = new Vector3(0.727f, 1, 1);
            }

            if(metallicHealth == 7){

                lifeMetallicBar.transform.localScale = new Vector3(0.636f, 1, 1);
            }

            if(metallicHealth == 6){

                lifeMetallicBar.transform.localScale = new Vector3(0.545f, 1, 1);
            }

            if(metallicHealth == 5){

                lifeMetallicBar.transform.localScale = new Vector3(0.454f, 1, 1);
            }

            if(metallicHealth == 4){

                lifeMetallicBar.transform.localScale = new Vector3(0.363f, 1, 1);
            }

            if(metallicHealth == 3){

                lifeMetallicBar.transform.localScale = new Vector3(0.272f, 1, 1);
            }

            if(metallicHealth == 2){

                lifeMetallicBar.transform.localScale = new Vector3(0.181f, 1, 1);
            }

            if(metallicHealth == 1){

                lifeMetallicBar.transform.localScale = new Vector3(0.09f, 1, 1);
            }

            if(metallicHealth <= 0){

                lifeMetallicBar.transform.localScale = new Vector3(0, 1, 1);
            }

            lifeMetallicText.SetActive(true);
            lifeMetallicBar.SetActive(true);
            metallic.SetActive(true);
            UIMetallic.SetActive(true);

            lifeMetallicText.GetComponent<TextMeshProUGUI>().text = "HP: " + metallicHealth;

            if(ally == 2 || ally == 3 || ally == 4 || whoHeal == 1){

                lifeMetallicText.transform.localPosition = positionWithAllyText;
                lifeMetallicBar.transform.localPosition = positionWithAllyBar;
                metallic.transform.localPosition = positionWithAllySprite;
                UIMetallic.transform.localPosition = positionWithAllyUI;
            }
        }

        if(GameManager.unitWhoTarget == 2 || ally == 2 || GameManager.whoAttack == 2 || whoHeal == 2){

            if(jazzHealth == 6){

                lifeJazzBar.transform.localScale = new Vector3(1, 1, 1);
            }

            if(jazzHealth == 5){

                lifeJazzBar.transform.localScale = new Vector3(0.833f, 1, 1);
            }

            if(jazzHealth == 4){

                lifeJazzBar.transform.localScale = new Vector3(0.666f, 1, 1);
            }

            if(jazzHealth == 3){

                lifeJazzBar.transform.localScale = new Vector3(0.499f, 1, 1);
            }

            if(jazzHealth == 2){

                lifeJazzBar.transform.localScale = new Vector3(0.332f, 1, 1);
            }

            if(jazzHealth == 1){

                lifeJazzBar.transform.localScale = new Vector3(0.165f, 1, 1);
            }

            if(jazzHealth <= 0){

                lifeJazzBar.transform.localScale = new Vector3(0, 1, 1);
            }

            lifeJazzText.SetActive(true);
            lifeJazzBar.SetActive(true);
            jazz.SetActive(true);
            UIJazz.SetActive(true);

            lifeJazzText.GetComponent<TextMeshProUGUI>().text = "HP: " + jazzHealth;

            if(ally == 1 || ally == 3 || ally == 4 || whoHeal == 2){

                lifeJazzText.transform.localPosition = positionWithAllyText;
                lifeJazzBar.transform.localPosition = positionWithAllyBar;
                jazz.transform.localPosition = positionWithAllySprite;
                UIJazz.transform.localPosition = positionWithAllyUI;
            }
        }

        if(GameManager.unitWhoTarget == 3 || ally == 3 || GameManager.whoAttack == 3 || whoHeal == 3){

            if(electronicHealth == 8){

                lifeElectronicBar.transform.localScale = new Vector3(1, 1, 1);
            }

            if(electronicHealth == 7){

                lifeElectronicBar.transform.localScale = new Vector3(0.875f, 1, 1);
            }

            if(electronicHealth == 6){

                lifeElectronicBar.transform.localScale = new Vector3(0.75f, 1, 1);
            }

            if(electronicHealth == 5){

                lifeElectronicBar.transform.localScale = new Vector3(0.625f, 1, 1);
            }

            if(electronicHealth == 4){

                lifeElectronicBar.transform.localScale = new Vector3(0.5f, 1, 1);
            }

            if(electronicHealth == 3){

                lifeElectronicBar.transform.localScale = new Vector3(0.375f, 1, 1);
            }

            if(electronicHealth == 2){

                lifeElectronicBar.transform.localScale = new Vector3(0.25f, 1, 1);
            }

            if(electronicHealth == 1){

                lifeElectronicBar.transform.localScale = new Vector3(0.125f, 1, 1);
            }

            if(electronicHealth <= 0){

                lifeElectronicBar.transform.localScale = new Vector3(0, 1, 1);
            }

            lifeElectronicText.SetActive(true);
            lifeElectronicBar.SetActive(true);
            electronic.SetActive(true);
            UIElectronic.SetActive(true);

            lifeElectronicText.GetComponent<TextMeshProUGUI>().text = "HP: " + electronicHealth;

            if(ally == 1 || ally == 2 || ally == 4 || whoHeal == 3){

                lifeElectronicText.transform.localPosition = positionWithAllyText;
                lifeElectronicBar.transform.localPosition = positionWithAllyBar;
                electronic.transform.localPosition = positionWithAllySprite;
                UIElectronic.transform.localPosition = positionWithAllyUI;
            }
        }

        if(GameManager.unitWhoTarget == 4 || ally == 4 || GameManager.whoAttack == 4){

            if(classicHealth == 8){

                lifeClassicBar.transform.localScale = new Vector3(1, 1, 1);
            }

            if(classicHealth == 7){

                lifeClassicBar.transform.localScale = new Vector3(0.875f, 1, 1);
            }

            if(classicHealth == 6){

                lifeClassicBar.transform.localScale = new Vector3(0.75f, 1, 1);
            }

            if(classicHealth == 5){

                lifeClassicBar.transform.localScale = new Vector3(0.625f, 1, 1);
            }

            if(classicHealth == 4){

                lifeClassicBar.transform.localScale = new Vector3(0.5f, 1, 1);
            }

            if(classicHealth == 3){

                lifeClassicBar.transform.localScale = new Vector3(0.375f, 1, 1);
            }

            if(classicHealth == 2){

                lifeClassicBar.transform.localScale = new Vector3(0.25f, 1, 1);
            }

            if(classicHealth == 1){

                lifeClassicBar.transform.localScale = new Vector3(0.125f, 1, 1);
            }

            if(classicHealth <= 0){

                lifeClassicBar.transform.localScale = new Vector3(0, 1, 1);
            }

            lifeClassicText.SetActive(true);
            lifeClassicBar.SetActive(true);
            classic.SetActive(true);
            UIClassic.SetActive(true);

            lifeClassicText.GetComponent<TextMeshProUGUI>().text = "HP: " + classicHealth;

            if(ally == 1 || ally == 2 || ally == 3){

                lifeClassicText.transform.localPosition = positionWithAllyText;
                lifeClassicBar.transform.localPosition = positionWithAllyBar;
                classic.transform.localPosition = positionWithAllySprite;
                UIClassic.transform.localPosition = positionWithAllyUI;
            }
        }

        if(fightEnd){

            fightEnd = false;

            if(GameManager.fight == 1){

                fireBall.SetActive(true);

                if((GameManager.whoEnemy == 1 || GameManager.whoEnemy == 2) && GameManager.whoAttack == 1){

                    if(BeatsManager.beatHit <= BeatsManager.beatMax / 2){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= metallicDamage;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= metallicDamage;
                        }
                    }

                    if(BeatsManager.beatHit > BeatsManager.beatMax / 2 && BeatsManager.beatHit <= BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= metallicDamage + 2;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= metallicDamage + 2;
                        }
                    }

                    if(BeatsManager.beatHit == BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= metallicDamage + 4;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= metallicDamage + 4;
                        }
                    }

                    GameManager.unitDictionaryHealth["Goblin"] = goblinHeath;
                    GameManager.unitDictionaryHealth["Chauve-Souris"] = batHealth;
                }

                if((GameManager.whoEnemy == 1 || GameManager.whoEnemy == 2) && GameManager.whoAttack == 2){

                    if(BeatsManager.beatHit <= BeatsManager.beatMax / 2){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= jazzDamage;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= jazzDamage;
                        }
                    }

                    if(BeatsManager.beatHit > BeatsManager.beatMax / 2 && BeatsManager.beatHit <= BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= jazzDamage + 2;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= jazzDamage + 2;
                        }
                    }

                    if(BeatsManager.beatHit == BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= jazzDamage + 4;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= jazzDamage + 4;
                        }
                    }

                    GameManager.unitDictionaryHealth["Goblin"] = goblinHeath;
                    GameManager.unitDictionaryHealth["Chauve-Souris"] = batHealth;
                }

                if((GameManager.whoEnemy == 1 || GameManager.whoEnemy == 2) && GameManager.whoAttack == 3){

                    if(BeatsManager.beatHit <= BeatsManager.beatMax / 2){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= electronicDamage;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= electronicDamage;
                        }
                    }

                    if(BeatsManager.beatHit > BeatsManager.beatMax / 2 && BeatsManager.beatHit <= BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= electronicDamage + 3;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= electronicDamage + 3;
                        }
                    }

                    if(BeatsManager.beatHit == BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= electronicDamage + 5;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= electronicDamage + 5;
                        }
                    }

                    GameManager.unitDictionaryHealth["Goblin"] = goblinHeath;
                    GameManager.unitDictionaryHealth["Chauve-Souris"] = batHealth;
                }

                if((GameManager.whoEnemy == 1 || GameManager.whoEnemy == 2) && GameManager.whoAttack == 4){

                    if(BeatsManager.beatHit <= BeatsManager.beatMax / 2){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= classicDamage;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= classicDamage;
                        }
                    }

                    if(BeatsManager.beatHit > BeatsManager.beatMax / 2 && BeatsManager.beatHit <= BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= classicDamage + 2;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= classicDamage + 2;
                        }
                    }

                    if(BeatsManager.beatHit == BeatsManager.beatMax){

                        if(GameManager.whoEnemy == 1){

                            goblinHeath -= classicDamage + 4;
                        }

                        if(GameManager.whoEnemy == 2){

                            batHealth -= classicDamage + 4;
                        }
                    }

                    GameManager.unitDictionaryHealth["Goblin"] = goblinHeath;
                    GameManager.unitDictionaryHealth["Chauve-Souris"] = batHealth;
                }
            }

            if(GameManager.fight == 0){

                if((GameManager.unitWhoTarget == 1 || GameManager.unitWhoTarget == 2 || GameManager.unitWhoTarget == 3 || GameManager.unitWhoTarget == 4) && GameManager.whoFight == "Goblin"){

                    if(QTEManager.QTEValide < QTEManager.QTECounter){

                        if(GameManager.unitWhoTarget == 1){

                            metallicHealth -= goblinDamage;
                        }

                        if(GameManager.unitWhoTarget == 2){

                            jazzHealth -= goblinDamage;
                        }

                        if(GameManager.unitWhoTarget == 3){

                            electronicHealth -= goblinDamage;
                        }

                        if(GameManager.unitWhoTarget == 4){

                            classicHealth -= goblinDamage;
                        }
                    }

                    if(QTEManager.QTEValide == QTEManager.QTECounter){

                        if(GameManager.unitWhoTarget == 1){

                            metallicHealth -= goblinDamage - 2;
                        }

                        if(GameManager.unitWhoTarget == 2){

                            jazzHealth -= goblinDamage - 2;
                        }

                        if(GameManager.unitWhoTarget == 3){

                            electronicHealth -= goblinDamage - 2;
                        }

                        if(GameManager.unitWhoTarget == 4){

                            classicHealth -= goblinDamage - 2;
                        }
                    }

                    GameManager.unitDictionaryHealth["Metalleux"] = metallicHealth;
                    GameManager.unitDictionaryHealth["Electro"] = electronicHealth;
                    GameManager.unitDictionaryHealth["Classic"] = classicHealth;
                    GameManager.unitDictionaryHealth["Jazz"] = jazzHealth;
                }

                if((GameManager.unitWhoTarget == 1 || GameManager.unitWhoTarget == 2 || GameManager.unitWhoTarget == 3 || GameManager.unitWhoTarget == 4) && GameManager.whoFight == "Chauve-Souris"){

                    if(QTEManager.QTEValide < QTEManager.QTECounter){

                        if(GameManager.unitWhoTarget == 1){

                            metallicHealth -= batDamage;
                        }

                        if(GameManager.unitWhoTarget == 2){

                            jazzHealth -= batDamage;
                        }

                        if(GameManager.unitWhoTarget == 3){

                            electronicHealth -= batDamage;
                        }

                        if(GameManager.unitWhoTarget == 4){

                            classicHealth -= batDamage;
                        }
                    }

                    if(QTEManager.QTEValide == QTEManager.QTECounter){

                        if(GameManager.unitWhoTarget == 1){

                            metallicHealth -= batDamage - 2;
                        }

                        if(GameManager.unitWhoTarget == 2){

                            jazzHealth -= batDamage - 2;
                        }

                        if(GameManager.unitWhoTarget == 3){

                            electronicHealth -= batDamage - 2;
                        }

                        if(GameManager.unitWhoTarget == 4){

                            classicHealth -= batDamage - 2;
                        }
                    }

                    GameManager.unitDictionaryHealth["Metalleux"] = metallicHealth;
                    GameManager.unitDictionaryHealth["Jazz"] = jazzHealth;
                    GameManager.unitDictionaryHealth["Electro"] = electronicHealth;
                    GameManager.unitDictionaryHealth["Classic"] = classicHealth;

                }
            }

            if(GameManager.fight == 2){

                heal.Play();

                if(whoHeal == 1){

                    if(BeatsManager.beatHit <= BeatsManager.beatMax / 2){

                        if(metallicHealth + 3 >= GameManager.metalmanHealthMax){

                            metallicHealth = GameManager.metalmanHealthMax;
                        }
                        else{

                            metallicHealth += 3;
                        }
                    }

                    if(BeatsManager.beatHit > BeatsManager.beatMax / 2 && BeatsManager.beatHit <= BeatsManager.beatMax){

                        if(metallicHealth + 6 >= GameManager.metalmanHealthMax){

                            metallicHealth = GameManager.metalmanHealthMax;
                        }
                        else{

                            metallicHealth += 6;
                        }
                    }

                    if(BeatsManager.beatHit == BeatsManager.beatMax){

                        if(metallicHealth + 10 >= GameManager.metalmanHealthMax){

                            metallicHealth = GameManager.metalmanHealthMax;
                        }
                        else{

                            metallicHealth += 10;
                        }
                    }

                    GameManager.unitDictionaryHealth["Metalleux"] = metallicHealth;
                }

                if(whoHeal == 2){

                    if(BeatsManager.beatHit <= BeatsManager.beatMax / 2){

                        if(jazzHealth + 3 >= GameManager.jazzmanHealthMax){

                            jazzHealth = GameManager.jazzmanHealthMax;
                        }
                        else{

                            jazzHealth += 3;
                        }
                    }

                    if(BeatsManager.beatHit > BeatsManager.beatMax / 2 && BeatsManager.beatHit <= BeatsManager.beatMax){

                        if(jazzHealth + 6 >= GameManager.jazzmanHealthMax){

                            jazzHealth = GameManager.jazzmanHealthMax;
                        }
                        else{

                            jazzHealth += 6;
                        }
                    }

                    if(BeatsManager.beatHit == BeatsManager.beatMax){

                        if(jazzHealth + 10 >= GameManager.jazzmanHealthMax){

                            jazzHealth = GameManager.jazzmanHealthMax;
                        }
                        else{

                            jazzHealth += 10;
                        }
                    }

                    GameManager.unitDictionaryHealth["Jazz"] = jazzHealth;
                }

                if(whoHeal == 3){

                    if(BeatsManager.beatHit <= BeatsManager.beatMax / 2){

                        if(electronicHealth + 3 >= GameManager.electronicmanHealthMax){

                            electronicHealth = GameManager.electronicmanHealthMax;
                        }
                        else{

                            electronicHealth += 3;
                        }
                    }

                    if(BeatsManager.beatHit > BeatsManager.beatMax / 2 && BeatsManager.beatHit <= BeatsManager.beatMax){

                        if(electronicHealth + 6 >= GameManager.electronicmanHealthMax){

                            electronicHealth = GameManager.electronicmanHealthMax;
                        }
                        else{

                            electronicHealth += 6;
                        }
                    }

                    if(BeatsManager.beatHit == BeatsManager.beatMax){

                        if(electronicHealth + 10 >= GameManager.electronicmanHealthMax){

                            electronicHealth = GameManager.electronicmanHealthMax;
                        }
                        else{

                            electronicHealth += 10;
                        }
                    }

                    GameManager.unitDictionaryHealth["Electro"] = electronicHealth;
                }
            }

            StopAllCoroutines();
            StartCoroutine(FightFinish());
        }
    }

    IEnumerator FightFinish(){

        yield return new WaitForSeconds(5f);

        GameManager.indexScene = true;
        GameManager.whoAttack = 0;

        SceneManager.LoadScene(2);
    }
}
