using UnityEngine;

public class LobbyManager : SingletonBehaviour<LobbyManager>
{
    public LobbyUIController lobbyUIController;

    private bool isLoadingInGame;
    protected override void Init()
    {
        isDestoryOnLoad = true;
        isLoadingInGame = false;

        base.Init();
    }

    private void Start()
    {
        if (!lobbyUIController)
        {
            Debug.Log("LobbyUIController does not exist.");
            return;
        }

        // AudioManager.Instance.PlayBGM(BGM.lobby);
    }

    public void StartGame()
    {
        if (isLoadingInGame) return;

        isLoadingInGame = true;

        UIManager.Instance.Fade(Color.black, 0f, 1f, 1f, 0f, false, () =>
        {
            UIManager.Instance.CloseAllOpenUI();
            SceneLoader.Instance.LoadScene(SceneType.InGame);
        });
    }

    public void ExitGame()
    {
        // 종료할꺼냐 팝업 창 띄우기
    }
}
