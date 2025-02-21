using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public KeyCode shootButton = KeyCode.X;
    public KeyCode spinButton = KeyCode.S;
    
    public Transform firePoint; // Reference to the fire point Transform
    public GameObject bulletPrefab; // Reference to your bullet prefab
    private Animator animator;
    private bool isSpinning = false;
    private bool isFacingRight = true; // Track player direction


    void Start()
    {
        // Search for the Animator in the entire hierarchy
        animator = GetComponentInParent<Animator>() ?? GetComponentInChildren<Animator>();

        if (!animator)
        {
            Debug.LogError("Animator not found! Please ensure an Animator component is attached to this or a parent/child GameObject.");
            enabled = false;
        }
    }

    void Update()
    {
        // Trigger shooting animation
        //if (Input.GetKeyDown(shootButton))
        //{
            // animator.SetTrigger("Shoot");
         //   animator.Play(shootAnimation.name);
            // Add shooting logic here (e.g., spawn bullet, play sound)
       // }

        // Start spinning when spin button is pressed
        if (Input.GetKey(spinButton) && !isSpinning)
        {
                animator.CrossFade("Spin",0,0);
                animator.speed = 3.0f;
                isSpinning = true;
        }

        // Stop spinning when spin button is released
        if (Input.GetKeyUp(spinButton) && isSpinning)
        {
            animator.CrossFade("Idle",0,0);
             animator.speed = 1.0f;
            isSpinning = false;
            
        }
    }

}
