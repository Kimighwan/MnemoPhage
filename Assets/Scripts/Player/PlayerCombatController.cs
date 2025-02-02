using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField] private bool combatEnabled;
    private bool getInput;

    private float lastInputTime;

    private void Update()
    {
        CheckCombatInput();

    }

    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return;
        }
    }
}
