using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    //private float dashTimeLeft;
    //private float lastDash = -100f;

    //private bool isRun;
    //private bool isDashing;
    //private bool canMove;
    //private bool canFlip;

    public int MoveInputDirection { get; private set; }

    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    
    public float groundCheckRadius;

    //public float dashTime;
    //public float dashSpeed;
    //public float dashCoolDown;

    public Transform groundCheck;



    private float jumpInputStartTime;
    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float dashInputStartTime;


    private void Awake()
    {
        //canMove = true;
        //canFlip = true;
    }

    private void Update()
    {
        CheckInput();
        CheckJumpInputHoldTIme();
        // CheckDashInutHoldTime(); // 8방향 대쉬를 사용한다면 주석 해제

        //CheckMoveDirection();
        //UpdateAnimations();
        //CheckIfCanJump();
        //CheckDash();
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



    private void CheckInput()
    {
        MoveInputDirection = (int)Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpInputStop = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //{
            //    Dash();
            //    anim.SetTrigger("isDash");
            //}

            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            DashInputStop = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;
    
    public void UseDashInput() => DashInput = false;

    private void CheckJumpInputHoldTIme()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInutHoldTime()    // 이거는 8방향 대쉬에서 사용됨
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
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

    //private void Flip()
    //{
    //    if (canFlip)
    //    {
    //        isFacingRight = !isFacingRight;
    //        transform.Rotate(0.0f, 180.0f, 0.0f);
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
