using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title,
    Lobby,
    InGame,
}


public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    public void LoadScene(SceneType sceneType)  // 씬 불러오기
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneType.ToString());
    }

    public void ReloadScene()                   // 씬 재시작
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public AsyncOperation LoadSceneAsync(SceneType sceneType)   // 비동기 씬 로드
    {
        Time.timeScale = 1.0f;
        return SceneManager.LoadSceneAsync(sceneType.ToString());
    }
}
