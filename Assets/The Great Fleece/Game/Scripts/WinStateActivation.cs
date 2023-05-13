using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _winLevelCutscene;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (GameManager.Instance.HasCard)
            {
                AudioManager.Instance.StopAudios();
                _winLevelCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("You don't have the key!");
            }
        }
    }
}
