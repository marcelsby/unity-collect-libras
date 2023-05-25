using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private Transform leftWaypoint;
    [SerializeField] private Transform rightWaypoint;

    private float leftBoundary;
    private float rightBoundary;

    void Start()
    {
        leftBoundary = leftWaypoint.position.x;
        rightBoundary = rightWaypoint.position.x;
    }

    void FixedUpdate()
    {
        float timeBasedOscillationRate = Time.time * speed;
        float movedX = Mathf.PingPong(timeBasedOscillationRate, rightBoundary - leftBoundary) + leftBoundary;

        transform.position = new Vector3(movedX, transform.position.y, transform.position.z);
    }
}

