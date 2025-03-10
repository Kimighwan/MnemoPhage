using UnityEngine;

public class IdleState : State
{
    protected D_IdelState stateData;

    protected bool flipAfterIdle;       // Idle 상태 종료후 Flip을 실행할 것이냐?
    protected bool isIdelTimeOver;      // Idle 상태 지속 시간을 초과 했는가?
    protected bool isPlayerInMinDetectedRange;

    protected float idleTIme;           // Idle 상태 지속 시간

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdelState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdelTimeOver = false;
        SetRandomIdleTime();
        isPlayerInMinDetectedRange = entity.CheckPlayerInMinRange();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if(Time.time >= startTime + idleTIme)   // Idle 상태 시간 체크
        {
            isIdelTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isPlayerInMinDetectedRange = entity.CheckPlayerInMinRange();
    }

    public void SetFlipAfterIdle(bool flip)     // 상태 종료후 Flip 설정
    {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime()            // 랜덤 Idle 시간 정하기
    {
        idleTIme = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
