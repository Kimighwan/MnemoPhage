using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AttackState : State
{
    protected Transform attackPosition;     // 공격 위치

    protected bool isAnimationFinished;     // 공격 애니메이션이 끝났는가?

    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();

        entity.animationStateMachineAnimation.attackState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
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

    // 애니메이션에 Event Trigger로 넣는데 나는 선호하지 않는다
    // 그렇기에 Enter에서 호출하는 방식을 생각해보자
    public virtual void TriggerAttack()     // 애니메이션에서 데미지를 입힐 때 호출
    {

    }

    public virtual void FinishAttack()      // 애니메이션 마지막에 종료를 알릴 때 호출
    {
        isAnimationFinished = true;
    }
}
