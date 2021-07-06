using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GazeObject : MonoBehaviour
{

    public UnityEvent OnGaze;
    [Header("Gaze")]
    public ToggleTouchGaze ttg;
    public float gazeTime = 2f;

    private float gazeTimer;
    public Image radialImage;
    private bool isRadialFilled;
    private bool isObjectGazed;


    public virtual void GazeAtObject()
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
                radialImage.fillAmount = gazeTimer / gazeTime;

                if (gazeTimer >= gazeTime)
                {
                    isRadialFilled = true;
                    ResetProgress();
                    OnGaze.Invoke();
                }
            }
        }

    }

    public virtual void ResetProgress()
    {
        isObjectGazed = false;
        gazeTimer = 0f;
        radialImage.fillAmount = 0f;
        Debug.Log("reset gaze");
    }

}
