using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading
using UnityEngine.UI; // Required for UI components

public class ButtonPlayScript : MonoBehaviour
{
    public Button playButton; // Reference to the button in the Inspector
    public string sceneToLoad = "GameScene"; // Name of the scene to load

    void Start()
    {
        // Ensure the button reference is assigned
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayGame); // Add the PlayGame method as a listener
        }
        else
        {
            Debug.LogError("Play button not assigned in the Inspector!");
        }
    }

    void PlayGame()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Play button clicked. Loading scene: " + sceneToLoad);
    }
}
