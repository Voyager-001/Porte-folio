using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QTEManager : MonoBehaviour{
    
    public GameObject displayBox;
    public GameObject passBox;
    public GameObject startUI;
    public GameObject QTEUI;
    public GameObject BeatsManager;
    public GameObject VFXPass;
    public GameObject countText;

    public AudioSource QTE;
    public AudioSource win;
    public AudioSource loose;

    public int QTEGen;
    public int waitingForInput;
    public int correctInput;
    public int countingDown;
    public int QTERestart;

    public static QTEManager QMInstance;

    public static int QTECounter;
    public static int QTEValide;

    public bool QTEEnd = true;

    void Awake(){

        if(GameManager.fight == 0){

            QTEUI.SetActive(true);
            BeatsManager.SetActive(false);

            QTECounter = 0;
            QTEValide = 0;
        }
    }

    void Start(){

        QMInstance = this;

        QTE.Play();
    }

    void Update(){

        if((Input.touchCount > 0 || QTERestart == 1) && QTECounter < 5){

            startUI.SetActive(false);

            QTERestart = 0;

            countText.GetComponent<TextMeshProUGUI>().text = "QTE: " + QTECounter + "/5";

            if(waitingForInput == 0){

                countingDown = 1;
                QTECounter += 1;

                StopAllCoroutines();
                StartCoroutine(CountDown());

                waitingForInput = 1;

                displayBox.GetComponent<TextMeshProUGUI>().text = "[T]";

                QTEGen = 1;
            }
        }

        if(Input.touchCount > 0 && QTEGen == 1 && QTECounter < 5){
                
            StartCoroutine(InputPressing());
        }

        if(QTECounter == 5 && QTEEnd){

            QTEEnd = false;

            if(QTEValide < 3){

                loose.Play();
            }

            if(QTEValide >= 3){

                win.Play();
            }

            StartCoroutine(EndQTE());
        }
    }

    IEnumerator EndQTE(){

        yield return new WaitForSeconds(7f);

        FightManager.fightEnd = true;
    }

    IEnumerator InputPressing(){

        QTEGen = 0;

        VFXPass.SetActive(true);

        countingDown = 2;

        passBox.GetComponent<TextMeshProUGUI>().text = "Pass";

        yield return new WaitForSeconds(1f);

        correctInput = 0;

        passBox.GetComponent<TextMeshProUGUI>().text = "";
        displayBox.GetComponent<TextMeshProUGUI>().text = "";

        yield return new WaitForSeconds(1f);

        waitingForInput = 0;
        countingDown = 1;
        QTERestart = 1;

        QTEValide += 1;
    }

    IEnumerator CountDown(){

        yield return new WaitForSeconds(1f);

        if(countingDown == 1){

            QTEGen = 4;
            countingDown = 2;

            passBox.GetComponent<TextMeshProUGUI>().text = "Fail";

            yield return new WaitForSeconds(1f);

            correctInput = 0;

            passBox.GetComponent<TextMeshProUGUI>().text = "";
            displayBox.GetComponent<TextMeshProUGUI>().text = "";

            yield return new WaitForSeconds(1f);

            waitingForInput = 0;
            countingDown = 1;
            QTERestart = 1;
        }
    }
}
