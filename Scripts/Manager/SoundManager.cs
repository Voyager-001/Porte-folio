using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour{
    
    [SerializeField] Slider volumeSlider;

    void Start(){

        if(!PlayerPrefs.HasKey("SavedMasterVolume")){

            PlayerPrefs.SetFloat("SavedMasterVolume", 0.5f);
        }

        if(!PlayerPrefs.HasKey("SavedMusicVolume")){

            PlayerPrefs.SetFloat("SavedMusicVolume", 1f);
        }

        if(!PlayerPrefs.HasKey("SavedSFXVolume")){

            PlayerPrefs.SetFloat("SavedSFXVolume", 1f);
        }
        
        Load();
    }

    public void ChangeVolume(){

        AudioListener.volume = volumeSlider.value;

        Save();
    }

    private void Load(){

        volumeSlider.value = PlayerPrefs.GetFloat("SavedMasterVolume");
        volumeSlider.value = PlayerPrefs.GetFloat("SavedMusicVolume");
        volumeSlider.value = PlayerPrefs.GetFloat("SavedSFXVolume");
    }

    private void Save(){

        PlayerPrefs.SetFloat("SavedMasterVolume", volumeSlider.value);
        PlayerPrefs.SetFloat("SavedMusicVolume", volumeSlider.value);
        PlayerPrefs.SetFloat("SavedSFXVolume", volumeSlider.value);
    }
}
