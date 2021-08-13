using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class HomeBtn : MonoBehaviour
{
    public ToggleTouchGaze ttg;

    public DataManager dataManager;
    public string levelName;
    public float timeAtLevel;

    public bool isTimerRunning;

    public Text levelTime;

    [Header("scene to load")]
    public string sceneToLoad;

    private void Start()
    {
        //for analytics
        dataManager.Load();
    }

    private void Update()
    {
        //for analytics
        if (isTimerRunning)
        {
            timeAtLevel += Time.deltaTime;
        }
        else{
            TimeFormat();
        }
        
    }

    void TimeFormat()
    {
        float seconds = timeAtLevel % 60;
        float minutes = timeAtLevel / 60;
        string time = (minutes < 10 ? "0" : "") + (int)minutes + ":" + (seconds < 10 ? "0" : "") + (int)seconds;
        levelTime.text = time;
    }

    public void BtnHome()
    {
        //delays calling the home scene to disable vr mode and return to panorama mode
        StartCoroutine(LoadHome());

        //for analytics
        dataManager.data.timeData += "Mode: " + levelName + " Time Spent: " +timeAtLevel + "\n";
        dataManager.Save();
    }

    IEnumerator LoadHome()
    {
        XRSettings.LoadDeviceByName("");

        yield return new WaitForSeconds(0.5f);
        //insert scene to load
        SceneManager.LoadScene(sceneToLoad);
    }

    [Header("for gaze controller")]
    //for gaze controller
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
                    BtnHome();
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
