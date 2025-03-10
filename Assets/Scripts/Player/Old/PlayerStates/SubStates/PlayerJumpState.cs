using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpLeft;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpLeft = playerData.amountOfJunp;
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(playerData.jumpForce);
        isAbilityDone = true;

        amountOfJumpLeft--;
        player.InAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if(amountOfJumpLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmountOfJumpLeft() => amountOfJumpLeft = playerData.amountOfJunp;

    public void DescreaseAmountOfJumpleft() => amountOfJumpLeft--;
}
