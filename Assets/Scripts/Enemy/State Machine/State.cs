using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    protected float startTime;  // 상태 시작한 시간

    protected string animBoolName;  // 애니메이션 이름

    // Entity로 생성하면 해당 상태들이 적인 것을 알 수 있다.
    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter() // 상태 진입 시
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit() // 상태 종료 시
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicalUpdate() // Update에서 사용
    {

    }

    public virtual void PhysicsUpdate()  // FixedUpdate에서 사용
    {

    }
}
