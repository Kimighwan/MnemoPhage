using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    //private float dashTimeLeft;
    //private float lastDash = -100f;

    //private bool isRun;
    //private bool isGrounded;
    //private bool canJump;
    //private bool isDashing;
    //private bool canMove;
    //private bool canFlip;

    //private int amountOfJumpsLeft;

    //private Rigidbody2D rigid;
    //private Animator anim;

    public int MoveInputDirection { get; private set; }
    //public float jumpForce = 15.0f;
    //public float groundCheckRadius;
    //public float dashTime;
    //public float dashSpeed;
    //public float dashCoolDown;

    //public int amountOfJump = 1;

    //public Transform groundCheck;

    //public LayerMask whatIsGround;

    private void Awake()
    {
        //canMove = true;
        //canFlip = true;
    }

    private void Start()
    {
        //rigid = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //amountOfJumpsLeft = amountOfJump;
    }

    private void Update()
    {
        CheckInput();

        //CheckMoveDirection();
        //UpdateAnimations();
        //CheckIfCanJump();
        //CheckDash();
    }

    private void FixedUpdate()
    {
        //ApplyMove();
        //CheckSurroundings();
    }

    //private void CheckIfCanJump()
    //{
    //    if(isGrounded && rigid.linearVelocityY <= 0.01f)
    //    {
    //        amountOfJumpsLeft = amountOfJump;
    //    }

    //    if(amountOfJumpsLeft <= 0)
    //    {
    //        canJump = false;
    //    }
    //    else
    //    {
    //        canJump = true;
    //    }
    //}

    //private void CheckSurroundings()
    //{
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    //}

    //private void CheckMoveDirection()
    //{
    //    if(isFacingRight && MoveInputDirection < 0) 
    //    {
    //        Flip();
    //    }
    //    else if(!isFacingRight && MoveInputDirection > 0)
    //    {
    //        Flip();
    //    }

    //    if(MoveInputDirection != 0)
    //    {
    //        isRun = true;
    //    }
    //    else
    //    {
    //        isRun = false;
    //    }
    //}

    //private void UpdateAnimations()
    //{
    //    anim.SetBool("isRun", isRun);
    //    anim.SetBool("isGrounded", isGrounded);
    //    anim.SetFloat("yVelocity", rigid.linearVelocityY);
    //}

    private void CheckInput()
    {
        MoveInputDirection = (int)Input.GetAxisRaw("Horizontal");

        //if (Input.GetButtonDown("Jump"))
        //{
        //    Jump();
        //}

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    if(Time.time >= (lastDash + dashCoolDown))
        //    {
        //        Dash();
        //        anim.SetTrigger("isDash");
        //    }
        //}
    }

    //private void Dash()
    //{
    //    isDashing = true;
    //    dashTimeLeft = dashTime;
    //    lastDash = Time.time;
    //}

    //private void CheckDash()
    //{
    //    if (isDashing)
    //    {
    //        if(dashTimeLeft > 0)
    //        {
    //            canMove = false;
    //            canFlip = false;
    //            rigid.linearVelocity = new Vector2(dashSpeed * MoveInputDirection, rigid.linearVelocityY);
    //            dashTimeLeft -= Time.deltaTime;
    //        }

    //        if(dashTimeLeft <= 0)
    //        {
    //            isDashing = false;
    //            canMove = true;
    //            canFlip = true;
    //        }
    //    }

    //}

    //private void Jump()
    //{
    //    if (canJump)
    //    {
    //        rigid.linearVelocityY = jumpForce;
    //        amountOfJumpsLeft--;
    //    }
    //}

    //private void ApplyMove()
    //{
    //    if (canMove)
    //    {
    //        rigid.linearVelocityX = moveSpeed * MoveInputDirection;
    //    }
    //}

    //private void Flip()
    //{
    //    if (canFlip)
    //    {
    //        isFacingRight = !isFacingRight;
    //        transform.Rotate(0.0f, 180.0f, 0.0f);
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    //}
}
