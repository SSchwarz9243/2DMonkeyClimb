using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to start the game
    public void StartGame()
    {
        // Replace "GameScene" with the name of your actual game scene
        SceneManager.LoadScene("Main");
    }

    // Function to exit the game
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
