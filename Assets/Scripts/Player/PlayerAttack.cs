using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Creating References & Initialising Variables
    [SerializeField] private float attackCoolDown;
    

    private float coolDownTimer = Mathf.Infinity; // Initialising the cool down timer to infinity- so that upon Awake() the player can shoot.
    // Grabbing animator
    private Animator anime;

    // Grabbing class: Player Movement from script. 
    private PlayerMovement playerMovement;

    // Startup Method
    private void Awake()
    {
        anime = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        coolDownTimer += Time.deltaTime;
    }

    // Update Method
    private void Update()
    {
        // If user presses left shift button, player will hit.
        if(Input.GetKey(KeyCode.LeftShift) && coolDownTimer > attackCoolDown && playerMovement.Attack())
        {
            AttackHit();
        }



        //coolDownTimer += Time.deltaTime;
    }

    // Class Methods
    private void AttackHit()
    {
        // Setting hit animation
        anime.SetTrigger("Attack");

       // coolDownTimer = 0;
    }


    // Searching for Player + Enemy collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(0.5f);
        }
    }

}
