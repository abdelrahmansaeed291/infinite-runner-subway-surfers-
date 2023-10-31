using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landscape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight; // Force landscape mode
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation != ScreenOrientation.LandscapeRight)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight; // Force landscape mode
        }
    }
}
