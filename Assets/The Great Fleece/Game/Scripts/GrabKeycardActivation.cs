using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _grabKeyCutscene;

    [SerializeField]
    private Transform _cameraPosition;

    private bool _alreadyPlayed = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !_alreadyPlayed)
        {
            _alreadyPlayed = true;
            StartCoroutine(WaitAndDeactivate());
        }
    }

    IEnumerator WaitAndDeactivate()
    {
        _grabKeyCutscene.SetActive(true);
        yield return new WaitForSeconds(6);
        _grabKeyCutscene.SetActive(false);
        Camera.main.transform.position = _cameraPosition.position;
    }
}
