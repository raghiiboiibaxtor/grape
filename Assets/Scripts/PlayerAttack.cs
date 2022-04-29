using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Creating References & Initialising Variables
    [SerializeField] private float throwCoolDown;
    private float coolDownTimer = Mathf.Infinity; // Initialising the cool down timer to infinity- so that upon Awake() the player can shoot.
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
        // If user presses left shift button, player will throw.
        if(Input.GetKey(KeyCode.LeftShift) && coolDownTimer > throwCoolDown && playerMovement.Attack())
        {
            AttackHit();
        }

        coolDownTimer += Time.deltaTime;
    }

    // Class Methods
    private void AttackHit()
    {
        // Setting throw animation
        anime.SetTrigger("Attack");
        coolDownTimer = 0;
    }

}
