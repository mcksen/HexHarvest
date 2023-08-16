using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] Sound[] sounds;


    void Awake()
    {

        instance = this;
        foreach (Sound i in sounds)
        {
            i.source = gameObject.AddComponent<AudioSource>();
            i.source.clip = i.Clip;
            i.source.volume = i.Volume;
            i.source.pitch = i.Pitch;
            i.source.loop = i.Loop;

        }

    }


    public void Play(string name)
    {

        Sound i = Array.Find(sounds, sound => sound.Name == name);

        if (i.Name != null)
        {
            i.source.Play();

        }
    }
    public void Pause(string name)
    {
        Sound i = Array.Find(sounds, sound => sound.Name == name);
        if (i.Name != null)
        {
            i.source.Pause();

        }
    }

    public void UnPause(string name)
    {
        foreach (Sound i in sounds)
        {
            if (i.Name != null)
            {
                i.source.UnPause();
            }
        }
    }
    public void StopAllAudio()
    {
        foreach (Sound i in sounds)
        {
            if (i.source.isPlaying)
            {
                i.source.Stop();
            }
        }

    }
    public void PlayDelayed(string name)
    {

        Sound i = Array.Find(sounds, sound => sound.Name == name);

        if (i.Name != null)
        {
            i.source.PlayDelayed(2);

        }
    }
}
