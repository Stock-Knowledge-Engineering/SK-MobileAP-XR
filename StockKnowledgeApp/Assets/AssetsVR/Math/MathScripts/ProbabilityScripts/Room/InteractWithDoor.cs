using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithDoor : MonoBehaviour
{
    public RoomIntro room;

    public GameObject doorPuzzle;
    public GameObject points;

    public bool isChecked = false;

    public void OpenDoor()
    {
        if (!room.isKeyCollected)
        {
            room.audio.clip = room.needAKey;
            room.audio.Play();
        }
        else
        {
            if (!isChecked)
            {
                points.gameObject.SetActive(true);
                isChecked = true;
            }
            doorPuzzle.gameObject.SetActive(true);
            Invoke("DelayAudio", 0.5f);
        }
    }

    void DelayAudio()
    {
        room.audio.clip = room.aClueAnswer;
        room.audio.Play();
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
                    OpenDoor();
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
