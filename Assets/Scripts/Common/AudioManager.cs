using System.Collections.Generic;
using UnityEngine;

public enum BGM
{
    lobby,
    COUNT
}

public enum SFX
{
    ui_button_click,
    COUNT
}

public class AudioManager : SingletonBehaviour<AudioManager>
{
    public Transform BGMTrs;
    public Transform SFXTrs;

    private const string AUDIO_PATH = "Audio";  // 여기에 오디오 파일 넣기

    private Dictionary<BGM, AudioSource> m_BGMPlayer = new Dictionary<BGM, AudioSource>();
    private AudioSource m_CurrBGMSource;    // 현재 재생중인 BGM

    private Dictionary<SFX, AudioSource> m_SFXPlayer = new Dictionary<SFX, AudioSource>();

    protected override void Init()
    {
        base.Init();

        LoadBGMPlayer();
        LoadSFXPlayer();
    }

    // BGM 오디오 파일 가져오기
    private void LoadBGMPlayer()
    {
        for(int i = 0; i < (int)BGM.COUNT; i++)
        {
            var audioName = ((BGM)i).ToString();
            var pathStr = $"{AUDIO_PATH}/{audioName}";
            var audioClip = Resources.Load(pathStr, typeof(AudioClip)) as AudioClip;

            if(!audioClip)
            {
                continue;
            }

            var newObj = new GameObject(audioName);
            var newAudioSource = newObj.AddComponent<AudioSource>();

            newAudioSource.clip = audioClip;
            newAudioSource.loop = true;
            newAudioSource.playOnAwake = false;

            newObj.transform.parent = BGMTrs;

            m_BGMPlayer[(BGM)i] = newAudioSource;
        }
    }

    // SFX 오디오 파일 가져오기
    private void LoadSFXPlayer()
    {
        for(int i = 0; i < (int)SFX.COUNT; i++)
        {
            var audioName = ((SFX)i).ToString();
            var pathStr = $"{AUDIO_PATH}/{audioName}";
            var audioClip = Resources.Load(pathStr, typeof(AudioClip))as AudioClip;

            if (!audioClip) continue;

            var newObj = new GameObject(audioName);
            var newAudioSource = newObj.AddComponent<AudioSource>();

            newAudioSource.clip = audioClip;
            newAudioSource.loop = false;
            newAudioSource.playOnAwake = false;

            newObj.transform.parent = SFXTrs;

            m_SFXPlayer[(SFX)i] = newAudioSource;
        }
    }

    // BGM 실행
    public void PlayBGM(BGM bgm)
    {
        if (!m_BGMPlayer.ContainsKey(bgm))
        {
            Debug.Log($"Doesn't exist {bgm}");
            return;
        }

        if (m_CurrBGMSource)
        {
            m_CurrBGMSource.Stop();
            m_CurrBGMSource = null;
        }

        m_CurrBGMSource = m_BGMPlayer[bgm];
        m_CurrBGMSource.Play();
    }

    // BGM 일시정지
    public void PauseBGM()
    {
        if(m_CurrBGMSource) m_CurrBGMSource.Pause();
    }

    // BGM 일시정지 해제
    public void ResumeBGM()
    {
        if (m_CurrBGMSource) m_CurrBGMSource.UnPause();
    }

    // BGM 종료
    public void StopBGM()
    {
        if (m_CurrBGMSource) m_CurrBGMSource.Stop();
    }

    // 효과음 재생
    public void PlaySFX(SFX sfx)
    {
        if (!m_SFXPlayer.ContainsKey(sfx))
        {
            Debug.Log($"Doesn't exist {sfx}");
            return;
        }

        m_SFXPlayer[sfx].Play();
    }

    // 음소거
    public void Mute()
    {
        foreach(var audioSourceItem in m_BGMPlayer)
        {
            audioSourceItem.Value.volume = 0f;
        }

        foreach (var audioSourceItem in m_SFXPlayer)
        {
            audioSourceItem.Value.volume = 0f;
        }
    }

    // 음소거 해제
    public void UnMute()
    {
        foreach (var audioSourceItem in m_BGMPlayer)
        {
            audioSourceItem.Value.volume = 1f;
        }

        foreach (var audioSourceItem in m_SFXPlayer)
        {
            audioSourceItem.Value.volume = 1f;
        }
    }



    //public void OnLoadUserData() // 데이터를 로드했을 때 실행할 함수
    //{
    //    var userSettinsData = UserDataManager.Instance.GetUserData<UserSettingsData>();
    //    if (userSettinsData != null)
    //    {
    //        if (!userSettinsData.sound)
    //        {
    //            Mute();
    //        }
    //    }
    //}
}
