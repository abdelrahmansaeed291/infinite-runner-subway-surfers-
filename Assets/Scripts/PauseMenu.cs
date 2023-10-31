using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PausePanel;
    public GameObject music;
    //  private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
   /* void TogglePause()
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
    public void Pause()
    {
        music.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        music.SetActive(true);
    }
    public void Restart()
    {
        PausePanel.SetActive(false);
        music.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);

    }
  
    public void MAinMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
