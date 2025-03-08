using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float moveSpeed = 8.0f;

    [Header("jump State")]
    public float jumpForce = 15f;
    public int amountOfJunp = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float varialbleJumpHeightMultiplier = 0.5f;

    [Header("Dash State")]
    public float dashCoolDown = 1.5f;
    public float dashTime = 0.2f;
    public float dashVelocity = 10f;
    public float drag = 10f;

    [Header("Check Variables")]
    public float groundCheckRadius;
    public LayerMask whatIsGround;
}
