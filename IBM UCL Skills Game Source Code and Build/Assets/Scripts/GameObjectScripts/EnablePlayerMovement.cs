using UnityEngine;

public class EnablePlayerMovement : MonoBehaviour
{
    public GameObject player;

    public void EnableMovement()
    {
        // Find player avatar game object and enable its movement script component:
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}