using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBeats : MonoBehaviour{
    
    public GameObject healBeatUp;
    public GameObject healBeatDown;
    public GameObject healBeatLeft;
    public GameObject healBeatRight;

    public static HealBeats HBInstance;

    // Start is called before the first frame update
    void Start(){
        
        HBInstance = this;
    }

    // Update is called once per frame
    void Update(){


    }

    public void SpawnHealBeats(){

        int random = Random.Range(0, 4);

        if(random == 0){

            GameObject arrowUp = Instantiate(healBeatUp, new Vector3(7, 5.4f, 0), Quaternion.identity);

            arrowUp.transform.SetParent(GameObject.FindGameObjectWithTag("HealBeat").transform);

            BeatsManager.healCount += 0.31f;
        }

        if(random == 1){

            GameObject arrowDown = Instantiate(healBeatDown, new Vector3(7, 2.5f, 0), Quaternion.Euler(0, 0, 180));

            arrowDown.transform.SetParent(GameObject.FindGameObjectWithTag("HealBeat").transform);

            BeatsManager.healCount += 0.31f;
        }

        if(random == 2){

            GameObject arrowLeft = Instantiate(healBeatLeft, new Vector3(7, 3.5f, 0), Quaternion.Euler(0, 0, 90));

            arrowLeft.transform.SetParent(GameObject.FindGameObjectWithTag("HealBeat").transform);

            BeatsManager.healCount += 0.31f;
        }

        if(random == 3){

            GameObject arrowRight = Instantiate(healBeatRight, new Vector3(7, 4.5f, 0), Quaternion.Euler(0, 0, -90));

            arrowRight.transform.SetParent(GameObject.FindGameObjectWithTag("HealBeat").transform);

            BeatsManager.healCount += 0.31f;
        }
    }
}
