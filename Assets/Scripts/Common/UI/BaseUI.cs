using System;
using UnityEngine;

public class BaseUIData
{
    public Action OnShow;   // UI 열 때 실행할 행위
    public Action OnClose;  // UI 닫을 때 실행할 행위
}

public class BaseUI : MonoBehaviour
{
    public Animation uiAnim;    // UI 열 때 애니메이션이 있다면 여기에 할당

    public Action uiOnShow;
    public Action uiOnClose;

    public virtual void Init(Transform anchor)
    {
        Debug.Log($"{GetType()}::SetInit");

        uiOnShow = null;
        uiOnClose = null;

        transform.SetParent(anchor);

        var rectTransfrom = GetComponent<RectTransform>();
        rectTransfrom.localPosition = Vector3.zero;
        rectTransfrom.localScale = Vector3.one;
        rectTransfrom.offsetMax = Vector3.zero;
        rectTransfrom.offsetMin = Vector3.zero;
    }

    public virtual void SetInfo(BaseUIData uiData)
    {
        Debug.Log($"{GetType()}::SetInfo");

        uiOnClose = uiData.OnShow;
        uiOnShow = uiData.OnClose;
    }

    public virtual void ShowUI()
    {
        if(uiAnim != null)
        {
            uiAnim.Play();
        }

        uiOnShow?.Invoke();
        uiOnShow = null;
    }

    public virtual void CloseUI(bool isCloseAll = false)
    {
        if (!isCloseAll)
        {
            uiOnClose?.Invoke();
        }
        uiOnClose = null;

        UIManager.Instance.CloseUI(this);
    }

    public virtual void OnClickCloseButton()
    {
        // AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        CloseUI();
    }
}
