using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D boxcol;
    private Animator anime;
    private float _direction;

    // Game Wake
    private void Awake()
    {
        boxcol = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // If hit is true, return onTriggerEnter (enabling explosion)
        if (hit) return;
        // Creating variable to detect movement speed of projectile
        float moveSpeed = speed * Time.deltaTime * _direction;
        transform.Translate(moveSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Setting state of projectile (hit = enabled)
        hit = true;
        // Enabling box collider to test for collisions
        boxcol.enabled = false;
        // Setting explode animation
        anime.SetTrigger("Explode");
    }

    // Setting direction for projectile
    public void SetDirection(float _direction)
    {
        // Initialising local variable from parameters.
        float direction = _direction;

        // Activating projectile within game
        gameObject.SetActive(true);

        // Setting state of projectile (hit = disabled)
        hit = false;

        // Enabling box collider to test for collisions
        boxcol.enabled = true;


        // Handling projectile direction
        float localScaleX = transform.localScale.x;
        // If projectile is facing the wring way, flip it on x axis
        if (Mathf.Sign(localScaleX) != direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }

    // Deactivating projectile once triggered 
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
