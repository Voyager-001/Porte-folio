using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetallicBeats : MonoBehaviour{
    
    public GameObject metallicBeatUp;
    public GameObject metallicBeatDown;
    public GameObject metallicBeatLeft;
    public GameObject metallicBeatRight;

    public static MetallicBeats MBInstance;

    // Start is called before the first frame update
    void Start(){
        
        MBInstance = this;
    }

    // Update is called once per frame
    void Update(){


    }

    public void SpawnMetallicBeats(){

        int random = Random.Range(0, 4);

        if(random == 0){

            GameObject arrowUp = Instantiate(metallicBeatUp, new Vector3(7, 5.4f, 0), Quaternion.identity);

            arrowUp.transform.SetParent(GameObject.FindGameObjectWithTag("MetallicBeat").transform);

            BeatsManager.metallicCount += 0.31f;
        }

        if(random == 1){

            GameObject arrowDown = Instantiate(metallicBeatDown, new Vector3(7, 2.5f, 0), Quaternion.Euler(0, 0, 180));

            arrowDown.transform.SetParent(GameObject.FindGameObjectWithTag("MetallicBeat").transform);

            BeatsManager.metallicCount += 0.31f;
        }

        if(random == 2){

            GameObject arrowLeft = Instantiate(metallicBeatLeft, new Vector3(7, 3.5f, 0), Quaternion.Euler(0, 0, 90));

            arrowLeft.transform.SetParent(GameObject.FindGameObjectWithTag("MetallicBeat").transform);

            BeatsManager.metallicCount += 0.31f;
        }

        if(random == 3){

            GameObject arrowRight = Instantiate(metallicBeatRight, new Vector3(7, 4.5f, 0), Quaternion.Euler(0, 0, -90));

            arrowRight.transform.SetParent(GameObject.FindGameObjectWithTag("MetallicBeat").transform);

            BeatsManager.metallicCount += 0.31f;
        }
    }
}
