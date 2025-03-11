using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetectedState
{
    private Enemy1 enemy;

    public E1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        //if (!isPlayerInMaxDetectedRange)    // 감지 범위 밖으로 나감
        //{
        //    enemy.idleState.SetFlipAfterIdle(false);
        //    stateMachine.ChangeState(enemy.idleState);
        //}

        if(doLongRangeAction)
        {
            Debug.Log("계속 감지되어 돌진 상태 전환");
            stateMachine.ChangeState(enemy.chargeState);
        }
        else if (!isPlayerInMaxDetectedRange)
        {
            Debug.Log("감지 실패하여 도리도리 상태 들감");
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
