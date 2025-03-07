using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    public void OnClickSettingsBtn()
    {
        var settinsUI = new BaseUIData();
        // UIManager.Instance.OpenUI<SettingsUI>(settinsUI);
    }

    public void OnClickStartBtn()
    {
        // AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        // AudioManager.Instance.StopBGM();
        LobbyManager.Instance.StartGame();
    }

    public void OnClickExitBtn()
    {
        // AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        // AudioManager.Instance.StopBGM();
        LobbyManager.Instance.ExitGame();
    }
    public void OnClickCreditBtn()
    {
        // AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        // AudioManager.Instance.StopBGM();
        LobbyManager.Instance.Credit();
    }

}
