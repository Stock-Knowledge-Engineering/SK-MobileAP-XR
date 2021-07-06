using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityIntro : MonoBehaviour
{
    public GameObject roomCasino;
    public GameObject roomParkingLot;
    public GameObject introCanvas;
    public GameObject parkingCanvas;
    public GameObject ftb;
    public GameObject ffb;

    public GameObject winningCard;

    public AudioSource audio;

    public AudioClip intro;
    public AudioClip tutorial;
    public AudioClip flip;

    public AudioClip won;
    public AudioClip congrats;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTutorial());
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(32);
        audio.clip = tutorial;
        audio.Play();

        yield return new WaitForSeconds(30);
        winningCard.SetActive(true);

        yield return new WaitForSeconds(2);
        audio.clip = flip;
        audio.Play();
    }

    public IEnumerator CardFlipped()
    {
        yield return new WaitForSeconds(2);
        audio.clip = won;
        audio.Play();

        yield return new WaitForSeconds(5);
        audio.clip = congrats;
        audio.Play();

        yield return new WaitForSeconds(4f);
        //inset fade to black
        ftb.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
        roomCasino.gameObject.SetActive(false);
        roomParkingLot.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        ftb.gameObject.SetActive(false);
        //inset fade from black
        ffb.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        introCanvas.gameObject.SetActive(false);
        ffb.gameObject.SetActive(false);
        parkingCanvas.gameObject.SetActive(true);
    }
}
