using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MuteAudio : MonoBehaviour
{
    // Start is called before the first frame update
   // bool muted = true;
    public Toggle toggle;
    public void MuteToggle()
    {
        if (toggle.isOn)
        {
            AudioListener.volume = 0;
            print("muted");
          
            //toggle.isOn = true;
        }
        else
        {
            AudioListener.volume = 1;
            print("unmuted");
           
           // toggle.isOn = true;


        }

    }

    private void Update()
    {
        if(AudioListener.volume == 0)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }
}
