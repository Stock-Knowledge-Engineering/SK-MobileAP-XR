 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeObjects : MonoBehaviour
{

    public string subject;
    public string topic;
    public string objectName;

    private Mode1_ConversionGameManager gameManager;
    [Header("Gaze")]
    public ToggleTouchGaze ttg;

    public float gazeTimer;
    public Image radialImage;
    public bool isRadialFilled;
    public bool isObjectGazed;


    [Header("GameObject")]
    public bool isPoints;
    public GameObject activeObject;
    public bool isActive;
    public bool isInteracted;

    public CurrentUser currentUser;
    private int numOfInteractables;

    public void Awake()
    {
        gameManager = FindObjectOfType<Mode1_ConversionGameManager>();
        this.isInteracted = false;
        /*  
        currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();*/
    }

    private void Start()
    {
/*        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
        numOfInteractables = interactables.Length;*/
    }

   public void Interacted()
    {
        if (!this.isInteracted)
        {
            gameManager.correctPoints.SetActive(true);
            this.isInteracted = true;
            gameManager.totalScore += 50;
/*
            currentUser.AddUserGamePoint(subject, topic, objectName, 50);

            //count interacted object in the scene
            int totalInteractedObject = currentUser.CountInteractedObject(topic);

            //Log Player Experience
            currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, subject, topic, 25);

            //Level Up Player
            currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);*/
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
                   
                    if (isActive)
                    {
                        activeObject.SetActive(true);
                        if (isPoints)
                        {
                            Interacted();
                        }
                    }
                    else
                    {
                        activeObject.SetActive(false);

                    }

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
