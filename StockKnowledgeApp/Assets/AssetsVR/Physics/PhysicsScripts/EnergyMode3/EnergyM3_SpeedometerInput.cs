using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyM3_SpeedometerInput : MonoBehaviour
{
    public EnergyM3_RideManager rideManager;

    public int speedValue;
    public float transformValue;

    public AudioSource audio;
    public AudioClip buttonSound;

    public GameObject imageBlocker;



    public void EnterSpeedValue()
    {
        if (rideManager.isProb2)
        {
            audio.clip = buttonSound;
            audio.Play();
            rideManager.objNeedle.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - transformValue);
            rideManager.prob2Result = speedValue;
            imageBlocker.gameObject.SetActive(true);
            StartCoroutine(rideManager.Problem2Results());
        }
        if (rideManager.isProb3)
        {
            audio.clip = buttonSound;
            audio.Play();
            rideManager.objNeedle.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - transformValue);
            rideManager.prob2Result = speedValue;
            imageBlocker.gameObject.SetActive(true);
            StartCoroutine(rideManager.Problem3Results());
        }

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
            isRadialFilled = false;
            isObjectGazed = true;
            Debug.Log("start gaze");
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
                    EnterSpeedValue();
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