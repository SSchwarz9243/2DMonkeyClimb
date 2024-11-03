using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the tag "Player"
        {
            Debug.Log("Player reached the finish line!");
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if there is a next scene in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // No more levels, return to the main menu
            Debug.Log("No more levels available. Returning to main menu.");
            SceneManager.LoadScene("MainMenu"); // Load the main menu scene
        }
    }
}
