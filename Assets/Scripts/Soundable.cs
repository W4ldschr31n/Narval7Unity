using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundData
{
    public AudioClip clip;
    public float volume;
    public bool oneShot;
    public bool hasBeenPlayed;
}

public class Soundable : MonoBehaviour
{
    public List<SoundData> soundData = new List<SoundData>();
    public AudioClip clip;
    public AudioClip clip1;

    public float volume = 1.0f;
    public float volume1 = 1.0f;

    public void Sound()
    {
        foreach (SoundData data in soundData)
        {
            if (data.oneShot && data.hasBeenPlayed)
                break;
            FindObjectOfType<AudioRef>().PlaySFX(data.clip, data.volume);
            data.hasBeenPlayed = true;
        }
    }
}
