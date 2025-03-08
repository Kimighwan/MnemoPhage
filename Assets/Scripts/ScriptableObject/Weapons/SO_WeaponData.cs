using UnityEngine;

// 여기에 무기에 관한 데이터 입력 가능
// 예를 들어 어떤 무기는 차징 시간이 필요하다면 여기에 변수를 선언하고 사용 등등

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Weapon")]
public class SO_WeaponData : ScriptableObject
{
    public float[] movementSpeed;
}
