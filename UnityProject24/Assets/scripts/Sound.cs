using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;           // The name of the sound
    public AudioClip audioClip;   // The audio clip to be played
    [Range(0f, 1f)] public float volume; // Volume of the sound
    [Range(.1f, 3f)] public float pitch;  // Pitch of the sound
    public bool loop;             // Whether or not the sound should loop

    [HideInInspector] public AudioSource audioSource; // The audio source component attached to the AudioManager
}
