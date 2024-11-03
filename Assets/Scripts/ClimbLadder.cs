using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour {
    private bool isClimbing = false;
    public float climbSpeed = 3f;
    private Rigidbody2D rb;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (isClimbing) {
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
            rb.gravityScale = 0; // Disable gravity while climbing
        } else {
            rb.gravityScale = 1; // Re-enable gravity when not climbing
        }

        // Jump off the ladder
        if (Input.GetButtonDown("Jump") && isClimbing) {
            isClimbing = false;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(rb.velocity.x, 5f); // Give upward force to jump off
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ladder")) {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ladder")) {
            isClimbing = false;
        }
    }
}
