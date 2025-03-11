using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectWall;            // 벽을 감지했는가?
    protected bool isDetectLegde;           // 낭떨어지를 감지했는가?

    protected bool isPlayerInMinDetectedRange;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isDetectWall = entity.CheckWall();
        isDetectLegde = entity.CheckLedge();
        isPlayerInMinDetectedRange = entity.CheckPlayerInMinRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.moveSpeed);
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
    }
}
