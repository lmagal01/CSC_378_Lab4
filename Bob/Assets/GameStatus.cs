using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
   
    public Transform playerTransform;

    public float loseGameYPos = -20f;

    public float winGameXPos = 158f;

    


    
    public bool restartOnReach = true;

    private void Start()
    {
        // Auto-find player if not assigned
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                playerTransform = player.transform;
            }
           
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Check if player falls below Y-Pos
            if (playerTransform.position.y <= loseGameYPos)
            {
                HandleGameEnd();
            }

            // Check if player reaches target position
            if (playerTransform.position.x >= winGameXPos)
            {
                HandleGameEnd();
            }
        }
    }

    private void HandleGameEnd()
    {
        if (restartOnReach)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart game
        }
    }
}
