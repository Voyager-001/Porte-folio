using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicBeats : MonoBehaviour{
    
    public GameObject electronicBeatUp;
    public GameObject electronicBeatDown;
    public GameObject electronicBeatLeft;
    public GameObject electronicBeatRight;

    public static ElectronicBeats EBInstance;

    // Start is called before the first frame update
    void Start(){
        
        EBInstance = this;
    }

    // Update is called once per frame
    void Update(){


    }

    public void SpawnElectronicBeats(){

        int random = Random.Range(0, 4);

        if(random == 0){

            GameObject arrowUp = Instantiate(electronicBeatUp, new Vector3(7, 5.4f, 0), Quaternion.identity);

            arrowUp.transform.SetParent(GameObject.FindGameObjectWithTag("ElectronicBeat").transform);

            BeatsManager.electronicCount += 0.31f;
        }

        if(random == 1){

            GameObject arrowDown = Instantiate(electronicBeatDown, new Vector3(7, 2.5f, 0), Quaternion.Euler(0, 0, 180));

            arrowDown.transform.SetParent(GameObject.FindGameObjectWithTag("ElectronicBeat").transform);

            BeatsManager.electronicCount += 0.31f;
        }

        if(random == 2){

            GameObject arrowLeft = Instantiate(electronicBeatLeft, new Vector3(7, 3.5f, 0), Quaternion.Euler(0, 0, 90));

            arrowLeft.transform.SetParent(GameObject.FindGameObjectWithTag("ElectronicBeat").transform);

            BeatsManager.electronicCount += 0.31f;
        }

        if(random == 3){

            GameObject arrowRight = Instantiate(electronicBeatRight, new Vector3(7, 4.5f, 0), Quaternion.Euler(0, 0, -90));

            arrowRight.transform.SetParent(GameObject.FindGameObjectWithTag("ElectronicBeat").transform);

            BeatsManager.electronicCount += 0.31f;
        }
    }
}
