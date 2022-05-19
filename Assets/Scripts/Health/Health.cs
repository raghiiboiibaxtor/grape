using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    // Allowing for public access to get, but private access to set
    public float currentHealth {get; private set;}
    private Animator anime;
    // Ensuring the die animation does not loop by triggering bool dead.
    private bool dead;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        anime = GetComponent<Animator>();
    }

    

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anime.SetTrigger("Hurt");
        }
        else
        {
            if (!dead)
            {
                anime.SetTrigger("Die");
                // Disabling player movement once dead
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }

        }


    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }

}
