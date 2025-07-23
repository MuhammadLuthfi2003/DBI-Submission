using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if player presses E
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("attack"); // Trigger the attack animation
    }
}
