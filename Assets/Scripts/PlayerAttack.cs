using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Creating References & Initialising Variables
    [SerializeField] private float attackCoolDown;
    private float coolDownTimer = Mathf.Infinity; // Initialising the cool down timer to infinity- so that upon Awake() the player can shoot.
    [SerializeField] private Transform projectilePoint;
    [SerializeField] private GameObject[] projectiles;
    private Animator anime;

    // Grabbing class: Player Movement from script. 
    private PlayerMovement playerMovement;

    // Startup Method
    private void Awake()
    {
        anime = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update Method
    private void Update()
    {
        // If user presses left shift button, player will hit.
        if(Input.GetKey(KeyCode.LeftShift) && coolDownTimer > attackCoolDown && playerMovement.Attack())
        {
            AttackHit();
        }
        // If user presses Key 'Z' button, player will throw.
        if (Input.GetKey(KeyCode.Z) && coolDownTimer > attackCoolDown && playerMovement.Throw())
        {
            AttackThrow();
        }


        //coolDownTimer += Time.deltaTime;
    }

    // Class Methods
    private void AttackHit()
    {
        // Setting hit animation
        anime.SetTrigger("Attack");
        //coolDownTimer = 0;
    }

    private void AttackThrow()
    {
        // Setting throw animation
        anime.SetTrigger("Throw");
        //coolDownTimer = 0;

        // Object pool projectile activation
        //Resetting projectile position
        projectiles[0].transform.position = projectilePoint.position;
        projectiles[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

}