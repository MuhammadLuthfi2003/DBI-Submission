using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    // components
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    [Tooltip("Player Settings")]
    public float moveSpeed = 5f; // Speed of the player movement
    public int playerHP = 3; // Player health points

    [HideInInspector] public bool isFacingLeft = false; // Check if the player is facing left

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) // check if the player is on the ground
        {
            anim.SetBool("isGrounded", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Move(-1);
            spriteRenderer.flipX = true; // Flip the sprite to face left
            isFacingLeft = true; // Set facing left state
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Move(1);
            spriteRenderer.flipX = false; // Flip the sprite to face right
            isFacingLeft = false; // Set facing right state
        }
        else
        {
            Move(0);
        }
    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) // Check if the player is on the ground
        {
            rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
            anim.SetTrigger("jump"); // Trigger jump animation
            anim.SetBool("isGrounded", false); // Set grounded state to false
        }
    }

    void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y); // Move left or right
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x)); // Set speed for animation
    }
}
