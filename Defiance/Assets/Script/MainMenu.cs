using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private bool OnPause;
    [SerializeField]
    public GameObject pausePanel;

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
        }
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
