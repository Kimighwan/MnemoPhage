using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    private PlayerController playerController;
    private Weapon weapon;
    private TestWeaponInventory testWeaponInventory;

    private bool combatEnabled;
    private bool getInput;
    private bool setVelocity;       // 이동 속도를 변경할 것인가?

    private float lastInputTime;
    private float velocityToSet;    // 공격시 설정할 이동 속도

    
    public float orignalVelocity {  get; private set; } // 기존 이동 속도


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        testWeaponInventory = GetComponent<TestWeaponInventory>();
        SetWeapon(testWeaponInventory.weapon[0]);
        setVelocity = false;
    }


    private void Update()
    {
        CheckCombatInput();
        SetPlayerAttackMoveSpeed();
    }

    private void CheckCombatInput() // 공격 입력 체크
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("일반 공격");
            weapon.EnterWeapon();
            weapon.AnimationStartMovementTrigger();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("강공격");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("특수 공격");
        }
    }

    public void SetWeapon(Weapon weapon)    // 무기 설정
    {
        this.weapon = weapon;
    }

    public void SetPlayerVelocity(float velocity)   // 외부에서 플레이어 이동 속도 조절
    {
        orignalVelocity = playerController.moveSpeed;

        playerController.SetVelocityX(velocity);

        velocityToSet = velocity;
        setVelocity = true;
    }

    private void SetPlayerAttackMoveSpeed() // 설정된 속도로 지속적으로 설정
    {
        if (setVelocity)
        {
            playerController.SetVelocityX(velocityToSet);
        }
    }
}
