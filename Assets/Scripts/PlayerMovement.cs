using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Declaring member variables
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;


    // Function declaration
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        Jump();
    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            
        }

    }


}
