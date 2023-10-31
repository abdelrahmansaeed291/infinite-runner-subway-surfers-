using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform player;
    Vector3 offset;
    bool third = true;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            third = !third;

        }
        if (third)
        {
            Vector3 targetPos = player.position + offset;
            targetPos.x = 0;
            transform.position = targetPos;
            transform.rotation = Quaternion.Euler(30f, 0f, 0f);
        }
        else
        {
            transform.position = player.position;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }

    }
}