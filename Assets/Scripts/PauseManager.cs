using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public TMP_Text pausedText;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pausedText.text = ""; // Hide the text when unpausing
            }
            else
            {
                Time.timeScale = 0;
                pausedText.text = "Paused"; // Show the text when pausing
            }
        }
    }
}
