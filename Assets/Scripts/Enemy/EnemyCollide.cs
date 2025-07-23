using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    private Collider2D collider;
    [Header("Enemy Settings")]
    public float knockbackForce = 5f; // Set the knockback force

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            GameObject player = collision.gameObject;
            Animator playerAnim = player.GetComponent<Animator>();
            PlayerController playerController = player.GetComponent<PlayerController>();

            playerController.playerHP -= 1; // Decrease player health

            

            if (playerController.playerHP <= 0)
            {
                // add random knockback force to the player
                Vector2 knockbackDirection = (player.transform.position - transform.position).normalized; // Calculate knockback direction
                player.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse); // Apply knockback force

                playerAnim.SetTrigger("die"); // Trigger player death animation
                playerController.enabled = false; // Disable player controls
                collider.enabled = false; // Disable enemy collider to prevent further collisions
            }
            else
            {
                playerAnim.SetTrigger("hurt"); // Trigger player hit animation
            }

        }
    }
}
