using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Obstacle : MonoBehaviour
{

    PlayerMovement playerMovement;
    public AudioClip sfx2;


    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Kill the player
            GameManager.inst.src.Stop();
            GameManager.inst.src.clip = sfx2;
            GameManager.inst.src.Play();
            if (GameManager.inst.scshield)
            {
                if (GameManager.inst.scshieldactive)
                {
                    Destroy(gameObject);
                    GameManager.inst.scshieldactive = false;
                    if(GameManager.inst.blue == 0)
                    {
                        GameManager.inst.scshield = false;
                    }
                    

                }
                else
                {
                    Destroy(gameObject);
                    GameManager.inst.scshield = false;
                    
                }  
            }else if (GameManager.inst.multiplier)
            {
                Destroy(gameObject);
                GameManager.inst.multiplieractive = false;
                GameManager.inst.multiplier = false;

            }
            else if (GameManager.inst.nuke)
            {
                Destroy(gameObject);
                GameManager.inst.nukeactive = false;
                GameManager.inst.nuke = false;

            }
            else
            {
                playerMovement.Die();
            }
            
        }
    }

    private void Update()
    {

    }
}