using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabObject;
    public Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", startDelay, Random.Range(.5f, 2.5f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        int randomObstacle = Random.Range(0, 4);

        if (!playerControllerScript.isGameOver)
        {
            Instantiate(prefabObject[randomObstacle], spawnPosition, prefabObject[randomObstacle].transform.rotation);
        }
        
    }
}
