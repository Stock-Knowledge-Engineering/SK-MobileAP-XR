using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MillikansPlayAudioInfo : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip audioInfo;

    public bool IsAtomizer;
    public bool IsXray;
    public bool IsOil;
    public bool IsPlates;
    public bool IsEyePiece;
    public bool IsHole;

    [Header("Points")]
    public bool isGraded;
    public GameObject pointsUI;
    public MillikansComplete mc;
    public GameObject complete;

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

    public void PlayInfo()
    {
        if (IsAtomizer)
        {
            audio.clip = audioInfo;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Chemistry", "Millikans-Experiment", "Atomizer", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Millikans-Experiment");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Millikans-Experiment", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
                mc.TotalScore += 1;
            }
        }

        if (IsXray)
        {
            audio.clip = audioInfo;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Chemistry", "Millikans-Experiment", "Xray", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Millikans-Experiment");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Millikans-Experiment", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
                mc.TotalScore += 1;
            }
        }

        if (IsOil)
        {
            audio.clip = audioInfo;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Chemistry", "Millikans-Experiment", "Oil", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Millikans-Experiment");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Millikans-Experiment", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
                mc.TotalScore += 1;
            }
        }

        if (IsPlates)
        {
            audio.clip = audioInfo;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Chemistry", "Millikans-Experiment", "Plates", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Millikans-Experiment");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Millikans-Experiment", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
                mc.TotalScore += 1;
            }
        }

        if (IsEyePiece)
        {
            audio.clip = audioInfo;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Chemistry", "Millikans-Experiment", "Eye Piece", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Millikans-Experiment");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Millikans-Experiment", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
                mc.TotalScore += 1;
            }
        }

        if (IsHole)
        {
            audio.clip = audioInfo;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Chemistry", "Millikans-Experiment", "Hole", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Millikans-Experiment");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Millikans-Experiment", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
                mc.TotalScore += 1;
            }
        }

        if(mc.TotalScore >= 6)
        {
            Invoke("DelayComplete", 12.5f);
        }
    }

    void DelayComplete()
    {
        complete.gameObject.SetActive(true);
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
                    PlayInfo();
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
