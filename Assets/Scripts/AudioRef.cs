using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRef : MonoBehaviour
{
    [Header("---------Audio Source----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;



    [Header("---------Audio Clip----------")]

    public AudioClip background;
    public AudioClip MetalLocker;


    private void Start()
    {
        MusicSource.clip = background;
        MusicSource.Play();

    }

    public void PlaySFX(AudioClip clip, float volume=1.0f)
    {
        SFXSource.volume = volume;
        SFXSource.PlayOneShot(clip);
    }
}
