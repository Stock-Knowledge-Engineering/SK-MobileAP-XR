using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyM3_RideManager : MonoBehaviour
{
    public GameObject points;

    public Animator animator;

    public AudioSource audioSource;
    public AudioClip problem1;
    public AudioClip problem2;
    public AudioClip problem3;
    public AudioClip voiceFill;
    public AudioClip voiceIncorrect;
    public AudioClip voiceEnd;


    public GameObject objNeedle;

    public GameObject panelProblem1;
    public GameObject panelProblem1Visuals;
    public GameObject panelProblem2;
    public GameObject panelProblem2Visuals;
    public GameObject panelProblem3;
    public GameObject panelProblem3Visuals;

    public GameObject panelRetry;
    public GameObject panelComplete;

    public int prob1Result;
    public int prob2Result;
    public int prob3Result;

    public bool isProb2;
    public bool isProb3;

    public GameObject prob1Blocker;
    public GameObject speedometerImageBlocker;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RideConditions());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RideConditions()
    {
        yield return new WaitForSeconds(21);
        audioSource.clip = problem1;
        audioSource.Play();
        yield return new WaitForSeconds(5);
        objNeedle.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - 50f);
        yield return new WaitForSeconds(15);
        panelProblem1.gameObject.SetActive(true);
        animator.StopPlayback();
    }

    public IEnumerator Problem1Results()
    {
        audioSource.clip = voiceFill;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        panelProblem1Visuals.gameObject.SetActive(false);
        prob1Blocker.gameObject.SetActive(true);
        switch (prob1Result)
        {
            case 1:
                animator.Play("energy3_Motion2");
                yield return new WaitForSeconds(7f);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                panelRetry.gameObject.SetActive(true);
                break;
            case 2:
                animator.Play("energy3_Motion1");
                yield return new WaitForSeconds(2f);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                panelRetry.gameObject.SetActive(true);
                break;
            case 3:
                animator.Play("energy3_Motion3");
                yield return new WaitForSeconds(2.5f);
                Debug.Log("points");
                points.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                objNeedle.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 50f);
                audioSource.clip = problem2;
                audioSource.Play();
                yield return new WaitForSeconds(3);
                panelProblem2.gameObject.SetActive(true);         
                yield return new WaitForSeconds(8);
                speedometerImageBlocker.gameObject.SetActive(false);
                panelProblem1.gameObject.SetActive(false);
                break;
        }
        
    }

    public IEnumerator Problem2Results()
    {
        audioSource.clip = voiceFill;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        panelProblem2Visuals.gameObject.SetActive(false);
        switch (prob2Result)
        {
            case 5:
                animator.Play("energy3_P2Motion2");
                yield return new WaitForSeconds(4.2f);
                panelRetry.gameObject.SetActive(true);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                break;
            case 6:
                animator.Play("energy3_P2Motion3");
                yield return new WaitForSeconds(2f);
                Debug.Log("points");
                points.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                objNeedle.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 50f);
                audioSource.clip = problem3;
                audioSource.Play();
                yield return new WaitForSeconds(3);
                panelProblem3.gameObject.SetActive(true);
                yield return new WaitForSeconds(8);
                isProb2 = false;
                isProb3 = true;
                speedometerImageBlocker.gameObject.SetActive(false);
                panelProblem2.gameObject.SetActive(false);
                break;
            default:
                animator.Play("energy3_P2Motion1");
                yield return new WaitForSeconds(1.8f);
                panelRetry.gameObject.SetActive(true);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                break;
        }

    }

    public IEnumerator Problem3Results()
    {
        audioSource.clip = voiceFill;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        panelProblem3Visuals.gameObject.SetActive(false);
        switch (prob2Result)
        {
            case 5:
                animator.Play("energy3_P3Motion2");
                yield return new WaitForSeconds(4.2f);
                panelRetry.gameObject.SetActive(true);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                break;
            case 6:
                animator.Play("energy3_P3Motion2");
                yield return new WaitForSeconds(4.2f);
                panelRetry.gameObject.SetActive(true);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                break;
            case 7:
                animator.Play("energy3_P3Motion2");
                yield return new WaitForSeconds(4.2f);
                panelRetry.gameObject.SetActive(true);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                break;
            case 8:
                animator.Play("energy3_P3Motion3");
                yield return new WaitForSeconds(2f);
                Debug.Log("points");
                points.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                audioSource.clip = voiceEnd;
                audioSource.Play();
                yield return new WaitForSeconds(2);
                panelComplete.gameObject.SetActive(true);
                break;
            default:
                animator.Play("energy3_P3Motion1");
                yield return new WaitForSeconds(1.8f);
                panelRetry.gameObject.SetActive(true);
                audioSource.clip = voiceIncorrect;
                audioSource.Play();
                break;
        }

    }
}
