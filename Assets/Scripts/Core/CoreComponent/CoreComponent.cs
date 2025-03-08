using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core core;

    private void Awake()
    {
        core = transform.parent.GetComponent<Core>();
    }
}
