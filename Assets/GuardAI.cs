using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class GuardAI : MonoBehaviour
{

    public List<Transform> WayPoints;

    private Transform _currentTarget;
    private NavMeshAgent _agent;
    private Animator _animator;
    private int _index = 0;
    private bool _reverse = false;
    private bool _targetReached = false;

	// Use this for initialization
	void Start () {

	    _agent = GetComponent<NavMeshAgent>();
	    _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{

        if ( WayPoints[_index]!=null && WayPoints.Count>0)
	    {
	        _currentTarget = WayPoints[_index];
	        _agent.destination = _currentTarget.position;
	        float distance = Vector3.Distance(transform.position, _currentTarget.position);
            if (distance < 1f && !_targetReached)
            {
                _targetReached = true;

                StartCoroutine(WaitBeforeMovingRoutine());

                
            }
           // print(_currentTarget);
        }
	    
	}

    private IEnumerator WaitBeforeMovingRoutine()
    {
        if ((_index == 0 || _index == WayPoints.Count - 1 && _reverse == false))
        {
            _animator.SetBool("Walk",false);
            yield return new WaitForSeconds(3f);
        }

        if (WayPoints.Count > 1)
        {
            switch (_reverse)
            {
                case true:
                {
                    _index--;
                    _animator.SetBool("Walk", true);
                    if (_index == 0)
                    {
                        _reverse = false;
                        _index = 0;
                    }

                    break;
                }
                case false:
                {
                    _index++;
                    _animator.SetBool("Walk", true);
                    if (_index == WayPoints.Count)
                    {
                        _reverse = true;
                        _index--;
                    }

                    break;
                }
            }
        }

        _targetReached = false;
    }
}
