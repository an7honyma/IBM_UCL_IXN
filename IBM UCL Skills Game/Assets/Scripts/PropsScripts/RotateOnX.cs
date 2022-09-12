using UnityEngine;

public class RotateOnX : MonoBehaviour
{
    private float rotationSpeed = 50f;

    void Update()
    {
        // Rotate around local X axis:
        transform.Rotate(new Vector3(rotationSpeed, 0, 0) * Time.deltaTime, Space.Self);
    }
}
