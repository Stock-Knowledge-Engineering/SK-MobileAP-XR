using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCRTIntro : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] audioInfo = new AudioClip[2];

    // Start is called before the first frame update
    void Start()
    {
        audio.clip = audioInfo[0];
        audio.Play();
        Invoke("CloseIntro",32f);
    }


    // Update is called once per frame
    void CloseIntro()
    {
        audio.clip = audioInfo[1];
        audio.Play();
    }
}
