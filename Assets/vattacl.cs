using UnityEngine;

public class VillainBehavior : MonoBehaviour
{
    public Transform hero; // Reference to the hero character
    public float moveSpeed = 2f; // Speed at which the villain moves
    public float attackRange = 2f; // Range within which the villain attacks
    public float attackDelay = 2f; // Time to wait before attacking after reaching range

    private Animator animator; // Reference to the Animator component
    private bool isAttacking = false; // Flag to check if villain is attacking
    private bool isWithinRange = false; // Flag to manage attack delay timer
    private float attackTimer = 0f; // Timer for attack delay

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        if (hero == null)
        {
            Debug.LogError("Hero not assigned to VillainBehavior script!");
        }
    }

    void Update()
    {
        if (hero == null) return;

        // Calculate distance to the hero
        float distanceToHero = Vector3.Distance(transform.position, hero.position);

        if (distanceToHero > attackRange)
        {
            // Move towards the hero
            isAttacking = false;
            isWithinRange = false;
            attackTimer = 0f; // Reset the attack timer
            animator.SetBool("isAttacking", false); // Stop attack animation
            animator.SetBool("isRunning", true); // Play running animation
            MoveTowardsHero();
        }
        else
        {
            // Start attack sequence
            if (!isWithinRange)
            {
                // Wait for the attack delay
                isWithinRange = true;
                animator.SetBool("isRunning", false); // Stop running animation
                attackTimer = attackDelay; // Start the timer
            }

            // Countdown and attack
            if (isWithinRange && attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else if (!isAttacking)
            {
                isAttacking = true;
                animator.SetBool("isAttacking", true); // Trigger attack animation
            }
        }
    }

    void MoveTowardsHero()
    {
        // Move towards the hero's position
        Vector3 direction = (hero.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Face the hero
        transform.LookAt(new Vector3(hero.position.x, transform.position.y, hero.position.z));
    }
}
