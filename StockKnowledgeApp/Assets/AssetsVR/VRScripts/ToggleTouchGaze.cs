using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTouchGaze : MonoBehaviour
{
    public Button btnToggle;
    public Sprite touchIcon;
    public Sprite gazeIcon;

    public bool isGaze = false;

    // Start is called before the first frame update
    void Awake()
    {
        //PlayerPrefs.GetInt("p_toggleInteract");
        btnToggle = GetComponent<Button>();
        switch (PlayerPrefs.GetInt("p_toggleView"))
        {
            case 1:
                btnToggle.image.sprite = touchIcon;
                isGaze = true;
                break;
            default:
                btnToggle.image.sprite = gazeIcon;
                isGaze = false;
                break;
        }
    }

    public void Toggle()
    {
        switch (PlayerPrefs.GetInt("p_toggleView"))
        {
            case 1:
                btnToggle.image.sprite = gazeIcon;
                isGaze = false;
                PlayerPrefs.SetInt("p_toggleView", 0);
                break;
            default:
                btnToggle.image.sprite = touchIcon;
                isGaze = true;
                PlayerPrefs.SetInt("p_toggleView", 1);
                break;
        }
        PlayerPrefs.Save();

    }

    //for gaze controller
    public float gazeTimer;
    public Image radialImage;
    public bool isRadialFilled;
    public bool isObjectGazed;

    public void GazeAtObject()
    {
        if (isGaze)
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
                    Toggle();
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
