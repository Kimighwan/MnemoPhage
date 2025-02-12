using UnityEngine;

public class InGameManager : SingletonBehaviour<InGameManager>
{
    protected override void Init()
    {
        isDestoryOnLoad = true;     // 씬 전환시 파괴

        base.Init();

        UIManager.Instance.Fade(Color.black, 1f, 0f, 1f, 0f, true);
    }
}
