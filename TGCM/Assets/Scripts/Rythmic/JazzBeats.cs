using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JazzBeats : MonoBehaviour{

    public GameObject jazzBeatUp;
    public GameObject jazzBeatDown;
    public GameObject jazzBeatLeft;
    public GameObject jazzBeatRight;

    public static JazzBeats JBInstance;

    // Start is called before the first frame update
    void Start(){
            
        JBInstance = this;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnJazzBeats(){

        int random = Random.Range(0, 4);

        if(random == 0){

            GameObject arrowUp = Instantiate(jazzBeatUp, new Vector3(7, 5.4f, 0), Quaternion.identity);

            arrowUp.transform.SetParent(GameObject.FindGameObjectWithTag("JazzBeat").transform);

            BeatsManager.jazzCount += 0.31f;
        }

        if(random == 1){

            GameObject arrowDown = Instantiate(jazzBeatDown, new Vector3(7, 2.5f, 0), Quaternion.Euler(0, 0, 180));

            arrowDown.transform.SetParent(GameObject.FindGameObjectWithTag("JazzBeat").transform);

            BeatsManager.jazzCount += 0.31f;
        }

        if(random == 2){

            GameObject arrowLeft = Instantiate(jazzBeatLeft, new Vector3(7, 3.5f, 0), Quaternion.Euler(0, 0, 90));

            arrowLeft.transform.SetParent(GameObject.FindGameObjectWithTag("JazzBeat").transform);

            BeatsManager.jazzCount += 0.31f;
        }

        if(random == 3){

            GameObject arrowRight = Instantiate(jazzBeatRight, new Vector3(7, 4.5f, 0), Quaternion.Euler(0, 0, -90));

            arrowRight.transform.SetParent(GameObject.FindGameObjectWithTag("JazzBeat").transform);

            BeatsManager.jazzCount += 0.31f;
        }
    }
}
