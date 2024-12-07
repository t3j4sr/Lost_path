using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 5f;  // Movement speed along X-axis

    void Start()
    {
        // Get the Animator and SpriteRenderer components attached to the character
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Spacebar input to trigger attack animation (same as previous)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed - Attack");
            animator.SetBool("isattacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Spacebar released - Stop Attack");
            animator.SetBool("isattacking", false);
        }

        // Right arrow key for running forward (normal running animation)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right arrow pressed - Start Running");
            animator.SetBool("isrunning", true);
            spriteRenderer.flipX = false; // Ensure the character faces right
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);  // Move character right
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("Right arrow released - Stop Running");
            animator.SetBool("isrunning", false);
        }

        // Left arrow key for running backward (flip the character)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left arrow pressed - Run Backwards");
            animator.SetBool("isrunning", true);  // Keep running animation active
            spriteRenderer.flipX = true; // Flip the character to face left
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);  // Move character left
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log("Left arrow released - Stop Running");
            animator.SetBool("isrunning", false); // Stop running animation
        }
    }
}
