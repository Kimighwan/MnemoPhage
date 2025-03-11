using UnityEngine;

[CreateAssetMenu(fileName = "newLookForPlayerState", menuName = "Data/State Data/Look For Player State")]
public class D_LookForPlayerState : ScriptableObject
{
    public int amountOfTurns = 2;               // 플레이를 찾는 횟수
    public float timeBetweenTurn = 0.75f;       // 바라보는 시간 = 턴 사이의 시간
}
