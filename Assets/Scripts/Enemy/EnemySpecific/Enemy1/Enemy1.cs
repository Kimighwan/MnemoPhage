using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState {  get; private set; }
    public E1_MoveState moveState { get; private set; }

    [SerializeField]
    private D_IdelState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);

        stateMachine.Init(moveState);
    }
}
