using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{

    [SerializeField] private float damage;
   

    // Method detecting for player collisions 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Grabbing health component to borrow TakeDamage method to execute enemy damage
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
