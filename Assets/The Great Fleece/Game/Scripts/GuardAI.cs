using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _waypoints;
    private NavMeshAgent _guardAgent;

    Animator _guardAnimator;

    private int _currentWaypoint = 0;

    private bool _isReverse = false;
    private bool _targetReached = false;

    public bool SentToCoin = false;

    void Start()
    {
        _guardAgent = GetComponent<NavMeshAgent>();
        _guardAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_waypoints.Count > 1 && _waypoints[_currentWaypoint] != null && !SentToCoin)
        {
            _guardAgent.SetDestination(_waypoints[_currentWaypoint].position);

            float distance = Vector3.Distance(
                transform.position,
                _waypoints[_currentWaypoint].position
            );

            if (
                distance < 1f && (_currentWaypoint == 0 || _currentWaypoint == _waypoints.Count - 1)
            )
            {
                _guardAnimator.SetBool("isWalking", false);
            }
            else
            {
                _guardAnimator.SetBool("isWalking", true);
            }

            if (distance < 1f && _targetReached == false)
            {
                _targetReached = true;

                StartCoroutine(WaitBeforeMoving());
            }
        }
        else if (SentToCoin)
        {
            float distance = Vector3.Distance(transform.position, _guardAgent.destination);

            if (distance < 4f)
            {
                _guardAnimator.SetBool("isWalking", false);
                _guardAgent.SetDestination(gameObject.transform.position);
                StartCoroutine(WaitForCoin());
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        if (_currentWaypoint == 0 || _currentWaypoint == _waypoints.Count - 1)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
        }
        else
        {
            yield return null;
        }

        _targetReached = false;

        if (_isReverse)
        {
            _currentWaypoint--;
            if (_currentWaypoint == 0)
            {
                _isReverse = false;
            }
        }
        else
        {
            _currentWaypoint++;
            if (_currentWaypoint == _waypoints.Count)
            {
                _isReverse = true;
                _currentWaypoint--;
            }
        }
    }

    IEnumerator WaitForCoin()
    {
        yield return new WaitForSeconds(5);
        SentToCoin = false;

        if (_waypoints.Count == 1)
        {
            _guardAgent.SetDestination(_waypoints[0].position);
        }
    }
}
