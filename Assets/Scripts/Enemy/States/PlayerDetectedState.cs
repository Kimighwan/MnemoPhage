using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;

    protected bool isPlayerInMinDetectedRange;
    protected bool isPlayerInMaxDetectedRange;

    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);

        isPlayerInMinDetectedRange = entity.CheckPlayerInMinRange();
        isPlayerInMaxDetectedRange = entity.CheckPlayerInMaxRange();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isPlayerInMinDetectedRange = entity.CheckPlayerInMinRange();
        isPlayerInMaxDetectedRange = entity.CheckPlayerInMaxRange();
    }
}
