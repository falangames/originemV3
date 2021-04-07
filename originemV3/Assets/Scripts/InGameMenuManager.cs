using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    public GameObject InGamePanel;
    public GameObject PausePanel;

    void Start()
    {
        Time.timeScale = 1;
    }
    public void OnClick_PauseButton()
    {
        StickControl.Instance.OnClick_AudioOnOff();
        InGamePanel.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnClick_ContinueButton()
    {
        StickControl.Instance.OnClick_AudioOnOff();
        InGamePanel.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClick_PlayButton()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("MainScene");
        //float loadProgress = loadingOperation.progress;
        if (loadingOperation.isDone)
        {
            SceneManager.LoadScene("MainScene");
            Time.timeScale = 1;
        }
    }
    public void OnClick_MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;

    }
    public void OnClick_RestartButton()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }
    public void OnClick_InfoButton()
    {
        SceneManager.LoadScene("InfoScene");
        Time.timeScale = 1;
    }
    public void OnClick_PatreonButton()
    {
        Application.OpenURL("https://www.patreon.com/falangamestudio");
    }
}
