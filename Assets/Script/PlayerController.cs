using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int IsJumpingHash = Animator.StringToHash("isJumping");

    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private bool jumpRequested;
    private Rigidbody2D player;

    public Animator animator;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool facingRight = true;

    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read input every frame so no key press is missed; physics is applied in FixedUpdate.
        direction = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpRequested = true;

        animator.SetFloat(SpeedHash, Mathf.Abs(direction));

        if ((direction > 0f && !facingRight) || (direction < 0f && facingRight))
            Flip();
    }

    private void FixedUpdate()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        Vector2 velocity = player.velocity;
        velocity.x = direction * speed;

        if (jumpRequested && isTouchingGround)
        {
            velocity.y = jumpSpeed;
            animator.SetBool(IsJumpingHash, true);
        }
        jumpRequested = false;

        player.velocity = velocity;
    }

    public void OnLanding()
    {
        animator.SetBool(IsJumpingHash, false);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
