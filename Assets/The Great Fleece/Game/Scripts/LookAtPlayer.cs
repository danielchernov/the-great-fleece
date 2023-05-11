using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    Transform _player;

    [SerializeField]
    Transform _startingCamera;

    void Start()
    {
        transform.position = _startingCamera.position;
    }

    void Update()
    {
        transform.LookAt(_player);
    }
}
