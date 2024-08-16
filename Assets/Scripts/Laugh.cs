using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Laugh : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    private bool activeAudio = false;
    public bool attack;

    private void OnTriggerEnter(Collider other)
    {
        if (!activeAudio && other.GetComponent<FirstPersonController>())
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        activeAudio = true;
        yield return new WaitForSeconds(5);
        activeAudio = false;
    }
    
}