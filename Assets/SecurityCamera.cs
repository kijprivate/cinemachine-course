using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{

    public GameObject capturedCutscene;

    private MeshRenderer meshRenderer;
    private Animator animator;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        animator = GetComponentInParent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            Color color = new Color(255/255f,38/255f,0/255f,20/255f);
            meshRenderer.material.SetColor("_TintColor",color);
            animator.enabled = false;
            StartCoroutine(CameraFreezeRoutine());
        }

    }

    private IEnumerator CameraFreezeRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        capturedCutscene.SetActive(true);
    }
    
}
