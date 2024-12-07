using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the character
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if Spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed"); // Debug log to confirm input
            // Set the isattacking boolean to true
            animator.SetBool("isattacking", true);
        }
        // Check if the Spacebar is released
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Spacebar released"); // Debug log to confirm input
            // Set the isattacking boolean to false
            animator.SetBool("isattacking", false);
        }
    }
}
