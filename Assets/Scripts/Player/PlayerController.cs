using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move System")]
    private float dashTimeLeft;
    private float lastDash = -100f;

    private bool isFacingRight = true;
    private bool isRun;
    private bool isGrounded;
    private bool isDashing;
    private bool canJump;
    private bool canMove;
    private bool canFlip;

    private int amountOfJumpsLeft;

    private Rigidbody2D rigid;
    private Animator anim;

    public float MoveInputDirection { get; private set; }
    public float moveSpeed = 10.0f;
    public float jumpForce = 15.0f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float groundCheckRadius;
    public float dashTime;
    public float dashSpeed;
    public float dashCoolDown;

    public int amountOfJump = 1;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    [Header("Combat System")]
    [SerializeField] private bool combatEnabled;
    private bool getInput;

    private float lastInputTime;


    private void Awake()
    {
        canMove = true;
        canFlip = true;
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJump;
    }

    private void Update()
    {
        CheckInput();
        CheckMoveDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckDash();
        CheckCombatInput();
    }

    private void FixedUpdate()
    {
        ApplyMove();
        CheckSurroundings();
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rigid.linearVelocityY <= 0.01f)
        {
            amountOfJumpsLeft = amountOfJump;
        }

        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void CheckMoveDirection()
    {
        if (isFacingRight && MoveInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && MoveInputDirection > 0)
        {
            Flip();
        }

        if (MoveInputDirection != 0)
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
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rigid.linearVelocityY);
    }

    private void CheckInput()
    {
        MoveInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            rigid.linearVelocityY = rigid.linearVelocityY * variableJumpHeightMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                Dash();
                anim.SetTrigger("isDash");
            }
        }
    }

    private void CheckCombatInput() // 공격 입력 체크
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            return;
        }
    }

    private void Dash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
    }

    private void CheckDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                rigid.gravityScale = 0f;
                canMove = false;
                canFlip = false;
                rigid.linearVelocity = new Vector2(dashSpeed * MoveInputDirection, rigid.linearVelocityY);
                dashTimeLeft -= Time.deltaTime;
            }

            if (dashTimeLeft <= 0)
            {
                rigid.gravityScale = 4f;
                isDashing = false;
                canMove = true;
                canFlip = true;
            }
        }

    }

    private void Jump()
    {
        if (canJump)
        {
            rigid.linearVelocityY = jumpForce;
            amountOfJumpsLeft--;
        }
    }

    private void ApplyMove()
    {
        if (canMove)
        {
            rigid.linearVelocityX = moveSpeed * MoveInputDirection;
        }
    }

    private void Flip()
    {
        if (canFlip)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

