using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RideCart : MonoBehaviour
{
    public EnergyMode1Intro energy1;

    public GameObject player;
    public GameObject ftb;
    public GameObject ffb;

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
    }

    public void BtnRidePressed()
    {
        StartCoroutine(Blink());
        
    }

    IEnumerator Blink()
    {
        points.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        ftb.SetActive(true);
        yield return new WaitForSeconds(1);
        ftb.SetActive(false);

        player.transform.position = new Vector3(0f, 1.75f, -0.4f);

        ffb.SetActive(true);
        yield return new WaitForSeconds(1);
        ffb.SetActive(false);

        StartCoroutine(energy1.StartExperience());
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
            Debug.Log("total interacted: " + totalInteractedObject);
            Debug.Log("num of interactable: " + numOfInteractables);
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
                    BtnRidePressed();
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