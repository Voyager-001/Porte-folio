using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatObject : MonoBehaviour{

    public bool canBePressed;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if(Input.touchCount > 0){

            if(canBePressed){

                Destroy(gameObject);

                BeatsManager.BMInstance.BeatHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Beat"){

            canBePressed = true;
        }

        if(other.tag == "Dead"){
            
            Destroy(gameObject);

            BeatsManager.BMInstance.BeatMissed();
        }
    }

    private void OnTriggerExit2D(Collider2D other){

        if(other.tag == "Beat"){

            canBePressed = false;
        }

        if(other.tag == "Enter"){

            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
