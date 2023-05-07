using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _playerAgent;
    Animator _playerAnimator;

    RaycastHit rayHit;

    void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayOrigin, out rayHit))
            {
                _playerAgent.SetDestination(rayHit.point);
                _playerAnimator.SetBool("isWalking", true);
            }
        }

        float distance = Vector3.Distance(transform.position, rayHit.point);
        if (distance < 0.2f)
        {
            _playerAnimator.SetBool("isWalking", false);
        }
    }
}
