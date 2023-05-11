using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioSource _VOAudioSource;

    [SerializeField]
    private AudioClip _clipToPlay;

    private bool playedAudio = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !playedAudio)
        {
            playedAudio = true;
            _VOAudioSource.PlayOneShot(_clipToPlay, 0.5f);
        }
    }
}
