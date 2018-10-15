using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{

    public GameObject Cutscenes;
    public GameObject WinCutscene;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Cutscenes.SetActive(true);
            if (GameManager.Instance.HasKey)
            {
                WinCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("You must have a key card");
            }
        }
    }
}
