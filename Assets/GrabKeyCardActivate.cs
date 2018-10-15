using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivate : MonoBehaviour
{

    public GameObject SleepingGuardCutscene;

    private bool wasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !wasPlayed)
        {
            SleepingGuardCutscene.SetActive(true);
            wasPlayed = true;
        }
    }
}
