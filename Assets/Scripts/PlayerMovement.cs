using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    // Declaring member variables
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    protected Animator anime;
    protected bool grounded = false;
    



    // Game Play Functions Declaration (Awake = Initialise Game, Update = Run Code per Frame)
    private void Awake()
    {
        // Grab game object references for private variables: Rigidbody & Animator
        body = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

    }

    private void Update()
    {
        
        Walk();
        CharacterFlip();
        Jump(anime);
        Run(anime);
    }

    // Function Declarations

    private void Walk()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
    }

    private void Jump(Animator anime)
    {
        anime.SetBool("Grounded", grounded);
        anime.SetTrigger("Jump");
        if (Input.GetKey(KeyCode.Space) && grounded) 
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            grounded = false;
        }
        
    }

    private void CharacterFlip()
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

    private bool Run(Animator anime)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        anime.SetBool("Run", horizontalInput != 0);
        return true;
    }



    // Detecting collisions between 2d objs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
