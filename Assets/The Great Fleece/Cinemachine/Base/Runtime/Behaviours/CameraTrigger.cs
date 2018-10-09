using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public GameObject TriggeredCamera;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("Trigger");
            Camera.main.transform.position = TriggeredCamera.transform.position;
            Camera.main.transform.rotation = TriggeredCamera.transform.rotation;

        }
    }
}
