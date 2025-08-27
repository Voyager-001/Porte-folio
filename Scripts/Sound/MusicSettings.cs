using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicSettings : MonoBehaviour{
    internal int length;
    private AudioSource audioSource;

    public static MusicSettings MSInstance;

    private void Awake(){

        DontDestroyOnLoad(transform.gameObject);
        
        audioSource = GetComponent<AudioSource>();

        var a = FindObjectsOfType<MusicSettings>();

        if(a.Length > 1){

            Destroy(gameObject);

            return;
        }
    }

    void Start(){

        MSInstance = this;
    }

    void Update(){

        if(SceneManager.GetActiveScene().buildIndex == 3){

            PauseMusic();
        }
    }

    public void PlayMusic(){

        audioSource.Play();
    }

    public void PauseMusic(){

        audioSource.Pause();
    }
}
