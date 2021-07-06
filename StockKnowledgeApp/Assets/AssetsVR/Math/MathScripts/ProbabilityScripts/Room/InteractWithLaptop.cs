using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithLaptop : MonoBehaviour
{
    public RoomIntro room;

    public string displayLabel;

    public GameObject points;

    public GameObject wallpaper;
    public GameObject laptopScreen;

    public GameObject laptopCanvas;

    public AudioSource audio;

    public AudioClip buttonSound;

    public void SubmitPassword()
    {
        audio.clip = buttonSound;
        audio.Play();

        if (displayLabel == "1/1000")
        {
            points.gameObject.SetActive(true);
            wallpaper.SetActive(true);
            laptopScreen.SetActive(true);
            room.isLaptopUnlocked = true;

            StartCoroutine(HideCanvas());
        }
        else
        {
            displayLabel = "Incorrect Password";
        }
    }

    IEnumerator HideCanvas()
    {
        yield return new WaitForSeconds(1);
        room.audio.clip = room.vaultHint;
        room.audio.Play();

        yield return new WaitForSeconds(12);
        laptopCanvas.SetActive(false);
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
                    SubmitPassword();
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