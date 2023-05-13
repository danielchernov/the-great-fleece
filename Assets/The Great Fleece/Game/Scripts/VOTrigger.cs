using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clipToPlay;

    private bool playedAudio = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !playedAudio)
        {
            AudioManager.Instance.PlayVoiceOver(_clipToPlay);
            playedAudio = true;
        }
    }
}
