using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    // 씬 전환 시 삭제할지 여부
    protected bool isDestoryOnLoad = false;     // false : 유지하며 씬 전환

    protected static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        if(instance == null)
        {
            instance = (T)this;

            if(!isDestoryOnLoad) DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        Dispose();
    }

    protected virtual void Dispose()
    {
        instance = null;
    }
}