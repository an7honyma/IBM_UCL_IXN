using UnityEngine;

public class ERotation : MonoBehaviour
{
    private float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }
}