using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{

    int score;
    int red;
    int green;
    public int blue;
    public bool scshield = false;
    public bool multiplier = false;
    public bool nuke = false;



    public bool scshieldactive = false;
    public bool multiplieractive = false;
    public bool nukeactive = false;

    public static GameManager inst;
    [SerializeField] Rigidbody rb;

    public TMP_Text scoreText;
    public TMP_Text redText;
    public TMP_Text greenText;
    public TMP_Text blueText;
    public TMP_Text Finalscore;

    [SerializeField] PlayerMovement playerMovement;
    private GroundTile obstacleInstance;
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4;

    public void IncrementScore(string x)
    {
        score++;
        src.Stop();
        src.clip = sfx1;
        src.Play();

        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
        switch (x)
        {
            case "Red":
                if (!nuke)
                {
                    red++;

                }

                if (nuke)
                {
                    //   red+=2;

                    score++;

                }
                if (multiplieractive)
                {
                    score += 4;
                    red++;
                    multiplieractive = false;
                }


                if (red > 5)
                {
                    red = 5;
                }
                redText.text = "Red: " + red;
                break;
            case "Green":
                // Handle collision with Green object
                if (!multiplier)
                {
                    green++;
                }
                if (multiplier)
                {
                    // green += 2;
                    score++;

                }
                if (multiplieractive)
                {
                    score += 8;
                    multiplieractive = false;
                }
                if (green > 5)
                {
                    green = 5;

                }
                greenText.text = "Green: " + green;
                break;
            case "Blue":
                if (!scshield)
                {
                    blue++;
                }
                if (scshield)
                {
                    //  blue += 2;
                    score++;

                }
                if (multiplieractive)
                {
                    score += 4;
                    blue++;
                    multiplieractive = false;
                }
                if (blue > 5)
                {
                    blue = 5;
                }
                blueText.text = "blue: " + blue;

                // Handle collision with Blue object
                break;
            default:
                // Handle other cases if needed
                break;
        }
        scoreText.text = "Score: " + score;
    }

    public void DecrementScore(string x)
    {

        switch (x)
        {
            case "Red":

                red--;
                redText.text = "Red: " + red;
                if (red == 0)
                {
                    nuke = false;
                    nukeactive = false;
                }

                break;
            case "Green":
                // Handle collision with Green object

                green--;
                greenText.text = "Green: " + green;
                if (green == 0)
                {
                    multiplier = false;
                    multiplieractive = false;
                }

                break;
            case "Blue":

                blue--;
                blueText.text = "blue: " + blue;
                if (red == 0)
                {
                    scshield = false;
                    scshieldactive = false;
                }

                // Handle collision with Blue object
                break;
            default:
                // Handle other cases if needed
                break;
        }
    }

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        obstacleInstance = FindObjectOfType<GroundTile>();


    }
    public void redEnergy()
    {
        if (red == 5 && !nuke)
        {
            src.Stop();
            src.clip = sfx3;
            src.Play();
            DecrementScore("Red");
            multiplier = false;
            scshield = false;
            nuke = true;
            multiplieractive = false;
            scshieldactive = false;
        }
        else
        {
            src.Stop();
            src.clip = sfx2;
            src.Play();
        }
    }
    public void greenEnergy()
    {
        if (green == 5 && !multiplier)
        {
            src.Stop();
            src.clip = sfx3;
            src.Play();
            DecrementScore("Green");
            multiplier = true;
            scshield = false;
            nuke = false;
            scshieldactive = false;
            nukeactive = false;
        }
        else
        {
            src.Stop();
            src.clip = sfx2;
            src.Play();
        }
    }
    public void blueEnergy()
    {
        if (blue == 5 && !scshield)
        {
            src.Stop();
            src.clip = sfx3;
            src.Play();
            DecrementScore("Blue");
            scshield = true;
            multiplier = false;
            nuke = false;
            multiplieractive = false;
            nukeactive = false;
        }
        else
        {
            src.Stop();
            src.clip = sfx2;
            src.Play();
        }
    }


    public void activate()
    {
        if (blue > 0 && scshield && !scshieldactive)
        {
            src.Stop();
            src.clip = sfx4;
            src.Play();
            DecrementScore("Blue");
            scshieldactive = true;

        }
        else if (green > 0 && multiplier && !multiplieractive)
        {
            src.Stop();
            src.clip = sfx4;
            src.Play();
            DecrementScore("Green");
            multiplieractive = true;

        }
        else if (red > 0 && nuke)
        {
            src.Stop();
            src.clip = sfx4;
            src.Play();
            //nukeactive = true;
            GroundTile.DestroyAllObstacles();
            DecrementScore("Red");
        }
        else
        {
            src.Stop();
            src.clip = sfx2;
            src.Play();
        }
    }

    private void Update()
    {

        Renderer renderer = rb.GetComponent<Renderer>();

        // Create a new material with the desired color (blue)
        Material newMaterial = new Material(renderer.sharedMaterial);
          if (Input.GetKeyDown(KeyCode.L))
          {
            blueEnergy();
             /* if (blue ==5  && !scshield) 
              {
                  src.Stop();
                  src.clip = sfx3;
                  src.Play();
                  DecrementScore("Blue");
                  scshield = true;
                  multiplier = false;
                  nuke = false;
                  multiplieractive = false;
                  nukeactive = false;
              }
              else
              {
                  src.Stop();
                  src.clip = sfx2;
                  src.Play();
              }*/

          }
          if (Input.GetKeyDown(KeyCode.K))
          {

            greenEnergy();
              /*if (green ==5 && !multiplier)
              {
                  src.Stop();
                  src.clip = sfx3;
                  src.Play();
                  DecrementScore("Green");
                  multiplier = true;
                  scshield = false;
                  nuke = false;
                  scshieldactive = false;
                  nukeactive = false;
              }
              else
              {
                  src.Stop();
                  src.clip = sfx2;
                  src.Play();
              }*/

          }
          
         if (Input.GetKeyDown(KeyCode.J))
          {
            redEnergy();

          }
        /////////// activation ////////////////////////


        if (Input.GetKeyDown(KeyCode.Space))
        {

            activate();
           /* if (blue > 0 && scshield && !scshieldactive)
            {
                src.Stop();
                src.clip = sfx4;
                src.Play();
                DecrementScore("Blue");
                scshieldactive = true;
                
            }
            else if (green > 0 && multiplier && !multiplieractive)
            {
                src.Stop();
                src.clip = sfx4;
                src.Play();
                DecrementScore("Green");
                multiplieractive = true;
                
            }
            else if (red > 0 && nuke)
            {
                src.Stop();
                src.clip = sfx4;
                src.Play();
                //nukeactive = true;
                GroundTile.DestroyAllObstacles();
                DecrementScore("Red");
                newMaterial.color = Color.red;

                // Assign the new material to the object
                renderer.material = newMaterial;
            }
            else
            {
                src.Stop();
                src.clip = sfx2;
                src.Play();
            }*/
        }


        ///////////////////////////////////////////////
        if (scshieldactive)
        {
            newMaterial.color = Color.black;

            // Assign the new material to the object
            renderer.material = newMaterial;
        }
        else if (multiplieractive)
        {
            newMaterial.color = Color.yellow;

            // Assign the new material to the object
            renderer.material = newMaterial;
        }
        else if (scshield)
        {

            newMaterial.color = Color.blue;

            // Assign the new material to the object
            renderer.material = newMaterial;
        }
        else if (multiplier)
        {

            newMaterial.color = Color.green;

            // Assign the new material to the object
            renderer.material = newMaterial;
        }
        else if (nuke)
        {
            newMaterial.color = Color.red;

            // Assign the new material to the object
            renderer.material = newMaterial;
        }

        else
        {
            newMaterial.color = Color.gray;

            // Assign the new material to the object
            renderer.material = newMaterial;
        }


        Finalscore.text = "Finalscore: " + score;

    }
}