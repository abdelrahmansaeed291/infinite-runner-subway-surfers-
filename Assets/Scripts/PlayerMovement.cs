using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;
    public GameObject PausePanel;

    public float speed = 5;
    [SerializeField] Rigidbody rb;
    public GameObject music;

    float horizontalInput;
    //[SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;
    private float laneWidth = 10/3f;
    private float currentLane = 1;
    

    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        forwardMove.x = 0f;
        forwardMove.y = 0f;
        rb.MovePosition(rb.position + forwardMove);

       



        

        // Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

    }
    void SwitchLane(int direction)
    {
        int newLane = (int)Mathf.Clamp(currentLane + direction, 0, 2);

        Vector3 targetPosition = transform.position;
        targetPosition.x = (newLane - 1) * laneWidth;
       

        currentLane = newLane;
        rb.MovePosition(targetPosition);
    }

    private void Update()
    {
        /* horizontalInput = Input.GetAxis("Horizontal");
         if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
         {
             SwitchLane(-1); // Move left
         }
         else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
         {
             SwitchLane(1); // Move right
         }
         */
         if (transform.position.y < -5)
         {
             Die();
         }
        if (alive)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SwitchLane(-1); // Move left
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                SwitchLane(1); // Move right
            }
        }
    }

    public void Die()
    {
        PausePanel.SetActive(true);
        music.SetActive(false);
        Time.timeScale = 0;
    }

   /* void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
    private void Start()
    {
        rb.transform.position = new Vector3(0f, 0.7f, 3f);
        /* int index = Random.Range(0, 3);
         if (index == 0)
         {
             rb.transform.position = new Vector3(-3.333f, 1f, 3f);
             Lane1 = true;
             Lane2 = false;
             Lane3 = false;

         }
         else if (index == 1)
         {
             rb.transform.position = new Vector3(0f, 1f, 3f);
             Lane2 = true;
             Lane1 = false;
             Lane3 = false;

         }
         else
         {
             rb.transform.position = new Vector3(3.333f, 1f, 3f);
             Lane3 = true;
             Lane1 = false;
             Lane2 = false;

         }
        */

    }
}