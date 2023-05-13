using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is Null");
            }

            return _instance;
        }
    }

    public AudioSource voiceOver;
    public AudioSource bgm;

    void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip audioToPlay)
    {
        voiceOver.PlayOneShot(audioToPlay, 0.5f);
    }

    public void StopAudios()
    {
        voiceOver.Stop();
        bgm.Stop();
    }
}
