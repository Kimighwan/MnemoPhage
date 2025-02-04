using UnityEngine;

public class PlayerInAirState : PlayerAbilityState
{
    private bool isGrounded;
    private bool jumpInput;
    private bool coyoteTime;
    private bool isJumping;
    private bool jumpInputStop;

    private int xInput;

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

        CheckJumpMultilier();

        if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isGrounded && player.CurrentVelocuty.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
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
