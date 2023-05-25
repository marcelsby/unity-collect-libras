using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private Transform leftWaypoint;
    [SerializeField] private Transform rightWaypoint;

    private Rigidbody2D rb;
    private float leftBoundary;
    private float rightBoundary;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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

