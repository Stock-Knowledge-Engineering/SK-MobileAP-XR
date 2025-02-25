﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopButtons : MonoBehaviour
{
    public InteractWithLaptop laptop;

    public string buttonValue;

    public Text txtLabel;

    public AudioSource audio;

    public AudioClip buttonSound;

    public void InputValue()
    {
        audio.clip = buttonSound;
        audio.Play();
        if (buttonValue != "X")
        {
            laptop.displayLabel += buttonValue;
        }
        else
        {
            laptop.displayLabel = "";
        }

    }


    private void Update()
    {
        txtLabel.text = laptop.displayLabel;
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
                    InputValue();
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
