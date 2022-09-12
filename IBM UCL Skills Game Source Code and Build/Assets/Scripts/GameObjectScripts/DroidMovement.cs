using UnityEngine;

/*
REFERENCES:
How to Make a Tower Defense Game (E02 Enemy AI) - Unity Tutorial (Youtube/Brackeys):
https://www.youtube.com/watch?v=aFxucZQ_5E4

*/

public class DroidMovement : MonoBehaviour
{
    // Droid movement speed:
    private float speed = 2f;
    // Droid pivot speed:
    private float lookSpeed = 5f;

    // Waypoint collection parent object:
    public GameObject waypointsCollection;
    // Array of child object positions:
    private Transform[] waypoints;
    // Current waypoint:
    private int waypointIndex = 0;
    private Transform target;

    void Awake()
    {
        // Find waypoints array assigned to droid:
        waypoints = new Transform[waypointsCollection.transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            // Index in order of child object hierarchy:
            waypoints[i] = waypointsCollection.transform.GetChild(i);
        }
    }

    void Start()
    {
        // Assign first waypoint target:
        target = waypoints[0];
    }

    void FixedUpdate()
    {
        Vector3 direction = target.position - transform.position;
        // Move towards waypoint target:
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // If droid movement reaches waypoint target:
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            if (waypointIndex >= waypoints.Length - 1)
            {
                // Set target index to first waypoint to complete route cycle:
                waypointIndex = 0;
            }
            else
            {
                // Set target index to next waypoint in cycle:
                waypointIndex ++;   
            }
            target = waypoints[waypointIndex];
        }

        // Rotate towards target waypoint:
        if (target.transform.position - transform.position != Vector3.zero)
        {
            Vector3 dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        }
    }
}
