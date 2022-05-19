using UnityEngine;

public class MonsterEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float damage;
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxcol;
    [SerializeField] private float colliderDistance;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTimer = Mathf.Infinity; // Giving enemy ability to attack straight away

    //References
    private Animator anime;
    private Health playerHealth;

    private EnemyPatrol enemyPatrol;


    private void Awake()
    {
        anime = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>(); // Grabbing component from parent, not object 
    }

    private void Update()
    {
        coolDownTimer += Time.deltaTime;

        // If Else to attack when player in sight
        if(PlayerInSight())
        {

            // If Else to attack when relevant time has passed
            if (coolDownTimer >= attackCoolDown)
            {
                //Attack
                coolDownTimer = 0;
                anime.SetTrigger("Attack");
            }

            // Enabling / Disabling Patrol when the player is in sight (so that enemy can still attack)
            if(enemyPatrol != null)
            {
                enemyPatrol.enabled = !PlayerInSight();
            }


        }

        
    }

    private bool PlayerInSight()
    {
        // Raycast acts as a 'laser' which can then trigger actions.
        RaycastHit2D hit =
             Physics2D.BoxCast(boxcol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, //Transform.right * range "pushes" the boxcast infront of the enemy. When player enters "range" enemy will attack.
             new Vector3(boxcol.bounds.size.x * range, boxcol.bounds.size.y, boxcol.bounds.size.z), 0, Vector2.left, 0, playerLayer); // Alignment, size, angle, direction, distance, layermask


        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;  // Enemy 'sees' player by checking if collider is hit or not

      
    }


    // Function to visualise sight of enemy in Unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxcol.bounds.size.x * range, boxcol.bounds.size.y, boxcol.bounds.size.z)); // Activate wireframe using box collider parameters
    }


    // Damage the player
    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
