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

    private const string AUDIO_PATH = "Audio";

    private Dictionary<BGM, AudioSource> m_BGMPlayer = new Dictionary<BGM, AudioSource>();
    private AudioSource m_CurrBGMSource;

    private Dictionary<SFX, AudioSource> m_SFXPlayer = new Dictionary<SFX, AudioSource>();

    protected override void Init()
    {
        base.Init();

        LoadBGMPlayer();
        LoadSFXPlayer();
    }

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

    public void PauseBGM()
    {
        if(m_CurrBGMSource) m_CurrBGMSource.Pause();
    }

    public void ResumeBGM()
    {
        if (m_CurrBGMSource) m_CurrBGMSource.UnPause();
    }

    public void StopBGM()
    {
        if (m_CurrBGMSource) m_CurrBGMSource.Stop();
    }

    public void PlaySFX(SFX sfx)
    {
        if (!m_SFXPlayer.ContainsKey(sfx))
        {
            Debug.Log($"Doesn't exist {sfx}");
            return;
        }

        m_SFXPlayer[sfx].Play();
    }

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
