using UnityEngine;

/*
REFERENCES:
Rotating a Character in the Direction of Movement (Unity Tutorial) (Youtube/Ketra Games):
https://www.youtube.com/watch?v=BJzYGsMcy8Q
How to use Animation Transitions (Unity Tutorial) (Youtube/Ketra Games):
https://www.youtube.com/watch?v=2_Hn5ZsUIXM

*/

public class PlayerMovement : MonoBehaviour
{
    // Player movement speed:
    private float speed = 3f;
    // Player pivot speed:
    private float lookSpeed = 200f;

    // Player animator component:
    private Animator animator;

    void Start()
    {
        // Get access to animator component on game object:
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // User movement input:
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementVector = new Vector3(horizontalInput, 0, verticalInput);
        // Normalise for all vector directions:
        movementVector.Normalize();
        // Translate avatar game object around world scene:
        transform.Translate(movementVector * speed * Time.deltaTime, Space.World);

        // If player is moving:
        if (movementVector != Vector3.zero)
        {
            // Animator Boolean condition:
            animator.SetBool("isMoving", true);
            // Rotate avatar to look in direction of movement:
            Quaternion toRotation = Quaternion.LookRotation(movementVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, lookSpeed);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
