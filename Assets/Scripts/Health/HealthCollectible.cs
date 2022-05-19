
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue = 0.25f;

    // Declaring on trigger method to execute when two colliders intersect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            // Deactivating collectible so that it cannot be picked up multiple times
            gameObject.SetActive(false);
        }
        
    }

   

}

