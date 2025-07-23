using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public EnemyController enemyController; // Reference to the enemy controller
    private PlayerAttack playerAttack; // Reference to the player attack script

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyController = collision.gameObject.GetComponent<EnemyController>();
            playerAttack.enemyController = enemyController; // Set the enemy controller in PlayerAttack
            print("Enemy detected: " + enemyController.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyController = null; // Clear the reference when the enemy exits the trigger
            playerAttack.enemyController = null; // Clear the reference in PlayerAttack
        }
    }
}
