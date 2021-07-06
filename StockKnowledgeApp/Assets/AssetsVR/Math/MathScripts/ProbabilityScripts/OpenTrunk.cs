using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenTrunk : MonoBehaviour
{
    public ParkingManager parking;

    public Animator animator;

    public bool isOpened;

    public GameObject points;

    public GameObject kidnapper;

    public void InteractWithTrunk()
    {
        if (!isOpened)
        {
            isOpened = true;
            points.gameObject.SetActive(true);
            animator.SetBool("isOpened", true);
            parking.audio.clip = parking.sfxtrunk;
            parking.audio.Play();
            StartCoroutine(ShowKidnapper());
        }
    }

    IEnumerator ShowKidnapper()
    {
        yield return new WaitForSeconds(2);
        kidnapper.gameObject.SetActive(true);
        parking.audio.clip = parking.sfxmetal;
        parking.audio.Play();

        yield return new WaitForSeconds(1);
        parking.audio.clip = parking.whatWasThat;
        parking.audio.Play();
    }

    [Header("Gaze")]
    public ToggleTouchGaze ttg;

    public float gazeTimer;
    public Image radialImage;
    public bool isRadialFilled;
    public bool isObjectGazed;

    public void GazeAtObject()
    {
        if (ttg.isGaze)
        {
            if (!isOpened)
            {
                isRadialFilled = false;
                isObjectGazed = true;
                Debug.Log("start gaze");
            }
        }

    }

    void LateUpdate()
    {
        if (isObjectGazed)
        {
            if (!isRadialFilled)
            {
                Debug.Log("Loading gaze");
                gazeTimer += Time.deltaTime;
                radialImage.fillAmount = gazeTimer / 2;

                if (gazeTimer >= 2)
                {
                    isRadialFilled = true;
                    ResetProgress();
                    Debug.Log("end gaze");
                    InteractWithTrunk();
                }
            }
        }

    }

    public void ResetProgress()
    {
        isObjectGazed = false;
        gazeTimer = 0f;
        radialImage.fillAmount = 0f;
        Debug.Log("reset gaze");
    }
}
