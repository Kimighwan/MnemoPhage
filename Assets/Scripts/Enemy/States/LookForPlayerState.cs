using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayerState stateData;

    protected bool isPlayerInDetectedMinRange;
    protected bool isAllTurnsDone;                   // 모든 Turn을 수행 했는가?
    protected bool isAllTurnTimeDone;               // 한 번의 Turn의 시간을 다 소진했는가?
    protected bool isTurnImmediately;               // Flip을 즉시 수행할 것인가?

    protected float lastTurnTIme;                   // 마지막 Turn 시간

    protected int amountOfTurnsDone;                // 수행된 Turn의 양

    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayerState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInDetectedMinRange = entity.CheckPlayerInMinRange();
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnTimeDone = false;
        isAllTurnsDone = false;

        lastTurnTIme = startTime;

        amountOfTurnsDone = 0;

        entity.SetVelocity(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if (isTurnImmediately)
        {
            entity.Flip();
            lastTurnTIme = Time.time;
            amountOfTurnsDone++;
            isTurnImmediately = false;
        }
        else if(Time.time >= lastTurnTIme + stateData.timeBetweenTurn && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTIme = Time.time;
            amountOfTurnsDone++;
        }

        if(amountOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if (Time.time >= lastTurnTIme + stateData.timeBetweenTurn && isAllTurnsDone)
        {
            isAllTurnTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetTurnImmediately(bool flip)
    {
        isTurnImmediately = flip;
    }
}
