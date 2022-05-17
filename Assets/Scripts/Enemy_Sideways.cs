using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    private bool movingLeft;
    private float leftEgde;
    private float rightEdge;


    private void Awake()
    {
        leftEgde = transform.position.x - movementDistance;
        leftEgde = transform.position.x + movementDistance;
    }

    private void Update()
    {
        // Nested IfElse block to check whether or not the Rock obj is moving left or right.
        // Different directions will trigger different results.
        if (movingLeft)
        {
            if (transform.position.x > leftEgde)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;

            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;

            }
        }

    }

    // Method detecting for player collisions 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Grabbing health component to borrow TakeDamage method to execute enemy damage
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
