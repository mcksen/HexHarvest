using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private AudioClip clip;
    public AudioClip Clip => clip;

    [SerializeField] private string name;
    public string Name => name;

    [Range(0f, 1f)]
    [SerializeField] private float volume;
    public float Volume => volume;

    [Range(0.1f, 3f)]
    [SerializeField] private float pitch;
    public float Pitch => pitch;

    [SerializeField] private bool loop;
    public bool Loop => loop;
    [HideInInspector]
    public AudioSource source;


}
