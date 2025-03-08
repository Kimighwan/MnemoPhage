using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Combat System")]
    [SerializeField] private bool combatEnabled;
    private bool getInput;

    private float lastInputTime;

    private Weapon weapon;
    private TestWeaponInventory testWeaponInventory;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        testWeaponInventory = GetComponent<TestWeaponInventory>();
        SetWeapon(testWeaponInventory.weapon[0]);
    }


    private void Update()
    {
        CheckCombatInput();
    }

    private void CheckCombatInput() // 공격 입력 체크
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("일반 공격");
            weapon.EnterWeapon();
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

    public void SetWeapon(Weapon weapon)    // Setting Weapon 
    {
        this.weapon = weapon;
    }
}
