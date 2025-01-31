using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveInputDirection;

    private bool isFacingRight = true;
    private bool isRun;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool canJump;

    private Rigidbody2D rigid;
    private Animator anim;

    
    public float moveSpeed = 10.0f;
    public float jumpForce = 15.0f;
    public float groundCheckRadius;

    public Transform groundCheck;

    public LayerMask whatIsGround;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
        CheckMoveDirection();
        UpdateAnimations();
        CheckIfCanJump();
    }

    private void FixedUpdate()
    {
        ApplyMove();
        CheckSurroundings();
    }

    private void CheckIfCanJump()
    {
        if(isGrounded && rigid.linearVelocityY <= 0)
        {
            canJump = true;
        }
        else
        {
            canJump= false;
        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void CheckMoveDirection()
    {
        if(isFacingRight && moveInputDirection < 0) 
        {
            Flip();
        }
        else if(!isFacingRight && moveInputDirection > 0)
        {
            Flip();
        }

        if(rigid.linearVelocityX != 0)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isRun", isRun);
    }

    private void CheckInput()
    {
        moveInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            rigid.linearVelocityY = jumpForce;
        }
    }

    private void ApplyMove()
    {
        rigid.linearVelocityX = moveSpeed * moveInputDirection;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}

