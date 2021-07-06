using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BegginCTRMagnetExperiment : MonoBehaviour
{
    public GameObject previousPanel;
    public GameObject thisObject;
    public GameObject nextObject;

    public GameObject pointsUI;
    public bool isGraded;

    public void BegginExperiemt()
    {
        nextObject.gameObject.SetActive(true);
        thisObject.gameObject.SetActive(false);
        previousPanel.gameObject.SetActive(false);
        if (!isGraded)
        {
            pointsUI.gameObject.SetActive(true);
            isGraded = true;
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
                    BegginExperiemt();
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
