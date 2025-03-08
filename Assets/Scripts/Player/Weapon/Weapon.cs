using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] 
    private SO_WeaponData weaponData;

    protected Animator playerAnimator;
    protected Animator baseAnimator;
    protected Animator weaponAnimator;

    private PlayerCombatController playerCombatController;

    protected int attackCounter;

    protected virtual void Start()
    {
        playerAnimator = transform.parent.parent.GetComponent<Animator>();
        playerCombatController = transform.parent.parent.GetComponent<PlayerCombatController>();
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();


        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if(attackCounter >= weaponData.movementSpeed.Length)
        {
            attackCounter = 0;
        }

        playerAnimator.SetBool("attack", true);
        baseAnimator.SetTrigger("attack");
        weaponAnimator.SetTrigger("attack");

        baseAnimator.SetInteger("attackCounter", attackCounter);
        weaponAnimator.SetInteger("attackCounter", attackCounter);
    }

    public virtual void ExitWeapon()
    {
        playerAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    public virtual void AnimationStartMovementTrigger()
    {
        playerCombatController.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        playerCombatController.SetPlayerVelocity(playerCombatController.orignalVelocity);
    }
}
