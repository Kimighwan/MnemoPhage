using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/State Data/Player Detected State")]
public class D_PlayerDetected : ScriptableObject
{
    public float longRangeActionTime = 1.5f;         // 플레이어가 감지되었을 때 몇초 후 공격을 실행할 것인가?
}
