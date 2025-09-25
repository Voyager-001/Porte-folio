using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private Button defaultButton;

    private void Update()
    {
        if (defaultButton != null && EventSystem.current.currentSelectedGameObject == null) defaultButton.Select();
    }

    public void LoadScene(int sceneId)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneId);
       
    }
}
