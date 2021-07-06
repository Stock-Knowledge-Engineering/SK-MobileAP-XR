/****************************************************************************************************************************************************************************************************************
 * 
 * CR:
 * *** Using a standard deck of cards, determine the probability of face cards.
 * *** FaceCard = 3/13
 * 
 * Storage:
 * *** The number “1” in a die is changed to a “2” so that there are now two 2’s on the die. What is the probability of getting a multiple of 2, if this die is rolled once?
 * *** Multiple of 2 = 2/3
 * 
 * Room2:
 * *** A purse contains nine 5-peso coins and seven 10-peso coins. If 3 coins are drawn at random, what is the probability that one is a 5-peso coin and two are 10-peso coins?
 * *** one is a 5-peso coin and two are 10-peso coins = 27/80
 * 
 * Exit:
 * *** The numbers 1, 2, . . . , 49, 50 are written on a slips of paper, placed in a box and mixed thoroughly. Two numbers are drawn together at random. What is the probability that both numbers drawn are divisible by 5
 * *** Both numbers drawn are divisible by 5. There are 10 numbers divisible by 5.
 * *** C(10,2) = 45
 * *** 45/1225
 * *** 9/245
 * 
****************************************************************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenRoomDoors : MonoBehaviour
{
    public  Probability2GameManager room;

    public string displayLabel;

    public Animator animatorKnob;

    public GameObject points;

    public GameObject doorCanvas;

    public GameObject endCanvas;

    public bool isOpened;

    public bool isCR;
    public bool isStorage;
    public bool isRoom2;
    public bool isExit;

    //for the door
    public Animator doorAnimator;

    public void CheckAnswer()
    {
        animatorKnob.SetBool("isTurned", true);
        Invoke("SetToFalse", 0.8f);

        if (isCR)
        {
            if (displayLabel == "3/13")
            {
                if (!isOpened)
                {
                    points.gameObject.SetActive(true);
                    isOpened = true;
                    room.isCROpen = true;
                }
                displayLabel = "OPEN";
                Invoke("HideDoorCanvas", 1f);
                Invoke("DelayDoorAnimation", 1f);
            }
            else
            {
                displayLabel = "ERROR";
            }
        }

        if (isStorage)
        {
            if (displayLabel == "2/3")
            {
                if (!isOpened)
                {
                    points.gameObject.SetActive(true);
                    isOpened = true;
                    room.isStorageOpen = true;
                }
                displayLabel = "OPEN";
                Invoke("HideDoorCanvas", 1f);
                Invoke("DelayDoorAnimation", 1f);
            }
            else
            {
                displayLabel = "ERROR";
            }
        }

        if (isRoom2)
        {
            if (displayLabel == "27/80")
            {
                if (!isOpened)
                {
                    points.gameObject.SetActive(true);
                    isOpened = true;
                    room.isRoomOpen = true;
                }
                displayLabel = "OPEN";
                Invoke("HideDoorCanvas", 1f);
                Invoke("DelayDoorAnimation", 1f);
            }
            else
            {
                displayLabel = "ERROR";
            }
        }

        if (isExit)
        {
            if (displayLabel == "9/245")
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
    }

    void SetToFalse()
    {
        animatorKnob.SetBool("isTurned", false);
    }
    void HideDoorCanvas()
    {
        doorCanvas.gameObject.SetActive(false);
    }
    void ShowMessage()
    {
        doorCanvas.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(true);
    }
    void DelayDoorAnimation()
    {
        doorAnimator.SetBool("isOpen", true);
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
                    CheckAnswer();
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
