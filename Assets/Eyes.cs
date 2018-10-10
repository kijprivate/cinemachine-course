using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    public GameObject _captured;
	// Use this for initialization
	
	// Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _captured!=null)
        {
            _captured.SetActive(true);
        }
    }
}
