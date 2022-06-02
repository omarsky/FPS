using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator m_crossfadeAnimator;
    [SerializeField] float m_transitionTime = 1f;
    [SerializeField] GameObject m_loadingScreen;
    [SerializeField] Slider m_loadingBar;

    public static LevelLoader m_instance { get; private set; }

    private void Awake()
    {
        m_instance = this;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevelAsync(int levelIndex)
    {
        m_crossfadeAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(m_transitionTime);


        if (m_loadingScreen)
        {
            m_loadingScreen.SetActive(true);
        }
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(levelIndex);

        while (!loadOp.isDone)
        {
            if (m_loadingBar)
            {
                m_loadingBar.value = loadOp.progress / 0.9f;
            }
            yield return null;
        }


    }
    IEnumerator LoadLevel(int levelIndex)
    {
        m_crossfadeAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(m_transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
