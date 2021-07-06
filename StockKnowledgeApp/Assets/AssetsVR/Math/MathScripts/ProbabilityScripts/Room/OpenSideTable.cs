using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenSideTable : MonoBehaviour
{
    public RoomIntro room;

    public Animator animator;

    public bool isOpened;

    public GameObject points;

    public void InteractWithSideTable()
    {
        if (!isOpened)
        {
            isOpened = true;
            animator.SetBool("isOpened", true);
            points.gameObject.SetActive(true);
            room.StartCoroutine(room.ShowVault());
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
            if (!isOpened)
            {
                isRadialFilled = false;
                isObjectGazed = true;
                Debug.Log("start gaze");
            }
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
                    InteractWithSideTable();
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
