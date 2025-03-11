using UnityEngine;

public class E1_LookForPlayerState : LookForPlayerState
{
    private Enemy1 enemy;

    public E1_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayerState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if (isPlayerInDetectedMinRange)
        {
            Debug.Log("플레이어 다시 찾아서 탐지 상태로 전환");
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isAllTurnTimeDone)
        {
            Debug.Log("플레이어를 찾지 못해 이동 상태 전환");
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
