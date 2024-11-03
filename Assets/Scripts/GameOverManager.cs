using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public GameObject gameOverScreen;
    public static bool isGameOver = false; // Add this variable to track game over state

    public void ShowGameOverScreen() {
        gameOverScreen.SetActive(true);
        isGameOver = true; // Set the game over state to true
        Time.timeScale = 0; // Pause the game
      //  Debug.Log("Game Over Screen should be visible now.");
    }

    public void TryAgain() {
        Time.timeScale = 1;
        isGameOver = false; // Reset the game over state
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu() {
        Time.timeScale = 1;
        isGameOver = false; // Reset the game over state
        SceneManager.LoadScene("MainMenu");
    }
}



