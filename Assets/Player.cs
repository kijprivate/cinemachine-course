using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject CoinPrefab;

    private NavMeshAgent _navMeshAgent;

    private Animator _animator;

    private Vector3 _target;

    private bool _coinThrown = false;
	// Use this for initialization
	void Start ()
	{
	    _animator = GetComponentInChildren<Animator>();
	    _navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin,out hitInfo))
            {
                _navMeshAgent.destination = hitInfo.point;
                _target = hitInfo.point;
                _animator.SetBool("Walk",true);
            }

        }

	    float distance = Vector3.Distance(transform.position,_target);

	    if (distance < 3f)
	    {
	        _animator.SetBool("Walk", false);
	    }

	    if (Input.GetMouseButtonDown(1) && !_coinThrown)
	    {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            _animator.SetTrigger("Throw");

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(CoinPrefab, hitInfo.point, Quaternion.identity);
            }

            SendAIToCoin(hitInfo.point);
	        _coinThrown = true;
	    }
    }

    void SendAIToCoin(Vector3 coinPos)
    {
        GuardAI[] guardAIs = FindObjectsOfType<GuardAI>();
        foreach (var guard in guardAIs)
        {
            guard.coinExist = true;
            guard.GetComponent<NavMeshAgent>().SetDestination(coinPos);
            Animator anim = guard.GetComponent<Animator>();
            anim.SetBool("Walk", true);
            guard.coinPos = coinPos;
        }
    }
}
