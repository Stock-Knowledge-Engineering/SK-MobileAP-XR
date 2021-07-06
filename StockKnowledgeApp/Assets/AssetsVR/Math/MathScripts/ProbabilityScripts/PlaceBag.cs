using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceBag : MonoBehaviour
{
    public ParkingManager parking;

    public GameObject bag;

    public GameObject points;

    public GameObject kidnapper1;
    public GameObject kidnapper2;

    public bool isBagPlaced;

    public void PlaceBagAtTrunk()
    {
        if (!isBagPlaced)
        {
            points.gameObject.SetActive(true);
            bag.gameObject.SetActive(true);
            StartCoroutine(ShowKidnapper());
            isBagPlaced = true;
        }
    }

    IEnumerator ShowKidnapper()
    {
        yield return new WaitForSeconds(1);
        parking.audio.clip = parking.sfxfootstep;
        parking.audio.Play();
        yield return new WaitForSeconds(1);
        kidnapper1.gameObject.SetActive(false);
        kidnapper2.gameObject.SetActive(true);
        parking.audio.clip = parking.anotherNoise;
        parking.audio.Play();
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
            if (!isBagPlaced)
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
                    PlaceBagAtTrunk();
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
