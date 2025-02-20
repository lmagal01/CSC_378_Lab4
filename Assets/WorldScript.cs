using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScript : MonoBehaviour
{
    [Header("Game Over Settings")]
    public string playerTag = "Player";
    public bool restartOnCollision = true;
    public bool quitGameOnCollision = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            Debug.Log("Player collided with the boundary!");

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;          // Stop movement
                rb.angularVelocity = 0f;             // Stop rotation
                rb.bodyType = RigidbodyType2D.Static; // Freeze player completely
            }

            if (restartOnCollision)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the scene
            }
            else if (quitGameOnCollision)
            {
                Application.Quit(); // Quit the application
            }
        }
    }
}
