using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectWall;            // 벽을 감지했는가?
    protected bool isDetectLegde;           // 낭떨어지를 감지했는가?

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.moveSpeed);

        isDetectWall = entity.CheckWall();
        isDetectLegde = entity.CheckLedge();
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

        isDetectWall = entity.CheckWall();
        isDetectLegde = entity.CheckLedge();
    }
}
