using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftSpeed = 20;
    private PlayerController playerControllerScript;
    private Transform playerCameraAnimation;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerCameraAnimation = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver && playerCameraAnimation.position.x >=0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftSpeed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
