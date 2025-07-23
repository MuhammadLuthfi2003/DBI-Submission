using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;

    [Header("Attack Collider Settings")]
    public Collider2D leftCollider;
    public Collider2D rightCollider;

    public EnemyController enemyController; // Reference to the enemy, if detected

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isFacingLeft)
        {
            leftCollider.enabled = true;  // Enable left attack collider
            rightCollider.enabled = false; // Disable right attack collider
        }
        else
        {
            leftCollider.enabled = false; // Disable left attack collider
            rightCollider.enabled = true;  // Enable right attack collider
        }

        // check if player presses E
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("attack"); // Trigger the attack animation

        if (enemyController != null)
        {
            enemyController.health -= 1; // Decrease enemy health
        }
    }
}
