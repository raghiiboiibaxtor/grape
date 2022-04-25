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



        CharacterFlip();
        Jump();
    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);

        }

    }

    void CharacterFlip()
    {
        //Flip Character when turning
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
