using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] clip;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        Play(0);
    }

    // Update is called once per frame


    public void Play(int num)
    {
        audioSource.clip = clip[num];
        audioSource.volume = 1;
        audioSource.Play();
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.volume = 1;
        audioSource.Play();
    }
}
