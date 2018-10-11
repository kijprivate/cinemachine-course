using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VoiceOverScript : MonoBehaviour
{

    //public AudioClip audioClip;
    private AudioSource audioSource;
    private bool wasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&& !wasPlayed)
        {
            audioSource.Play();
            wasPlayed = true;
        }
    }
}
