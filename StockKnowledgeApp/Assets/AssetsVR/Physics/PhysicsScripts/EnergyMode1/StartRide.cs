using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRide : MonoBehaviour
{
    public EnergyMode1Intro energy1;

    public GameObject points;

    public CurrentUser currentUser;
    private int numOfInteractables;

    public string subject;
    public string topic;
    public string objectName;

    public void Awake()
    {
        currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();
    }

    private void Start()
    {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
        numOfInteractables = interactables.Length;

        Debug.Log("number of interactables: " + numOfInteractables);
    }

    public void BtnStartPressed()
    {
        points.gameObject.SetActive(true);
        StartCoroutine(energy1.StartDiscussion());
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

            currentUser.AddUserGamePoint(subject, topic, objectName, 50);

            //count interacted object in the scene
            int totalInteractedObject = currentUser.CountInteractedObject(topic);

            //Log Player Experience
            currentUser.AddPlayerExperience(totalInteractedObject, 2, subject, topic, 25);

            //Level Up Player
            currentUser.PlayerLevelUp(totalInteractedObject, 2);
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
                    BtnStartPressed();
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