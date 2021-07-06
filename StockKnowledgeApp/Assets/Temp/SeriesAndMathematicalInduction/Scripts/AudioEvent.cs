using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AudioEvent : MonoBehaviour
{
    public AudioClip clip;
    public bool disableWhenDone;
    public GameObject[] enablesObjectWhenDone;
    public UnityEvent onAudioEnd;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = FXSoundSystem.Instance.PlaySound(clip);
        StartCoroutine(TriggerOnAudioEnd(audioSource));
    }

    private IEnumerator TriggerOnAudioEnd(AudioSource audioSource)
    {
        while (audioSource.isPlaying){
            if (Input.GetKeyUp(KeyCode.KeypadEnter)) {
                // Skip
                break;
            }
            yield return null;
        } 
        onAudioEnd.Invoke();
        if (disableWhenDone) gameObject.SetActive(false);
        foreach(GameObject obj in enablesObjectWhenDone) obj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
