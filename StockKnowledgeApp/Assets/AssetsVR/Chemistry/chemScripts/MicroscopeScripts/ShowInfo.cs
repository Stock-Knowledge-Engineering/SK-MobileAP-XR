using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    public ExplodeMicroscope explodeMicroscope;

    [Header("UI Canvas")]
    public GameObject infoUICanvas;
    public Text txtName;
    public Text txtDescription;
    public Image imgPart;
    public GameObject complete;

    [Header("ScriptableObjects")]
    public MicroscopeComponents[] msPart = new MicroscopeComponents[15];

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
        if (explodeMicroscope.isExploded)
        {
            infoUICanvas.gameObject.SetActive(true);

            if (isBase)
            {
                txtName.text = msPart[1].name;
                txtDescription.text = msPart[1].description;
                imgPart.sprite = msPart[1].partImage;
                explodeMicroscope.isBase = true;
                audio.clip = msPart[1].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Base", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }    
            }

            if (isBody)
            {
                txtName.text = msPart[2].name;
                txtDescription.text = msPart[2].description;
                imgPart.sprite = msPart[2].partImage;
                explodeMicroscope.isBody = true;
                audio.clip = msPart[2].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Body", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isCoarseFocus)
            {
                txtName.text = msPart[3].name;
                txtDescription.text = msPart[3].description;
                imgPart.sprite = msPart[3].partImage;
                explodeMicroscope.isCoarseFocus = true;
                audio.clip = msPart[3].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Coarse-Focus", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isCondenser)
            {
                txtName.text = msPart[4].name;
                txtDescription.text = msPart[4].description;
                imgPart.sprite = msPart[4].partImage;
                explodeMicroscope.isCondenser = true;
                audio.clip = msPart[4].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Condenser", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isDiopterAdjust)
            {
                txtName.text = msPart[5].name;
                txtDescription.text = msPart[5].description;
                imgPart.sprite = msPart[5].partImage;
                explodeMicroscope.isDiopterAdjust = true;
                audio.clip = msPart[5].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Diopter-Adjust", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isFineFocus)
            {
                txtName.text = msPart[6].name;
                txtDescription.text = msPart[6].description;
                imgPart.sprite = msPart[6].partImage;
                explodeMicroscope.isFineFocus = true;
                audio.clip = msPart[6].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Fine-Focus", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isIrisDiaphragm)
            {
                txtName.text = msPart[7].name;
                txtDescription.text = msPart[7].description;
                imgPart.sprite = msPart[7].partImage;
                explodeMicroscope.isIrisDiaphragm = true;
                audio.clip = msPart[7].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Iris-Diaphragm", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isLightSource)
            {
                txtName.text = msPart[8].name;
                txtDescription.text = msPart[8].description;
                imgPart.sprite = msPart[8].partImage;
                explodeMicroscope.isLightSource = true;
                audio.clip = msPart[8].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Light-Source", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isNosePiece)
            {
                txtName.text = msPart[9].name;
                txtDescription.text = msPart[9].description;
                imgPart.sprite = msPart[9].partImage;
                explodeMicroscope.isNosePiece = true;
                audio.clip = msPart[9].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Nose-Piece", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isObjectiveLens)
            {
                txtName.text = msPart[10].name;
                txtDescription.text = msPart[10].description;
                imgPart.sprite = msPart[10].partImage;
                explodeMicroscope.isObjectiveLens = true;
                audio.clip = msPart[10].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Objective-Lens", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isOcularLens)
            {
                txtName.text = msPart[11].name;
                txtDescription.text = msPart[11].description;
                imgPart.sprite = msPart[11].partImage;
                explodeMicroscope.isOcularLens = true;
                audio.clip = msPart[11].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Ocular-Lens", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isSlideHolder)
            {
                txtName.text = msPart[12].name;
                txtDescription.text = msPart[12].description;
                imgPart.sprite = msPart[12].partImage;
                explodeMicroscope.isSlideHolder = true;
                audio.clip = msPart[12].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Slide-Holder", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isStage)
            {
                txtName.text = msPart[13].name;
                txtDescription.text = msPart[13].description;
                imgPart.sprite = msPart[13].partImage;
                explodeMicroscope.isStage = true;
                audio.clip = msPart[13].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Stage", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (isSwitch)
            {
                txtName.text = msPart[14].name;
                txtDescription.text = msPart[14].description;
                imgPart.sprite = msPart[14].partImage;
                explodeMicroscope.isSwitch = true;
                audio.clip = msPart[14].readDesc;
                audio.Play();
                if (!isGraded)
                {
                    currentUser.AddUserGamePoint("Chemistry", "Parts-of-Microscope", "Switch", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Parts-of-Microscope");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, "Chemistry", "Parts-of-Microscope", 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);

                    pointsUI.gameObject.SetActive(true);
                    isGraded = true;
                }
            }

            if (explodeMicroscope.isBase && explodeMicroscope.isBody && explodeMicroscope.isCoarseFocus &&
                explodeMicroscope.isCondenser && explodeMicroscope.isDiopterAdjust && explodeMicroscope.isFineFocus && 
                explodeMicroscope.isIrisDiaphragm && explodeMicroscope.isLightSource && explodeMicroscope.isNosePiece &&
                explodeMicroscope.isObjectiveLens && explodeMicroscope.isOcularLens && explodeMicroscope.isSlideHolder &&
                explodeMicroscope.isStage && explodeMicroscope.isSwitch)
            {
                Invoke("DelayComplete", 12.5f);
            }

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
