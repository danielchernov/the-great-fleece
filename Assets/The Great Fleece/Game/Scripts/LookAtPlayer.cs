using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    Transform _player;

    void Update()
    {
        transform.LookAt(_player);
    }
}
