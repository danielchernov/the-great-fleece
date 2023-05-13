using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _playerAgent;
    Animator _playerAnimator;

    RaycastHit rayHit;

    [SerializeField]
    private GameObject _coinPrefab;

    [SerializeField]
    private GameObject _clickVFX;

    [SerializeField]
    private AudioClip _coinSFX;

    [SerializeField]
    private GameObject[] _guards;

    private bool _coinTossed = false;

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
                Instantiate(_clickVFX, rayHit.point, Quaternion.identity);
            }
        }

        float distance = Vector3.Distance(transform.position, rayHit.point);
        if (distance < 0.5f)
        {
            _playerAnimator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(1) && !_coinTossed)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayOrigin, out rayHit))
            {
                Instantiate(_coinPrefab, rayHit.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSFX, rayHit.point);

                _coinTossed = true;
                _playerAnimator.SetTrigger("isThrowing");

                SendAItoCoin(rayHit.point);
            }
        }
    }

    void SendAItoCoin(Vector3 coinPosition)
    {
        if (_guards != null)
        {
            for (int i = 0; i < _guards.Length; i++)
            {
                GuardAI guardAI = _guards[i].GetComponent<GuardAI>();
                NavMeshAgent guardAgent = _guards[i].GetComponent<NavMeshAgent>();
                Animator guardAnimator = _guards[i].GetComponent<Animator>();

                guardAI.SentToCoin = true;
                guardAgent.SetDestination(coinPosition);
                guardAnimator.SetBool("isWalking", true);
            }
        }
    }
}
