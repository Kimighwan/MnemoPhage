using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInAirState : PlayerAbilityState
{
    // Input
    private bool jumpInput;
    private int xInput;
    private bool jumpInputStop;
    private bool dashInput;

    // Check
    private bool isGrounded;
    private bool isJumping;

    private bool coyoteTime;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();

        xInput = player.InputHandler.MoveInputDirection;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        dashInput = player.InputHandler.DashInput;

        CheckJumpMultilier();

        if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isGrounded && player.CurrentVelocuty.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if(dashInput && player.DashState.CheckCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        else
        {
            player.CheckFlip(xInput);
            player.SetVelocityX(xInput);

            player.Anim.SetFloat("yVelocity", player.CurrentVelocuty.y);
        }
    }

    private void CheckJumpMultilier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocuty.y * playerData.varialbleJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.CurrentVelocuty.y <= 0.01f)
            {
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if(coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DescreaseAmountOfJumpleft();
        }
    }

    public void StartCoyoteTime() => coyoteTime = true;

    public void SetIsJumping() => isJumping = true;
}
