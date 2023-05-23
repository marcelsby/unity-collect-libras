using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 14.0f;
    [SerializeField] private float moveSpeed  = 7.0f;

    private enum MovementState { Idle, Running, Jumping, Falling }

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState movState;

        if (dirX > 0f)
        {
            movState = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            movState = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            movState = MovementState.Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            movState = MovementState.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            movState = MovementState.Falling;
        }
        else if (rb.velocity.y == 0)
        {
            movState = MovementState.Idle;
        }

        anim.SetInteger("state", ((int)movState));
    }
}
