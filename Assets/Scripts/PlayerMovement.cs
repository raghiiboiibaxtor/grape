using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Declaring member variables
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    protected Animator anime;
    



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
        Jump();
        Run(anime);
    }

    // Function Declarations

    void Walk()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
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

    bool Run(Animator anime)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        anime.SetBool("Run", horizontalInput != 0);
        return true;
    }






}
