using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    private Rigidbody2D rb;
    private const float defaultGravityScale = 8f; // Permanent gravity scale value

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 8; // Force the gravity scale to 8 at the start of the game
        Debug.Log("Gravity scale set to: " + rb.gravityScale); // Log for verification
    }


    void Update() {
        // Prevent movement if the game is over
        if (GameOverManager.isGameOver) {
            rb.velocity = Vector2.zero; // Stop the player from moving
            return; // Exit the Update function to prevent further movement
            Debug.Log("Current Gravity Scale: " + rb.gravityScale);
        }

        PlayerMove();
        playerRaycast();
    }

    void PlayerMove() {
        moveX = Input.GetAxis("Horizontal");

        // Jumping logic
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

        // Check for facing direction and flip if needed
        if (moveX > 0 && !facingRight) {
            FlipPlayer();
        } else if (moveX < 0 && facingRight) {
            FlipPlayer();
        }

        // Move the player
        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
    }

    void Jump() {
        rb.AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "grass") {
            isGrounded = true;
        }
    }

    void playerRaycast() {
        // Ray UP
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "item") {
            Destroy(rayUp.collider.gameObject);
        }

        // Ray Down
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy") {
            rb.AddForce(Vector2.up * 50); // Adjust this value as needed
            Rigidbody2D enemyRb = rayDown.collider.gameObject.GetComponent<Rigidbody2D>();
            enemyRb.AddForce(Vector2.right * 200);
            enemyRb.gravityScale = 20;
            enemyRb.freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }

        if (rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy") {
            isGrounded = true;
        }
    }
}
