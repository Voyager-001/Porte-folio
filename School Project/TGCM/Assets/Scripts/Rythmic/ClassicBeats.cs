using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicBeats : MonoBehaviour{
    
    public GameObject ClassicBeatUp;
    public GameObject ClassicBeatDown;
    public GameObject ClassicBeatLeft;
    public GameObject ClassicBeatRight;

    public static ClassicBeats CBInstance;

    // Start is called before the first frame update
    void Start(){
        
        CBInstance = this;
    }

    // Update is called once per frame
    void Update(){


    }

    public void SpawnClassicBeats(){

        int random = Random.Range(0, 4);

        if(random == 0){

            GameObject arrowUp = Instantiate(ClassicBeatUp, new Vector3(7, 5.4f, 0), Quaternion.identity);

            arrowUp.transform.SetParent(GameObject.FindGameObjectWithTag("ClassicBeat").transform);

            BeatsManager.classicCount += 0.31f;
        }

        if(random == 1){

            GameObject arrowDown = Instantiate(ClassicBeatDown, new Vector3(7, 2.5f, 0), Quaternion.Euler(0, 0, 180));

            arrowDown.transform.SetParent(GameObject.FindGameObjectWithTag("ClassicBeat").transform);

            BeatsManager.classicCount += 0.31f;
        }

        if(random == 2){

            GameObject arrowLeft = Instantiate(ClassicBeatLeft, new Vector3(7, 3.5f, 0), Quaternion.Euler(0, 0, 90));

            arrowLeft.transform.SetParent(GameObject.FindGameObjectWithTag("ClassicBeat").transform);

            BeatsManager.classicCount += 0.31f;
        }

        if(random == 3){

            GameObject arrowRight = Instantiate(ClassicBeatRight, new Vector3(7, 4.5f, 0), Quaternion.Euler(0, 0, -90));

            arrowRight.transform.SetParent(GameObject.FindGameObjectWithTag("ClassicBeat").transform);

            BeatsManager.classicCount += 0.31f;
        }
    }
}
