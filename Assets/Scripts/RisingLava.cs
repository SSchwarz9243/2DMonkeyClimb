using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingLava : MonoBehaviour {
    public float riseSpeed = 0.5f; // Adjust the speed of the lava rising
    public GameOverManager gameOverManager; // Reference to the GameOverManager script

    void Update() {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
  //  Debug.Log("Collision detected with: " + other.gameObject.name); // Check if this prints

    if (other.CompareTag("Player")) {
        // Debug.Log("Player touched the lava!");
        gameOverManager.ShowGameOverScreen(); // Ensure this line is active
       // Debug.Log("ShowGameOverScreen() was called from RisingLava");
     }
    }

}


