using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSystem : MonoBehaviour
{
    [SerializeField] private AudioClip onDeathSFX;
    [SerializeField] private AudioClip onFireSFX;
    [SerializeField] [Range(0,1)] private float volumeOfSFX = 0.5f;
    
    //cached reference
    private AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void DeathSFX()
    {
        AudioSource.PlayClipAtPoint(onDeathSFX, Camera.main.transform.position, volumeOfSFX);
    }
    public void FireSFX()
    {
        myAudioSource.PlayOneShot(onFireSFX, volumeOfSFX);
    }
}
