using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode1_ConversionSoundManager : MonoBehaviour
{

    [SerializeField]
    public Sound[] sounds;


    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }


        PlaySound("Introduction"); //Introduction first 10 Seconds 
    }
    public void PlaySound(string name) // Method used for playing a specific sound (Enter the name of the audio)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void StopSound(string name) // Method used for playing a specific sound (Enter the name of the audio)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

}

[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;
    [HideInInspector]
    public AudioSource source;
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}
