using UnityEngine;

public class WeaponAnimationToWeapon : MonoBehaviour
{
    private Weapon weapon;

    private void Start()
    {
        weapon = GetComponentInParent<Weapon>();
    }

    private void AnimationFinishTrigger()
    {
        weapon.ExitWeapon();
    }

    // 그냥 바로 PlayerCombatController에서 공격키 눌렀을 때 발동
    //private void AnimationStartMovementTrigger()
    //{
    //    weapon.AnimationStartMovementTrigger();
    //}

    private void AnimationStopMovementTrigger()
    {
        weapon.AnimationStopMovementTrigger();
    }
}
