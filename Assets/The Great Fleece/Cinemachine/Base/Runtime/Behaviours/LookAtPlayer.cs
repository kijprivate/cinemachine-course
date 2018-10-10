using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public Player player;

    public Transform startPosition;

    void Start()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
    }
	// Update is called once per frame
	void Update ()
	{
	    transform.LookAt(player.transform, Vector3.up);
	}
}
