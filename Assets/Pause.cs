using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    // private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }

    /*void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0; // Pause the game
            // Add any other pause-related actions here
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1; // Unpause the game
            // Add any other unpause-related actions here
        }
    }*/
    public void pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);

    }

    public void MAinMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
