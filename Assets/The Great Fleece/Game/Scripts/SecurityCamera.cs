using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutscene;

    [SerializeField]
    private MeshRenderer[] _cameraMeshRenderer;

    [SerializeField]
    private Animator[] _cameraAnimator;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine(GotCaught());
        }
    }

    IEnumerator GotCaught()
    {
        for (int i = 0; i < _cameraMeshRenderer.Length; i++)
        {
            _cameraMeshRenderer[i].material.SetColor("_TintColor", new Color(1, 0, 0, 0.1f));
            _cameraAnimator[i].speed = 0;
        }
        yield return new WaitForSeconds(1);

        AudioManager.Instance.StopAudios();
        _gameOverCutscene.SetActive(true);
    }
}
