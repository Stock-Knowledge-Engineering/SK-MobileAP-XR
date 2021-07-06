using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithVault : MonoBehaviour
{
    public RoomIntro room;

    public string displayLabel;

    public Animator animatorKnob;

    public Animator animatorVaultDoor;

    public GameObject points;

    public GameObject vaultCanvas;
    public GameObject vaultKnob;
   
    public void StartVault()
    {
        animatorKnob.SetBool("isTurned", true);
        Invoke("SetToFalse",0.8f);
        if(displayLabel == "2/36" || displayLabel == "1/18")
        {
            points.gameObject.SetActive(true);
            displayLabel = "OK";
            //openVault
            room.isVaultDoorOpen = true;
            Invoke("HideCanvas",1f);
        }
        else
        {
            displayLabel = "ERROR";
        }
    }

    void SetToFalse()
    {
        animatorKnob.SetBool("isTurned", false);
    }

    void HideCanvas()
    {
        animatorVaultDoor.SetBool("isOpened", true);
        vaultCanvas.SetActive(false);
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
                    StartVault();
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
