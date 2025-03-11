using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private Enemy1 enemy;
    public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if(!isDetectingLedge || isDetectingWall)
        {
            Debug.Log("돌진 중 이동 방해 받아 Idle 상태 전환");
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            Debug.Log("돌진 시간 오버 감지 상태로 전환");
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
