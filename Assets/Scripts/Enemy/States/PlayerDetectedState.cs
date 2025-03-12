using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;

    protected bool isPlayerInMinDetectedRange;
    protected bool isPlayerInMaxDetectedRange;
    protected bool doLongRangeAction;               // 원거리 공격 실행할 것인가?    // 돌진할 때 사용했는데 원거리 공격에 따로 사용하면 이름 바꾸기
    protected bool doMeleeAttackRange;              // 근거리 공격 실행할 것인가?

    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMinDetectedRange = entity.CheckPlayerInMinRange();
        isPlayerInMaxDetectedRange = entity.CheckPlayerInMaxRange();

        doMeleeAttackRange = entity.CheckPlayerInMeleeAttackRange();
    }

    public override void Enter()
    {
        base.Enter();

        doLongRangeAction = false;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if(Time.time >= startTime + stateData.longRangeActionTime)
        {
            doLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate() ;
    }
}
