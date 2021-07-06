using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMetamorphicInfo : MonoBehaviour
{
    [Header("UI Canvas")]
    public GameObject infoUICanvas;
    public Text txtName;
    public Text txtDescription;
    public GameObject[] rockUI = new GameObject[10];
    //public Image imgPart;
    public GameObject complete;

    [Header("ScriptableObjects")]
    public SOMetamorphicRocks[] rockInfo = new SOMetamorphicRocks[10];

    [Header("Rocks")]
    public bool isSlate;
    public bool isSerpentinite;
    public bool isSchist;
    public bool isQuartzite;
    public bool isPhylite;
    public bool isMetaconglomerate;
    public bool isMarble;
    public bool isHornfels;
    public bool isGneiss;
    public bool isAnthracite;

    public MRGameManager mr;

    [Header("Audio")]
    public AudioSource audio;

    [Header("Points")]
    public bool isGraded;
    public GameObject pointsUI;

    public void ShowInfoPanel()
    {
        infoUICanvas.gameObject.SetActive(true);

        if (isSlate)
        {
            txtName.text = rockInfo[0].name;
            txtDescription.text = rockInfo[0].description;
            //imgPart.sprite = rockInfo[0].partImage;
            mr.isSlate = true;
            audio.clip = rockInfo[0].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[0].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isSerpentinite)
        {
            txtName.text = rockInfo[1].name;
            txtDescription.text = rockInfo[1].description;
            //imgPart.sprite = rockInfo[1].partImage;
            mr.isSerpentinite = true;
            audio.clip = rockInfo[1].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[1].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[0], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isSchist)
        {
            txtName.text = rockInfo[2].name;
            txtDescription.text = rockInfo[2].description;
            //imgPart.sprite = rockInfo[2].partImage;
            mr.isSchist = true;
            audio.clip = rockInfo[2].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[2].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[0], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isQuartzite)
        {
            txtName.text = rockInfo[3].name;
            txtDescription.text = rockInfo[3].description;
            //imgPart.sprite = rockInfo[3].partImage;
            mr.isQuartzite = true;
            audio.clip = rockInfo[3].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[3].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[0], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isPhylite)
        {
            txtName.text = rockInfo[4].name;
            txtDescription.text = rockInfo[4].description;
            //imgPart.sprite = rockInfo[4].partImage;
            mr.isPhylite = true;
            audio.clip = rockInfo[4].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[4].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[0], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isMetaconglomerate)
        {
            txtName.text = rockInfo[5].name;
            txtDescription.text = rockInfo[5].description;
            //imgPart.sprite = rockInfo[5].partImage;
            mr.isMetaconglomerate = true;
            audio.clip = rockInfo[5].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[5].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[0], rockUI[6], rockUI[7], rockUI[8], rockUI[9]};
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isMarble)
        {
            txtName.text = rockInfo[6].name;
            txtDescription.text = rockInfo[6].description;
            //imgPart.sprite = rockInfo[6].partImage;
            mr.isMarble = true;
            audio.clip = rockInfo[6].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[6].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[0], rockUI[7], rockUI[8], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isHornfels)
        {
            txtName.text = rockInfo[7].name;
            txtDescription.text = rockInfo[7].description;
            //imgPart.sprite = rockInfo[7].partImage;
            mr.isHornfels = true;
            audio.clip = rockInfo[7].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[7].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[0], rockUI[8], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isGneiss)
        {
            txtName.text = rockInfo[8].name;
            txtDescription.text = rockInfo[8].description;
            //imgPart.sprite = rockInfo[8].partImage;
            mr.isGneiss = true;
            audio.clip = rockInfo[8].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[8].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[0], rockUI[9] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isAnthracite)
        {
            txtName.text = rockInfo[9].name;
            txtDescription.text = rockInfo[9].description;
            //imgPart.sprite = rockInfo[9].partImage;
            mr.isAnthracite = true;
            audio.clip = rockInfo[9].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[9].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[0] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (mr.isSlate && mr.isSerpentinite && mr.isSchist && mr.isQuartzite && mr.isPhylite && mr.isMetaconglomerate && mr.isMarble && mr.isHornfels && mr.isGneiss && mr.isAnthracite)
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
