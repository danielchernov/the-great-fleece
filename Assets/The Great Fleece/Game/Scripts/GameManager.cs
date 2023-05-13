using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is Null");
            }

            return _instance;
        }
    }
    public bool HasCard { get; set; }
    public PlayableDirector playableDirector;

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playableDirector.transform.parent.gameObject.activeSelf)
            {
                playableDirector.time = 62.2;
            }
        }
    }
}
