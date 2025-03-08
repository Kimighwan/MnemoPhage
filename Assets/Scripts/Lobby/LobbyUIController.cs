using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    public void OnClickSettingsBtn()    // 설정 버튼
    {
        var settinsUI = new BaseUIData();
        // UIManager.Instance.OpenUI<SettingsUI>(settinsUI);
    }

    public void OnClickStartBtn()       // 게임 시작 버튼
    {
        // AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        // AudioManager.Instance.StopBGM();
        LobbyManager.Instance.StartGame();
    }

    public void OnClickExitBtn()        // 게임 종료 버튼
    {
        // AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        // AudioManager.Instance.StopBGM();
        LobbyManager.Instance.ExitGame();
    }
    public void OnClickCreditBtn()      // 크래딧 화면 버튼
    {
        // AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        // AudioManager.Instance.StopBGM();
        LobbyManager.Instance.Credit();
    }

}
