using UnityEngine;

public class LobbyManager : SingletonBehaviour<LobbyManager>
{
    public LobbyUIController lobbyUIController;

    private bool isLoadingInGame;   // 로딩 중인가?

    protected override void Init()
    {
        isDestoryOnLoad = true;     // 씬 전환시 삭제
        isLoadingInGame = false;    // 로딩 중이 아니다

        base.Init();
    }

    private void Start()
    {
        if (!lobbyUIController) // 버그 예외처리
        {
            Debug.Log("LobbyUIController does not exist.");
            return;
        }

        // 씬 시작 애니메이션 순차적으로 나오게 
        // AudioManager.Instance.PlayBGM(BGM.lobby);
    }

    public void StartGame()
    {
        if (isLoadingInGame) return;    // 이미 로딩 중이면 실행 X

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

    public void Credit()
    {
        // 크레딧 창
    }
}
