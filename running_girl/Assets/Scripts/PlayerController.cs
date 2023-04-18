using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb ;
    public float gravityModifier = 2;
    public float jumpForce = 10 ;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem playerEffect;
    public ParticleSystem dirtEffect;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtEffect.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtEffect.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerEffect.Play();
            dirtEffect.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
