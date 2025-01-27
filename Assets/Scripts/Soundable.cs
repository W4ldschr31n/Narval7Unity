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
