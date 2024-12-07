using UnityEngine;

public class CharacterJumping : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float jumpForce = 10f;  // How high the character jumps
    public float fallSpeed = 2f;   // Speed at which the character falls
    private bool isJumping = false;
    private bool isFalling = false;

    private float groundY;  // Y position of the ground (starting position)

    void Start()
    {
        // Get the Animator and SpriteRenderer components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Set the initial groundY (character's starting position)
        groundY = transform.position.y;
    }

    void Update()
    {
        // Only handle movement if the character isn't already in the air (jumping or falling)
        if (!isJumping && !isFalling)
        {
            // Check for Up Arrow key to start jump
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Up Arrow pressed - Jump");
                isJumping = true;
                animator.SetBool("isjumping", true);  // Trigger jumping animation
                // Move the character up
                transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
            }
        }

        // Check if the character is still jumping, and simulate falling
        if (isJumping)
        {
            // Move the character upwards until a certain height
            if (transform.position.y < groundY + 5f)  // Adjust this value as needed for max jump height
            {
                transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
            }
            else
            {
                // Once it reaches max height, start falling
                isJumping = false;
                isFalling = true;
            }
        }

        // Falling logic: the character moves down
        if (isFalling)
        {
            if (transform.position.y > groundY)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);  // Fall down to the ground
            }
            else
            {
                // When the character reaches the ground, stop falling and reset
                transform.position = new Vector3(transform.position.x, groundY, transform.position.z);  // Correct position
                isFalling = false;
                animator.SetBool("isjumping", false);  // Stop jumping animation
            }
        }
    }
}
