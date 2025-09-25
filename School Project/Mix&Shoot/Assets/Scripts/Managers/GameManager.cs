using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    public static GameManager Instance { get { return s_instance; } }
    public int Score { get; set; }
    [SerializeField] private Transform _door;
    public Transform Door => _door;

    [SerializeField] private float timeBeforePlayerRespawn;

    private Button currentSelectedButton;

    [SerializeField] private Button restartButton;
    [SerializeField] private AudioPack audioPackWin;
    [SerializeField] private AudioPack audioPackLose;
    
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    
    private AudioSource _audioSource;

    private bool onPause;
    public bool OnPause { get { return onPause; } }


    private void Awake()
    {
        if (s_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_instance = this;
            //ResetScore();
            onPause = false;
        }
        print("Im a game Manager");
        
        _audioSource = GetComponent<AudioSource>();
        
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        _audioSource.outputAudioMixerGroup = audioMixerGroup;
    }

    public void AddScore(int addPoints)
    {
        Score += addPoints;
        if (HUDManager.Instance != null) HUDManager.Instance.UpdateScore();
    }

    public void RemoveScore(int removePoints)
    {
        Score -= removePoints;
        if (Score < 0) Score = 0;
        if (HUDManager.Instance != null) HUDManager.Instance.UpdateScore();
    }

    public void ResetScore()
    {
        Score = 0;
        if (HUDManager.Instance != null) HUDManager.Instance.UpdateScore();
    }

    public void Pause()
    {
        if (onPause)
        {
            Time.timeScale = 1.0f;
            if (HUDManager.Instance != null) HUDManager.Instance.TogglePauseMenu(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            if (HUDManager.Instance != null) HUDManager.Instance.TogglePauseMenu(true);
        }

        onPause = !onPause;
    }

    public void Victory()
    {
        Time.timeScale = 0.0f;
        
        audioPackWin.PlayOn(_audioSource);

        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.ToggleEndGameVictoryMenu(true);

            restartButton.Select();
        }
    }

    internal void GameOver()
    {
        Time.timeScale = 0.0f;
        
        audioPackLose.PlayOn(_audioSource);

        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.ToggleEndGameDefeatMenu(true);

            restartButton.Select();
        }
    }
    private void Update()
    {
        Debug.Log("Score : " + Score);
    }
}
