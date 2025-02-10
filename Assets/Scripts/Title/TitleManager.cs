using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Logo
    public Animation teamLogoAnimation;

    // DescImage
    public GameObject descImage;

    private AsyncOperation asyncOperation;

    private void Awake()
    {
        teamLogoAnimation.gameObject.SetActive(true);
        descImage.SetActive(false);
    }

    private void Start()
    {
        // 유저 데이터 로드
        // 유저 데이터에 따라 오디오 킬지 말지 결정

        StartCoroutine(LogoCo());
    }

    private IEnumerator LogoCo()
    {
        teamLogoAnimation.Play();   // 팀로고 애니메이션 재생
        yield return new WaitForSeconds(teamLogoAnimation.clip.length);

        teamLogoAnimation.gameObject.SetActive(false);
        descImage.SetActive(true);

        asyncOperation = SceneLoader.Instance.LoadSceneAsync(SceneType.Lobby);

        if(asyncOperation == null)
        {
            yield break;
        }

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)  // 로딩이 진행 중일 때
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
                yield break;
            }

            yield return null;
        }
    }
}
