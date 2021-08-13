using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSedimentaryInfo : MonoBehaviour
{
    [Header("UI Canvas")]
    public GameObject infoUICanvas;
    public Text txtName;
    public Text txtDescription;
    public GameObject[] rockUI = new GameObject[9];
    //public Image imgPart;
    public GameObject complete;

    [Header("ScriptableObjects")]
    public SOSedimentaryRocks[] rockInfo = new SOSedimentaryRocks[9];

    [Header("Rocks")]
    public bool isSiltstone;
    public bool isShale;
    public bool isSandstone;
    public bool isRockSalt;
    public bool isLimestone;
    public bool isGypsum;
    public bool isDolomite;
    public bool isConglomerate;
    public bool isCoal;

    public SRGameManager sr;

    [Header("Audio")]
    public AudioSource audio;

    [Header("Points")]
    public bool isGraded;
    public GameObject pointsUI;
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

    public void ShowInfoPanel()
    {
        infoUICanvas.gameObject.SetActive(true);

        if (isSiltstone)
        {
            txtName.text = rockInfo[0].name;
            txtDescription.text = rockInfo[0].description;
            //imgPart.sprite = rockInfo[0].partImage;
            sr.isSiltstone = true;
            audio.clip = rockInfo[0].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Siltstone", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rockss", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[0].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8]};
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isShale)
        {
            txtName.text = rockInfo[1].name;
            txtDescription.text = rockInfo[1].description;
            //imgPart.sprite = rockInfo[1].partImage;
            sr.isShale = true;
            audio.clip = rockInfo[1].readDesc;
            audio.Play();
            if (!isGraded) {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Shale", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[1].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[0], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isSandstone)
        {
            txtName.text = rockInfo[2].name;
            txtDescription.text = rockInfo[2].description;
            //imgPart.sprite = rockInfo[2].partImage;
            sr.isSandstone = true;
            audio.clip = rockInfo[2].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Sandstone", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);


                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[2].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[0], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isRockSalt)
        {
            txtName.text = rockInfo[3].name;
            txtDescription.text = rockInfo[3].description;
            //imgPart.sprite = rockInfo[3].partImage;
            sr.isRockSalt = true;
            audio.clip = rockInfo[3].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Rock Salt", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);


                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[3].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[0], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isLimestone)
        {
            txtName.text = rockInfo[4].name;
            txtDescription.text = rockInfo[4].description;
            //imgPart.sprite = rockInfo[4].partImage;
            sr.isLimestone = true;
            audio.clip = rockInfo[4].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Limestone", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);


                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[4].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[0], rockUI[5], rockUI[6], rockUI[7], rockUI[8] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isGypsum)
        {
            txtName.text = rockInfo[5].name;
            txtDescription.text = rockInfo[5].description;
            //imgPart.sprite = rockInfo[5].partImage;
            sr.isGypsum = true;
            audio.clip = rockInfo[5].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Gypsum", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);


                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[5].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[0], rockUI[6], rockUI[7], rockUI[8] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isDolomite)
        {
            txtName.text = rockInfo[6].name;
            txtDescription.text = rockInfo[6].description;
            //imgPart.sprite = rockInfo[6].partImage;
            sr.isDolomite = true;
            audio.clip = rockInfo[6].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Dolomite", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);


                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[6].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[0], rockUI[7], rockUI[8] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isConglomerate)
        {
            txtName.text = rockInfo[7].name;
            txtDescription.text = rockInfo[7].description;
            //imgPart.sprite = rockInfo[7].partImage;
            sr.isConglomerate = true;
            audio.clip = rockInfo[7].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Conglomerate", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[7].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[0], rockUI[8] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isCoal)
        {
            txtName.text = rockInfo[8].name;
            txtDescription.text = rockInfo[8].description;
            //imgPart.sprite = rockInfo[8].partImage;
            sr.isCoal = true;
            audio.clip = rockInfo[8].readDesc;
            audio.Play();
            if (!isGraded)
            {
                currentUser.AddUserGamePoint("Earth-Science", "Types-Of-Sedimentary-Rocks", "Coal", 50);

                //count interacted object in the scene
                int totalInteractedObject = currentUser.CountInteractedObject("Types-Of-Sedimentary-Rocks");

                //Log Player Experience
                currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Earth-Science", "Types-Of-Sedimentary-Rocks", 25);

                //Level Up Player
                currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[8].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[0] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (sr.isSiltstone && sr.isShale && sr.isSandstone && sr.isRockSalt && sr.isLimestone && sr.isGypsum && sr.isDolomite && sr.isConglomerate && sr.isCoal)
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
                    ShowInfoPanel();
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
