using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;          // 벽 체크 거리
    public float ledgeCheckDistance = 0.4f;         // 낭떨어지 체크 거리

    public float playerDetectedMinRange = 2f;       // 플레이어 감지 최소 거리
    public float playerDetectedMaxRange = 4f;       // 플래이어 감지 최대 거리

    public LayerMask layerMask;                     // Ground 레이어 마스크
    public LayerMask whatIsPlayer;                  // Player 레이어 마스크
}
