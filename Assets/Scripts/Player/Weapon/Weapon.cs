using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Animator playerAnimator;
    [SerializeField] protected Animator baseAnimator;
    [SerializeField] protected Animator weaponAnimator;

    protected virtual void Start()
    {
        playerAnimator = transform.parent.parent.GetComponent<Animator>();
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        playerAnimator.SetBool("attack", true);
        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);
    }

    public virtual void ExitWeapon()
    {
        playerAnimator.SetBool("attack", false);
        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        gameObject.SetActive(false);
    }
}
