using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public List<AudioClip> audioClips;

    AudioSource AS;


    // Use this for initialization
    void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    public void PlaySound(int clipNumber)
    {
        AS.Stop();
        if (name == "Songs")
        {
            AS.volume = 
        }
        AS.clip = audioClips[clipNumber];
        AS.Play();
    }

}