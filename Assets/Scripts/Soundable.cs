using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundable : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip clip1;

    public float volume = 1.0f;
    public float volume1 = 1.0f;

    public void Sound()
    {
        FindObjectOfType<AudioRef>().PlaySFX(clip, volume);
        FindObjectOfType<AudioRef>().PlaySFX(clip1, volume1);
    }

}
