using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    private NavMeshAgent _navMeshAgent;

    private Animator _animator;

    private Vector3 _target;
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
                // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // cube.transform.position = hitInfo.point;
                _animator.SetBool("Walk",true);
            }

        }

	    float distance = Vector3.Distance(transform.position,_target);

	    if (distance < 3f)
	    {
	        _animator.SetBool("Walk", false);
	    }
    }
}
