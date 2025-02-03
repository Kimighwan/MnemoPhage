using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int moveXInput;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoCheck()
    {
        base.DoCheck();
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

        moveXInput = player.InputHandler.MoveInputDirection;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
