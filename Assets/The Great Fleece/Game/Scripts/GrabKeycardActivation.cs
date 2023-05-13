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
            GameManager.Instance.HasCard = true;
            _alreadyPlayed = true;
            StartCoroutine(WaitAndDeactivate(collider.gameObject));
        }
    }

    IEnumerator WaitAndDeactivate(GameObject player)
    {
        _grabKeyCutscene.SetActive(true);
        yield return new WaitForSeconds(6);
        _grabKeyCutscene.SetActive(false);
        Camera.main.transform.position = _cameraPosition.position;
        player.transform.position = new Vector3(-4f, -2f, -110f);
    }
}
