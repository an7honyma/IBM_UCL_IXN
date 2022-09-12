using UnityEngine;

public class RotateOnZ : MonoBehaviour
{
    private float rotationSpeed = 50f;

    void Update()
    {
        // Rotate around local Z axis:
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime, Space.Self);
    }
}