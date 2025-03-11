using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;

    protected bool isPlayerInMinDetectedRange;      // 몬스터의 최소 탐지 범위
    protected bool isDetectingWall;                 // 현재 벽이 감지되었는가?
    protected bool isDetectingLedge;                // 현재 땅이 감지되었는가?
    protected bool isChargeTimeOver;                // 돌진 시간을 초과하였는가?

    public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMinDetectedRange = entity.CheckPlayerInMinRange();
        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(stateData.chargeSpped);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if(Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
