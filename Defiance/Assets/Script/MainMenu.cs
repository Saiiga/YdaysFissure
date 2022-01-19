using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : WinCondition
{
    [SerializeField]
    private bool OnPause;
    [SerializeField]
    public GameObject pausePanel;
    [SerializeField]
    public GameObject winPanel;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!OnPause)
            {
                Time.timeScale = 0;
                OnPause = true;
                pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                OnPause = false;
                pausePanel.SetActive(false);
            }

            if (hasWin)
            {
                Time.timeScale = 0;
                winPanel.SetActive(true);
            }
        }
    }

    public void ReturnToMenuAfterWin()
    {
        Time.timeScale = 1;
        winPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        OnPause = false;
        pausePanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
