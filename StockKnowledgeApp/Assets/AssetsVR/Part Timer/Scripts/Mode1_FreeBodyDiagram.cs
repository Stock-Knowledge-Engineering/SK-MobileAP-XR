using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1_FreeBodyDiagramGaze : MonoBehaviour
{

    private Mode1_FreeBodyDiagramGameManager gameManager;
    private Mode1_FreeBodyDiagramModeManager modeManager;
    public int modeNumber;
    [Header("Gaze")]
    public ToggleTouchGaze ttg;

    public float gazeTimer;
    public Image radialImage;
    public bool isRadialFilled;
    public bool isObjectGazed;


    [Header("GameObject")]
    public bool isPoints;
    public bool isInteracted;

    public void Awake()
    {
        gameManager = FindObjectOfType<Mode1_FreeBodyDiagramGameManager>();
        modeManager = FindObjectOfType<Mode1_FreeBodyDiagramModeManager>();
        this.isInteracted = false;
    }
    public void Interacted()
    {
        if (!this.isInteracted)
        {
            gameManager.correctPoints.SetActive(true);
            this.isInteracted = true;
            gameManager.totalScore += 50;
        }
    }


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

                     Interacted();
                     modeManager._currentMode = modeNumber;

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
