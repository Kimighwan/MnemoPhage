using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGroundedState : PlayerState
{
    protected int moveXInput;

    private bool JumpInput;
    private bool dashInput;

    private bool isGrounded;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoCheck()
    {
        base.DoCheck();

        isGrounded = player.CheckGround();
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpLeft();
        player.DashState.SetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        moveXInput = player.InputHandler.MoveInputDirection;
        JumpInput = player.InputHandler.JumpInput;
        dashInput = player.InputHandler.DashInput;

        if (JumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)   // 여긴 기획에 따라 변경하자
                                // 땅에 있다가 공중으로 간다면 예시로 걷다가 낭떨어지로 떨어질 때
        {
            player.InAirState.StartCoyoteTime();    // 코요테 타이머 시작
            stateMachine.ChangeState(player.InAirState);
        }
        else if (dashInput && player.DashState.CheckCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
