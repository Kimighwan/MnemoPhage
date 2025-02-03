using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 CurrentVelocuty { get; private set; }
    public int FacingDirection {  get; private set; }

    [Header("State")]
    public PlayerStateMachine StateMachine {  get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    [Header("Component")]
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D Rigid { get; private set; }

    [Header("Data")]
    [SerializeField] private PlayerData playerData;

    private Vector2 workspace;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
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

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocuty.y);
        Rigid.linearVelocity = workspace;
        CurrentVelocuty = workspace;
    }

    public void CheckFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
