using UnityEngine.Audio;
using System;
using UnityEngine;

public class GunAudioManager : MonoBehaviour
{
    public GunAudio[] audioList;

    private void Awake()
    {
        foreach(GunAudio gunAudio in audioList)
        {
            gunAudio.source = gameObject.AddComponent<AudioSource>();
            gunAudio.source.clip = gunAudio.clip;
        }
    }

    public void Play(string name)
    {
        GunAudio s = Array.Find(audioList, gunAudio => gunAudio.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
}
