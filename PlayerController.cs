using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator playerAnimation;
    private AudioSource jumpOrCrashAudio;
    private int jumpCount = 0;

    public ParticleSystem explosionParticle;
    public ParticleSystem runningParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float forcePower = 700;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        jumpOrCrashAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        StartRunning();

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRigidBody.AddForce(Vector3.up * forcePower , ForceMode.Impulse); 
            playerAnimation.SetTrigger("Jump_trig");
            runningParticle.Stop();
            jumpOrCrashAudio.PlayOneShot(jumpSound, 1.0f);
            jumpCount++;

            if (jumpCount >= 2)
            {
                isOnGround = false;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0;
            runningParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            runningParticle.Stop();
            jumpOrCrashAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over!");
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            
        }
        
    }

    void StartRunning()
    {
        if (gameObject.transform.position.x < 0)
        {
            transform.Translate(new Vector3(0,0,1) * Time.deltaTime * 15);
        }

    }
}
