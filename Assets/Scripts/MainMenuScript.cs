using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f; //in case we entered main menu from pause menu
    }

    public void PlayTheGame()
    {
        LevelLoader.m_instance.LoadNextLevel();
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
