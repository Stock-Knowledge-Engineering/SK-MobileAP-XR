using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateExitDoor : MonoBehaviour
{
    public Probability2GameManager room;

    public GameObject doorLock;

    public void ActivateDoor()
    {
        if (room.location == 4 && room.numberCluesCollected == 3)
        {
            doorLock.gameObject.SetActive(true);
            room.audio.clip = room.lastClue;
            room.audio.Play();
        }
        else if (room.location == 4 && room.numberCluesCollected != 3)
        {
            room.audio.clip = room.noClue;
            room.audio.Play();
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
                    ActivateDoor();
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