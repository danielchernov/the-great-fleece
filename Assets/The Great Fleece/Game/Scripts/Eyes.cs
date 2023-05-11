using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutscene;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _gameOverCutscene.SetActive(true);
        }
    }
}
