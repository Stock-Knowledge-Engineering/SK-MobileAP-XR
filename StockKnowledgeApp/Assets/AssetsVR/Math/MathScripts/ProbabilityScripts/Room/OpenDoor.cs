/*************************************************************************************************
 * 
 * Fifteen people sit around a circular table. What are odds against two particular people sitting together?
 * 
 * Sol: 15 persons can be seated in 14! Ways. No. of ways in which two particular people sit together is 13! × 2!
 * 
 * The probability of two particular persons sitting together 13!2! / 14! = 1/7
 * 
 * Odds against the event = 6 : 1
 * 
*************************************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public HomeBtn home;

    public RoomIntro room;

    public string displayLabel;

    public Animator animatorKnob;

    public GameObject points;

    public GameObject doorCanvas;

    public GameObject endCanvas;

    public bool isOpened;

    public void EndLevel()
    {
        animatorKnob.SetBool("isTurned", true);
        Invoke("SetToFalse", 0.8f);
        if (displayLabel == "2/14" || displayLabel == "1/7")
        {
            if (!isOpened)
            {
                points.gameObject.SetActive(true);
                isOpened = true;
            }
            displayLabel = "OPEN";

            Invoke("ShowMessage", 2f);
        }
        else
        {
            displayLabel = "ERROR";
        }
    }

    void SetToFalse()
    {
        animatorKnob.SetBool("isTurned", false);
    }

    void ShowMessage()
    {
        doorCanvas.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(true);
        home.isTimerRunning = false;
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
                    EndLevel();
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
