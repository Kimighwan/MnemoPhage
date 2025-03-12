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

        // 로비 씬 로드
        asyncOperation = SceneLoader.Instance.LoadSceneAsync(SceneType.Lobby);

        if(asyncOperation == null) // 버그 예외 처리
        {
            yield break;
        }

        asyncOperation.allowSceneActivation = false;        // 로딩 완료시 화면 전환 끄기

        while (!asyncOperation.isDone)                      // 로딩이 진행 중일 때
        {
            if (asyncOperation.progress >= 0.9f)            // 로딩 90% 이상 완료
            {
                asyncOperation.allowSceneActivation = true; // 로딩 완료시 화면 전환 켜기
                yield break;
            }

            yield return null;
        }
    }
}
