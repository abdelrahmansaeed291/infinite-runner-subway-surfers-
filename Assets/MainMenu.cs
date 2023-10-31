using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1); // Load your game scene
    }
    public void QuitGame()
    {
        Application.Quit(); // Load your game scene
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
