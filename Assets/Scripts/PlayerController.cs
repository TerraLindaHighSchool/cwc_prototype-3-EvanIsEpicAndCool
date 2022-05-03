using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Simple player controller
/// 
/// -Evan Egan
/// </summary>
public class PlayerController : MonoBehaviour
{
    //Declares the rigidbody as a call-able class
    private Rigidbody playerRb;
    
    //Public variables to change the Velocity / Force of the jump
    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    private float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        //calls the Rigidbody component and calls the Gravity modifier.
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the spacebar is down every frame
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
