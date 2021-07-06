using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPaperBox : MonoBehaviour
{
    public Probability2GameManager room;

    public bool isChecked;
    public GameObject points;

    public void StartPaperBox()
    {
        if (room.location == 6)
        {
            if (!isChecked)
            {
                points.gameObject.SetActive(true);
                room.numberCluesCollected += 1;
                isChecked = true;
            }
            if (room.isRoomOpen)
            {
                room.audio.clip = room.boxedNumbers;
                room.audio.Play();
            }
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
                    StartPaperBox();
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
