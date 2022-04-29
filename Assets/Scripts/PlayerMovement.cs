using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Allowing Unity to access private members.
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    // Creating references.
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;


    // Startup Method
    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    // Update Method (Runs continuously during gameplay)
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", Grounded());

        //Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (WallRun() && !Grounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 8;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }


    // Class Methods
    private void Jump()
    {
        // IfElse block to determine behaviour if on the ground or on the wall.
        if (Grounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
        else if (WallRun() && !Grounded())
        {
            // IfElse to determine the velocity between actions whilst wall jumping.
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0); //-Math allows for pushing character away from the wall.
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 5);

            wallJumpCooldown = 0;
        }
    }

    private bool Grounded()
    {
        // Assigning RayCastHit variable with BoxCast
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        // Will return false if != null
        return raycastHit.collider != null;
        
    }
    private bool WallRun()
    {
        // Changing the direction of box cast ray.
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool Attack()
    {

        // Retuirning conditions: Player can only throw if not moving, grounded and not on a wall.
        return horizontalInput == 0 && Grounded() && !WallRun();
    }
}





















/*using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    // Declaring member variables
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    protected Animator anime;
    protected bool grounded = true;




    // Game Play Functions Declaration (Awake = Initialise Game, Update = Run Code per Frame)
    private void Awake()
    {
        // Grab game object references for private variables: Rigidbody & Animator
        body = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

    }

    private void Update()
    {
        // Accessing Character Methods
        Run(anime);
        CharacterFlip();


        // If Else Block detecting for Jump (Space key) pressed or remaining grounded.
        if (Input.GetKey(KeyCode.Space) && grounded)
        {

            Jump(); //anime, grounded
            anime.SetTrigger("Jump");


        }
        else
        {
            anime.SetBool("Grounded", grounded);

        }


    }

    // Function Declarations

    // Jump Method
    private bool Jump()
    {

        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        grounded = false;
        anime.SetBool("Grounded", grounded);

        return grounded;
    }


    // Flip Character Left & Right
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

    // Run Method
    private bool Run(Animator anime)
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
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


}*/