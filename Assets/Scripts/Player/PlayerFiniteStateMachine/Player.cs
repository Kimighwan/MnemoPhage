using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables

    public PlayerStateMachine StateMachine {  get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }

    #endregion

    #region Components

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D Rigid { get; private set; }

    #endregion

    #region Check Transforms

    [SerializeField] private Transform groundCheck;

    #endregion

    #region Data

    [SerializeField] private PlayerData playerData;

    #endregion

    #region Other Variables

    public Vector2 CurrentVelocuty { get; private set; }
    public int FacingDirection { get; private set; }



    private Vector2 workspace;

    #endregion

    #region Unity Callback Fucntion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Rigid = GetComponent<Rigidbody2D>();

        FacingDirection = 1;    // Right

        StateMachine.Init(IdleState);
    }

    private void Update()
    {
        CurrentVelocuty = Rigid.linearVelocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Set Functions

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity * playerData.moveSpeed, CurrentVelocuty.y);
        Rigid.linearVelocity = workspace;
        CurrentVelocuty = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocuty.x, velocity);
        Rigid.linearVelocity = workspace;
        CurrentVelocuty = workspace;
    }

    #endregion

    #region Check Functions

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public void CheckFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    #endregion

    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    #endregion
}
