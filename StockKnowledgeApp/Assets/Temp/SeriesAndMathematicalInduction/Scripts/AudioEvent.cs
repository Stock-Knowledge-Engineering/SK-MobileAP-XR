using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEvent : MonoBehaviour
{
    public AudioClip clip;
    public bool disableWhenDone;
    public float delay = 0.5f;
    public GameObject[] enableObjectsWhenStarted;
    public GameObject[] enablesObjectWhenDone;
    public UnityEvent onEnabled;
    public UnityEvent onAudioEnd;

    public AudioEventTimeTrigger[] timeTriggers;
    AudioSource audioSource;
    

    void OnEnable(){
        audioSource = FXSoundSystem.Instance.PlaySoundDelayed(clip, delay);
        StartCoroutine(TriggerOnAudioEnd(audioSource));

        foreach (AudioEventTimeTrigger timeTrigger in timeTriggers) {
            StartCoroutine(ActivateTrigger(timeTrigger)); 
        }

        foreach (GameObject enableObject in enableObjectsWhenStarted) {
            enableObject.SetActive(true);
        }
        onEnabled.Invoke();
    }

    private IEnumerator ActivateTrigger(AudioEventTimeTrigger timeTrigger)
    {
        yield return new WaitForSeconds(timeTrigger.timeInSeconds);
        timeTrigger.Trigger();
    }

    private IEnumerator TriggerOnAudioEnd(AudioSource audioSource)
    {
        while (audioSource.isPlaying){
            if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
                yield return new WaitForSeconds(0.2f);
                // Skip all coroutines
                foreach (AudioEventTimeTrigger timeTrigger in timeTriggers) {
                    timeTrigger.Trigger();
                }
                audioSource.Stop();
                StopAllCoroutines();
                break;
            }
            yield return null;
        }
        onAudioEnd.Invoke();
        foreach(GameObject obj in enablesObjectWhenDone) obj.SetActive(true);
        if (disableWhenDone) gameObject.SetActive(false);
    }

}

[System.Serializable]
public class AudioEventTimeTrigger {
    public float timeInSeconds;
    public UnityEvent triggerEvent;

    public void Trigger(){
        triggerEvent.Invoke();
    }
}
