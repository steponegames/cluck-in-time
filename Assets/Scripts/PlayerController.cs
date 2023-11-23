using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerSprite; 

    public float moveSpeed = 5f; // maximum horizontal speed
    public float moveAcceleration = 10f; // how quickly the player accelerates/decelerates
    public float jumpSpeed = 10f; // initial jump speed
    public float gravityScale = 2.5f; // how strong the gravity is
    public float friction = 0.0f; // friction coefficient
    public bool isGrounded = false; // is the player on the ground?

    public Collider2D groundCheckCollider; // reference to the ground check collider

    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // check if the player is on the ground
        isGrounded = groundCheckCollider.IsTouchingLayers();

        // get input from player
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // calculate horizontal movement
        float horizontalVelocity = rb.velocity.x;
        float targetVelocity = horizontalInput * moveSpeed;
        horizontalVelocity = Mathf.MoveTowards(horizontalVelocity, targetVelocity, moveAcceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

        if(isGrounded && horizontalVelocity < 0 && (horizontalInput > 0 || horizontalInput < 0))
        {
            Debug.Log("amogus");
        }

        if(horizontalInput > 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (horizontalInput < 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

        // calculate jump
        if (isGrounded && verticalInput > 0)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        else if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        } else if (isJumping && rb.velocity.y <= 0)
        {
            isJumping = false;
        }

        // apply gravity
        rb.AddForce(new Vector2(0, -gravityScale * rb.mass));
    }
}
