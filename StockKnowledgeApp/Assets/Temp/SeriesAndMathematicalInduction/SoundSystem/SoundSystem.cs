using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundSystem : MonoBehaviour
{
    public AudioClip[] audioList;
    protected AudioSource audioSource;

    protected static SoundSystem _instance;
    public static SoundSystem Instance { get { return _instance; } }

    protected AudioClip initClip;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        if (_instance == null) {
            _instance = this;
            audioSource = GetComponent<AudioSource>();
            OnStart();
        }
        else {
            Destroy(this.gameObject);
        }        
    }


    public virtual void OnStart() { 
        initClip = audioSource.clip;
    }
    public void PlayAudioInList(int index){
        PlaySoundOneShot(audioList[index]);
    }

    public void PlaySoundOneShot(AudioClip audioClip, float volume = 1f) {
        audioSource.PlayOneShot(audioClip, volume);
    }
    public AudioSource PlaySound(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.Play();
        return audioSource;
    }
    public void PlayLooped(AudioClip audioClip, float delay = 0, float volume = 1) {
        audioSource.clip = audioClip;
        audioSource.PlayDelayed(delay);
        audioSource.loop = true;
        audioSource.volume = volume;
    }
    public void PlaySoundDelayed(AudioClip audioClip, float delay) {
        audioSource.clip = audioClip;
        audioSource.PlayDelayed(delay);
    }


    public void SetSoundVolume(float value) {
        audioSource.volume = value;
    }

    public void AddPitch(float value) {
        audioSource.pitch += value;
    }

    public void SetPitch(float value) {
        audioSource.pitch = value;

    }

    public float GetCurrentVolume() {
        return audioSource.volume;
    }

    public void Stop() {
        audioSource.loop = false;
        audioSource.Stop();
    }
}