using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1_FreeFallAudioManager : MonoBehaviour
{
    public GameObject btnFreeFall;
    public GameObject btnAirResistance;

    public AudioSource audio;

    public AudioClip woAirResistance;
    public AudioClip wAirResistance;
    public AudioClip notFalling;

    public Button freeFallButton;
    public Button airResistanceButton;

    public void StartAR()
    {
        StartCoroutine(StartFreefall());
    }

    public IEnumerator StartFreefall()
    {
        yield return new WaitForSeconds(7);
        btnFreeFall.gameObject.SetActive(true);
    }

    public IEnumerator FreefallPressed()
    {
        audio.clip = woAirResistance;
        audio.Play();
        yield return new WaitForSeconds(13);
        audio.clip = wAirResistance;
        audio.Play();
        yield return new WaitForSeconds(13);
        btnAirResistance.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        freeFallButton.interactable = true;
    }

    public IEnumerator AirResistancePressed()
    {
        yield return new WaitForSeconds(5);
        audio.clip = notFalling;
        audio.Play();
        yield return new WaitForSeconds(10);
        airResistanceButton.interactable = true;
    }
}
