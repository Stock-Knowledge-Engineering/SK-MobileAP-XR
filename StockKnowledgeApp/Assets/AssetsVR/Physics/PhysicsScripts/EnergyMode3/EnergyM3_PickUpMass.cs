using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyM3_PickUpMass : MonoBehaviour
{
    public EnergyM3_RideManager rideManager;

    public Text txtInfo;
    public GameObject txtInfoBG;

    public bool isBasalt;
    public bool isObsidian;
    public bool isGranite;

    public void PickARock()
    {
        if (isBasalt)
        {
            rideManager.prob1Result = 1;
            StartCoroutine(rideManager.Problem1Results());
        }
        if (isObsidian)
        {
            rideManager.prob1Result = 2;
            StartCoroutine(rideManager.Problem1Results());
        }
        if (isGranite)
        {
            rideManager.prob1Result = 3;
            StartCoroutine(rideManager.Problem1Results());
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

        //shows object info
        if (isBasalt)
        {
            txtInfo.text = "50Kg Basalt";
            txtInfoBG.SetActive(true);
        }
        if (isObsidian)
        {
            txtInfo.text = "1Kg Obsidian";
            txtInfoBG.SetActive(true);
        }
        if (isGranite)
        {
            txtInfo.text = "10Kg Granite";
            txtInfoBG.SetActive(true);
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
                    PickARock();
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

        //reset text info
        txtInfo.text = "";
        txtInfoBG.SetActive(false);
    }
}
