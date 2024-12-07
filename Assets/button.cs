using UnityEngine;
using UnityEngine.UI;

public class TransparentRoundedButton : MonoBehaviour
{
    [Range(0, 1)]
    public float transparency = 0.2f; // Set transparency for the button's background
    public float borderWidth = 5f; // Width of the bold edges for the button

    void Start()
    {
        // Get the Button component attached to this GameObject
        Button targetButton = GetComponent<Button>();

        if (targetButton != null)
        {
            // Get the Image component of the button (background)
            Image buttonImage = targetButton.GetComponent<Image>();

            if (buttonImage != null)
            {
                // Set the alpha value of the button's background to make it transparent
                Color buttonColor = buttonImage.color;
                buttonColor.a = transparency; // Apply transparency (0.2 for 20% opacity)
                buttonImage.color = buttonColor;

                // Set the button image type to Sliced for rounded corners
                buttonImage.type = Image.Type.Sliced; 
                buttonImage.fillCenter = true; // Ensure the image stretches to the button size

                // Optional: You can use a rounded sprite for better results if needed
                // Make sure the sprite you're using has rounded corners and is set to Sliced mode.
                // For this, set a rounded sprite in the Image component.
            }
            else
            {
                Debug.LogError("No Image component found on the button!");
            }

            // Optional: Add a border effect around the button
            if (buttonImage.GetComponent<Outline>() == null)
            {
                Outline outline = targetButton.gameObject.AddComponent<Outline>();
                outline.effectDistance = new Vector2(borderWidth, borderWidth); // Set border width
                outline.effectColor = Color.black; // Set border color to black (or any color you prefer)
            }

            // Adjust the text (make it bold and set the desired color)
            Text buttonText = targetButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                // Make the text bold
                buttonText.fontStyle = FontStyle.Bold;

                // Set the color of the text to dark or any color you want
                buttonText.color = Color.black; // Change text color to black
            }
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject!");
        }
    }
}
