using UnityEngine;

public class RotateOnY : MonoBehaviour
{
    private float rotationSpeed = 50f;

    void Update()
    {
        // Rotate around local Y axis:
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime, Space.Self);
    }
}