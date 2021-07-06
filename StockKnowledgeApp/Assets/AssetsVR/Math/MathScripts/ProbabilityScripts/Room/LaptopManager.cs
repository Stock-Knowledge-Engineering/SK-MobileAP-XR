using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopManager : MonoBehaviour
{
    public RoomIntro room;

    public GameObject laptopCanvas;

    public GameObject points;

    public void ShowLaptopCanvas()
    {
        if (!room.isLaptopUnlocked)
        {
            laptopCanvas.gameObject.SetActive(true);
            points.SetActive(true);
            room.audio.clip = room.laptopHint;
            room.audio.Play();
        }
        else
        {
            room.audio.clip = room.vaultHint;
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
                    ShowLaptopCanvas();
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
