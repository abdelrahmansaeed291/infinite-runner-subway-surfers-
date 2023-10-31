
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject RedPrefab;
    public GameObject GreenPrefab;
    public GameObject BluePrefab;
    public static List<GameObject> spawnedObstacles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        

    }
    public static void DestroyAllObstacles()
    {
        // Loop through the list of spawned obstacles and destroy them
        foreach (GameObject obstacle in spawnedObstacles)
        {
            Destroy(obstacle);
        }

        // Clear the list after destroying all obstacles
        spawnedObstacles.Clear();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame

    public void SpawnObstacle()
    {
        float spawnProbability = Random.Range(0f, 1f);
        int obstacleSpawnIndex = Random.Range(2, 5);
        if (spawnProbability < 0.8f) // Adjust this probability as needed (0.5 means 50% chance)
        {
            // Choose a random point to spawn the first obstacle
           
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            // Spawn the first obstacle at the position
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

            // Add the newly spawned obstacle to the list
            spawnedObstacles.Add(newObstacle);

        }

        // Generate a random number to determine if we should spawn a second obstacle
         spawnProbability = Random.Range(0f, 1f);

        if (spawnProbability < 0.3f) // Adjust this probability as needed (0.5 means 50% chance)
        {
            // Choose a different random point to spawn the second obstacle
            int obstacleSpawnIndex1 = Random.Range(2, 5);
            if(obstacleSpawnIndex != obstacleSpawnIndex1)
            {
                Transform spawnPoint1 = transform.GetChild(obstacleSpawnIndex1).transform;

                // Spawn the second obstacle at the position

                GameObject newObstacle = Instantiate(obstaclePrefab, spawnPoint1.position, Quaternion.identity, transform);

                // Add the newly spawned obstacle to the list
                spawnedObstacles.Add(newObstacle);
            }
           
        }
    }

    public void SpawnCoins()
    {
        Vector3 v1 = GetRandomPointInCollider();
        Vector3 v2 = GetRandomPointInCollider();
        Vector3 v3 = GetRandomPointInCollider();


        

            int typeofenergy = Random.Range(2, 5);
            if (typeofenergy == 2)
            {
                
                GameObject temp = Instantiate(RedPrefab, transform);
                temp.transform.position = v1;
            }
            else if (typeofenergy == 3)
            {
                GameObject temp = Instantiate(GreenPrefab, transform);
                temp.transform.position = v1;
            }
            else 
            {
                GameObject temp = Instantiate(BluePrefab, transform);
                temp.transform.position = v1;

            }

        if (AreVectorsNotEqual(v1, v2)){
            int typeofenergy1 = Random.Range(2, 5);
            if (typeofenergy1 == 2)
            {

                GameObject temp = Instantiate(RedPrefab, transform);
                temp.transform.position = v2;
            }
            else if (typeofenergy1 == 3)
            {
                GameObject temp = Instantiate(GreenPrefab, transform);
                temp.transform.position = v2;
            }
            else
            {
                GameObject temp = Instantiate(BluePrefab, transform);
                temp.transform.position = v2;

            }

        }

        if (AreVectorsNotEqual(v1, v3) && AreVectorsNotEqual(v2,v3))
        {
            int typeofenergy1 = Random.Range(2, 5);
            if (typeofenergy1 == 2)
            {

                GameObject temp = Instantiate(RedPrefab, transform);
                temp.transform.position = v3;
            }
            else if (typeofenergy1 == 3)
            {
                GameObject temp = Instantiate(GreenPrefab, transform);
                temp.transform.position = v3;
            }
            else
            {
                GameObject temp = Instantiate(BluePrefab, transform);
                temp.transform.position = v3;

            }

        }

        /*
        float spawnProbability = Random.Range(0f, 1f);

        if (spawnProbability < 0.3f) // Adjust this probability as needed (0.5 means 50% chance)
        {
            // Choose a different random point to spawn the second obstacle
            int place = Random.Range(5,8);

            int typeofenergy2 = Random.Range(2,5);
            Transform spawnPoint = transform.GetChild(place).transform;


            if (typeofenergy2 == 1)
            {
                Instantiate(RedPrefab,spawnPoint.position, Quaternion.identity, transform);
           
            }
            else if (typeofenergy2 == 2)
            {
                Instantiate(GreenPrefab, spawnPoint.position, Quaternion.identity, transform);

            }
            else
            {
                Instantiate(BluePrefab, spawnPoint.position, Quaternion.identity, transform);


            }

        }*/
    } 
    Vector3 GetRandomPointInCollider()
    {
       /* int maxAttempts = 100; // Maximum attempts to find a suitable position

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            int obstacleIndex = Random.Range(2, 5); // Avoid obstacles at ends
            Transform spawnPoint = transform.GetChild(obstacleIndex).transform;

            Vector3 point = spawnPoint.position;
            point.y = 1; // Adjust the y-coordinate as needed

            // Check if there's an obstacle at the chosen point
            Collider[] colliders = Physics.OverlapSphere(point, 0.5f); // Adjust the radius as needed

            if (colliders.Length == 0)
            {
                print("aaaaaa");
                return point;
            }
            
        }*/

        // If we exceed maxAttempts, return a fallback point (you can adjust this)

        int obstacleIndex1 = Random.Range(2, 5);
        return transform.GetChild(obstacleIndex1).transform.position;  // Fallback to middle point

    }
    
    void Update()
    {
        
    }
    bool AreVectorsNotEqual(Vector3 vector1, Vector3 vector2)
    {
        return vector1.x != vector2.x || vector1.y != vector2.y || vector1.z != vector2.z;
    }
}
