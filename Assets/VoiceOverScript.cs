﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverScript : MonoBehaviour
{

    public AudioClip audioClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip,Camera.main.transform.position);
        }
    }
}
