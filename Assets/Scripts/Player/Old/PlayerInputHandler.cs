using UnityEngine;
using UnityEngine.EventSystems;

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
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
