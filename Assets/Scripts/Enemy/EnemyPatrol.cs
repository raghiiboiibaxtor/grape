using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale; // Initialising the scale of the enemy
    private bool movingLeft;

    [Header("Idle")]
    [SerializeField] private float idleDuration;
    private float idleTime;

    //References
    [Header("Animator")]
    [SerializeField] private Animator anime;

    private void Awake()
    {
        initScale = enemy.localScale;
        //anime = GetComponent<Animator>();
    }

    // Method to disable moving animation
    private void OnDisable()
    {
        anime.SetBool("Moving", false);
    }

    private void Update()
    {
        // If statement to check if the enemy is moving left
        if(movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1); // Moving left (-1)
            }
            else
            {
                ChangeDirection();
            }
           
        }
       else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1); // Moving right (1)
            }
            else
            {
                ChangeDirection();
            }
           
        }
    }

    private void MoveInDirection(int _direction)
    {
        anime.SetBool("Moving", true);

        // Make enemy face the right direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z); //Mathf.Abs (maintaining absolute value of x axis)


        // Make enemy move in the correct direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }


    private void ChangeDirection()
    {
        idleTime = 0;

        anime.SetBool("Moving", false);

        idleTime += Time.deltaTime;

        if(idleTime > idleDuration)
        {
            movingLeft = !movingLeft; // Negation opperator (true => false etc)
        }

       
    }



}
