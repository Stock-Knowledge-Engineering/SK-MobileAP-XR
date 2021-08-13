using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeMicroscope : MonoBehaviour
{
    public Animator animator;
    public bool isExploded;

    [Header("Microscope Parts")]
    public bool isBase;
    public bool isBody;
    public bool isCoarseFocus;
    public bool isCondenser;
    public bool isDiopterAdjust;
    public bool isFineFocus;
    public bool isIrisDiaphragm;
    public bool isLightSource;
    public bool isNosePiece;
    public bool isObjectiveLens;
    public bool isOcularLens;
    public bool isSlideHolder;
    public bool isStage;
    public bool isSwitch;

    public CurrentUser currentUser;
    private int numOfInteractables;

    public void Awake()
    {
        currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();
    }

    private void Start()
    {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
        numOfInteractables = interactables.Length;
    }

    public void ExplodeMS()
    {/*
        if (isExploded)
        {
            animator.SetBool("isClicked", false);
            isExploded = false;
        }
        
        else
        { */
            isExploded = true;
            animator.SetBool("isClicked", true);
        //}

        currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Microscope", 50);

        //count interacted object in the scene
        int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

        //Log Player Experience
        currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

        //Level Up Player
        currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

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

    void Update()
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
                    ExplodeMS();
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
