using UnityEngine.Audio;
using System;
using UnityEngine;

public class GunAudioManager : MonoBehaviour
{
    [SerializeField] private GunAudio[] audioList;
    [SerializeField] private AudioSource audioSource;


    public void Play(string name)
    {
        GunAudio s = Array.Find(audioList, gunAudio => gunAudio.name == name);
        if(s == null)
        {
            return;
        }
        audioSource.PlayOneShot(s.clip);
    }
}
