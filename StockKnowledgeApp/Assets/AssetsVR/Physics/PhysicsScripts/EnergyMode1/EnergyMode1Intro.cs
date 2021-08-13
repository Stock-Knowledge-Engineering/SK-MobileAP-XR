using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMode1Intro : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject btnRide;
    public GameObject btnStartRide;
    public GameObject imgComplete;

    public GameObject peEquation;
    public GameObject keEquation;
    public GameObject teEquation;

    public AudioSource audio;

    public AudioClip potential;
    public AudioClip kinetic;
    public AudioClip discussion;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEnergy());
        animator.GetComponent<Animator>();
    }

    IEnumerator StartEnergy()
    {
        yield return new WaitForSeconds(12);
        panelStart.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        btnRide.gameObject.SetActive(true);
    }

    public IEnumerator StartExperience()
    {
        yield return new WaitForSeconds(1);
        peEquation.gameObject.SetActive(true);
        audio.clip = potential;
        audio.Play();
        yield return new WaitForSeconds(9);
        peEquation.gameObject.SetActive(false);
        btnStartRide.gameObject.SetActive(true);
        btnRide.gameObject.SetActive(false);

    }

    public IEnumerator StartDiscussion()
    {
        animator.enabled = true;
        animator.SetBool("isAnimating", true);
        yield return new WaitForSeconds(1);
        audio.clip = kinetic;
        audio.Play();
        yield return new WaitForSeconds(3);
        keEquation.gameObject.SetActive(true);
        //btnStartRide.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        keEquation.gameObject.SetActive(false);
        audio.clip = discussion;
        audio.Play();
        yield return new WaitForSeconds(10);
        teEquation.gameObject.SetActive(true);
        yield return new WaitForSeconds(13);
        teEquation.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        imgComplete.gameObject.SetActive(true);
        //animator.enabled = false;
    }
}
