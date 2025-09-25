using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Text volumeText;

    private float _masterVolume;
    private float _musicVolume;
    private float _sfxVolume;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SavedMasterVolume"))
        {
            PlayerPrefs.SetFloat("SavedMasterVolume", 0.5f);
            _masterVolume = 0.5f;
        }
        if (!PlayerPrefs.HasKey("SavedMusicVolume"))
        {
            PlayerPrefs.SetFloat("SavedMusicVolume", 0.7f);
            _musicVolume = 0.7f;
        }
        if (!PlayerPrefs.HasKey("SavedSFXVolume"))
        {
            PlayerPrefs.SetFloat("SavedSFXVolume", 0.7f);
            _sfxVolume = 0.7f;
        }
        
        Load();
    }
    
    private void Load()
    {
        _masterVolume = PlayerPrefs.GetFloat("SavedMasterVolume");
        _musicVolume = PlayerPrefs.GetFloat("SavedMusicVolume");
        _sfxVolume = PlayerPrefs.GetFloat("SavedSFXVolume");

        SetVolume("MasterVolume", _masterVolume);
        SetVolume("MusicVolume", _musicVolume);
        SetVolume("SFXVolume", _sfxVolume);
    }

    private void SetVolume(string parameterName, float volume)
    {
        audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20); // Convert linear 0-1 to decibels
    }

    public void DecreaseMasterVolume()
    {
        AdjustVolume(ref _masterVolume, "MasterVolume", -0.1f);
    }

    public void IncreaseMasterVolume()
    {
        AdjustVolume(ref _masterVolume, "MasterVolume", 0.1f);
    }

    public void DecreaseMusicVolume()
    {
        AdjustVolume(ref _musicVolume, "MusicVolume", -0.1f);
    }

    public void IncreaseMusicVolume()
    {
        AdjustVolume(ref _musicVolume, "MusicVolume", 0.1f);
    }

    public void DecreaseSFXVolume()
    {
        AdjustVolume(ref _sfxVolume, "SFXVolume", -0.1f);
    }

    public void IncreaseSFXVolume()
    {
        AdjustVolume(ref _sfxVolume, "SFXVolume", 0.1f);
    }

    private void AdjustVolume(ref float volume, string parameterName, float amount)
    {
        volume = Mathf.Clamp(volume + amount, 0.0001f, 1f);
        SetVolume(parameterName, volume);
        PlayerPrefs.SetFloat("Saved" + parameterName, volume);
        UpdateVolumeText(volume, parameterName);
    }

    private void UpdateVolumeText(float volume, string displayName)
    {
        if (volumeText != null)
        {
            volumeText.text = $"{displayName}: {(volume * 100f):F0}%";
        }
    }
}