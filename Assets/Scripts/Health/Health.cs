using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")] // Unity Heading "Health"
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set; } // Allowing for public access to get, but private access to set
    private Animator anime;
    private bool dead; // Bool dead will ensure player dies.

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numFlashes;
    private SpriteRenderer sprite;



    // Start is called before the first frame update
    void Awake()
    {
        //Grabbing components
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = startingHealth; // Instantiating variables
    }

    

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {

            anime.SetTrigger("Hurt"); // Triggering "Hurt" animation
            StartCoroutine(Invincibility());  // Setting iFrames for invincibility - using StartCorotine() to instantiate IEnumerator function

        }
        else
        {

            if (!dead)
            {
                sprite.color = new Color(1, 0.004716992f, 0.3888731f, 0.8f);
                anime.SetTrigger("Die"); // Triggering "Die" animation

                // Player
                if (GetComponent<PlayerMovement>() != null) // If to avoid exceptions from executions
                {
                    GetComponent<PlayerMovement>().enabled = false; // Disabling player movement once dead
                }
                 

                // Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }

                if(GetComponent<MonsterEnemy>() != null)
                {
                    GetComponent<MonsterEnemy>().enabled = false;
                } 
                

                dead = true;
            }

        }


    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, 1);

    }

    // IEnumerator() Declared to yield returns
    private IEnumerator Invincibility()
    {

        // Ignoring the collision of layer Player & Enemy (truw = colliosions ignored
        Physics2D.IgnoreLayerCollision(7, 8, true);

        // For loop to initialise invincibility flashing
        for(int i = 0; i < numFlashes; i++)
        {
            // Changing sprite colour to deep red / magenta
            sprite.color = new Color(1, 0.004716992f, 0.3888731f, 0.8f);
            // Slowing function execution down using yield return
            yield return new WaitForSeconds(iFramesDuration / (numFlashes * 2)); // iFramesDuration / numFlashes * 2 (red & white) avoids slow flashing
            // Changing sprite colour back to white
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(iFramesDuration / (numFlashes * 2));
        }
        
            // Disabling invincibility
        Physics2D.IgnoreLayerCollision(7, 8, false);

    }
}
