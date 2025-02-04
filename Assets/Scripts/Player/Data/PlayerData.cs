using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float moveSpeed = 10.0f;

    [Header("jump State")]
    public float jumpForce = 15f;
    public int amountOfJunp = 2;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float varialbleJumpHeightMultiplier = 0.5f;

    [Header("Check Variables")]
    public float groundCheckRadius;
    public LayerMask whatIsGround;
}
