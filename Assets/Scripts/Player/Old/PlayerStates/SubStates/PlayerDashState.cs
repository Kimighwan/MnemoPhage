using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }

    private bool dashInput;

    private float lastDashTime;
    private float dashDirectionp;

    private float startYVelocity;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CanDash = false;
        startYVelocity = player.CurrentVelocuty.y;
    }

    public override void Exit()
    {
        base.Exit();

        if (player.CurrentVelocuty.y > 0.01f)
        {
            player.SetVelocityY(startYVelocity);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        dashInput = player.InputHandler.DashInput;

        if (dashInput)
        {
            startTime = Time.time;
            player.Rigid.linearDamping = playerData.drag;
            Debug.Log("drag = 10");
            player.SetVelocityX(playerData.dashVelocity);
            player.InputHandler.UseDashInput();
        }

        if (Time.time > startTime + playerData.dashTime)
        {
            player.Rigid.linearDamping = 0f;
            Debug.Log("drag = 0");
            isAbilityDone = true;
            lastDashTime = Time.time;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool CheckCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCoolDown;
    }

    public void SetCanDash() => CanDash = true;
}
