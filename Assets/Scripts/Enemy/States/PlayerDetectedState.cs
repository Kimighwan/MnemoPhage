using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;
    
    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
}
