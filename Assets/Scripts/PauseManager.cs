using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the pause menu panel
    private bool isPaused = false; // Track if the game is currently paused

    void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Show the pause menu
        Time.timeScale = 0; // Stop the game time
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1; // Resume the game time
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; // Ensure time scale is reset before changing scenes
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
