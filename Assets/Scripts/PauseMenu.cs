using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool m_gameIsPaused = false;

    [SerializeField]
    GameObject[] m_objectsToDisableWhenPaused;
    [SerializeField]
    GameObject m_pauseMenu;
    [SerializeField]
    InputAction m_pauseAction;

    private void OnEnable()
    {
        m_pauseAction.Enable();
        m_pauseAction.performed += OnPauseAction;
    }

    private void OnDisable()
    {
        m_pauseAction.Disable();
    }

    private void OnPauseAction(InputAction.CallbackContext value)
    {
        if (m_gameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        m_pauseMenu.SetActive(false);
        foreach (GameObject obj in m_objectsToDisableWhenPaused)
        {
            obj.GetComponent<CanvasGroup>().alpha = 1f;
        }
        Time.timeScale = 1f;
        m_gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        m_pauseMenu.SetActive(true);
        foreach (GameObject obj in m_objectsToDisableWhenPaused)
        {
            obj.GetComponent<CanvasGroup>().alpha = 0f;
        }
        Time.timeScale = 0f;
        m_gameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Other.MainMenuName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
