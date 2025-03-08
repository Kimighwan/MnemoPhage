using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager>
{
    public Transform uICanvasTrs;   // 캔버스 위치
    public Transform closedUITrs;   // 비활성 UI 위치

    public Image fadeImage;         // fade in/out 사용할 이미지


    private BaseUI frontUI;         // 최상단 UI
    
    // 열린 UI
    private Dictionary<System.Type, GameObject> openUIPool = new Dictionary<System.Type, GameObject>();

    // 닫힌 UI 
    private Dictionary<System.Type, GameObject> closedUIPool = new Dictionary<System.Type, GameObject>();


    protected override void Init()
    {
        base.Init();

        fadeImage.transform.localScale = Vector3.zero;
    }

    private BaseUI GetUI<T>(out bool isAlreayOpen)  // 존재한다면 해당 BaseUI 반환 없다면 null 반환
    {
        System.Type uiType = typeof(T);

        BaseUI ui = null;
        isAlreayOpen = false;

        if (openUIPool.ContainsKey(uiType))         // 이미 활성화
        {
            ui = openUIPool[uiType].GetComponent<BaseUI>();
            isAlreayOpen = true;
        }
        else if (closedUIPool.ContainsKey(uiType))  // 비활성화
        {
            ui = closedUIPool[uiType].GetComponent<BaseUI>();
            closedUIPool.Remove(uiType);
        }
        else                                        // 생성된 적이 없다면
        {
            var uiObj = Instantiate(Resources.Load($"UI/{uiType}", typeof(GameObject))) as GameObject;
            ui = uiObj.GetComponent<BaseUI>();
        }

        return ui;
    }

    public void OpenUI<T>(BaseUIData uIData)    // UI 열기
    {
        System.Type uiType = typeof(T);

        bool isAlreayOpen = false;
        var ui = GetUI<T>(out isAlreayOpen);

        if (!ui) return;            // 해당 UI가 존재하지 않음

        if (isAlreayOpen) return;   // 이미 열려있음

        var siblingIndex = uICanvasTrs.childCount - 1;  // -1 이유는 FadeImg가 최상단에 위치해야 하기 때문임
        ui.Init(uICanvasTrs);                           // 위치 설정
        ui.transform.SetSiblingIndex(siblingIndex);     // 계층구조에서 순서 설정
        ui.gameObject.SetActive(true);                  // 활성화
        ui.SetInfo(uIData);
        ui.ShowUI();

        frontUI = ui;
        openUIPool[uiType] = ui.gameObject;
    }

    public void CloseUI(BaseUI ui)  // UI 닫기
    {
        System.Type uiType = ui.GetType();

        ui.gameObject.SetActive(false);

        openUIPool.Remove(uiType);
        closedUIPool[uiType] = ui.gameObject;

        ui.transform.SetParent(closedUITrs);

        frontUI = null;

        var lastChild = uICanvasTrs.GetChild(uICanvasTrs.childCount - 2);   // -1인 자식 오브젝트는 FadeImg임
        if(lastChild != null)
        {
            frontUI = lastChild.gameObject.GetComponent<BaseUI>();
        }
    }

    public BaseUI GetActiveUI<T>()          // 원하는 UI가 열려있다면 반환 아니면 null 반환
    {
        var uiType = typeof(T);
        return openUIPool.ContainsKey(uiType) ? openUIPool[uiType].GetComponent<BaseUI>() : null;
    }

    public bool ExistOpenUI()               // 활성화된 UI가 있는지 확인
    {
        return frontUI != null;
    }

    public BaseUI GetCurrentFrontUI()       // 최상단 UI 리턴
    {
        return frontUI;
    }

    public void CloseCurrentFrontUI()       // 최상단 UI 닫기
    {
        frontUI.CloseUI();
    }

    public void CloseAllOpenUI()            // 열려있는 모든 UI 닫기
    {
        while (frontUI)
        {
            frontUI.CloseUI(true);
        }
    }

    // Fade In/Out 기능
    #region Fade

    
    /// <param name="color"></param>                색상 지정
    /// <param name="startAlpha"></param>           fade 진행시 시작 Alpha 값
    /// <param name="endAlpha"></param>             fade 진행시 종료 Alpha 값
    /// <param name="duration"></param>             fade 진행 시간
    /// <param name="startDelay"></param>           fade 시작 전 딜레이
    /// <param name="deActivateOnFinish"></param>   fade 종료후 fade 이미지 활성/비활성화
    /// <param name="onFinish"></param>             끝났을 때 작동할 동작들
    public void Fade(Color color, float startAlpha, float endAlpha, float duration, float startDelay, bool deActivateOnFinish, Action onFinish = null)
    {
        StartCoroutine(FadeCo(color, startAlpha, endAlpha, duration, startDelay, deActivateOnFinish, onFinish));
    }

    private IEnumerator FadeCo(Color color, float startAlpha, float endAlpha, float duration, float startDelay, bool deActivateOnFinish, Action onFinish)
    {
        yield return new WaitForSeconds(startDelay);

        fadeImage.transform.localScale = Vector3.one;
        fadeImage.color = new Color(color.r, color.g, color.b, startAlpha);

        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < duration)
        {
            fadeImage.color = new Color(color.r, color.g, color.b, Mathf.Lerp(startAlpha, endAlpha, (Time.realtimeSinceStartup - startTime) / duration));
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, endAlpha);

        if (deActivateOnFinish)
        {
            fadeImage.transform.localScale = Vector3.zero;
        }

        onFinish?.Invoke();
    }

    #endregion
}
