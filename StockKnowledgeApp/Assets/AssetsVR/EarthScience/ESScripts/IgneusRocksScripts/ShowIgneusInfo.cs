using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowIgneusInfo : MonoBehaviour
{
    [Header("UI Canvas")]
    public GameObject infoUICanvas;
    public Text txtName;
    public Text txtDescription;
    public GameObject[] rockUI = new GameObject[12];
    //public Image imgPart;
    public GameObject complete;

    [Header("ScriptableObjects")]
    public SOIgneusRocks[] rockInfo = new SOIgneusRocks[12];

    [Header("Rocks")]
    public bool isTuff;
    public bool isScoria;
    public bool isRhyolite;
    public bool isPumice;
    public bool isPeriodotite;
    public bool isPegmatite;
    public bool isObsidian;
    public bool isGranite;
    public bool isGabbro;
    public bool isDiorite;
    public bool isBasalt;
    public bool isAndesite;

    public IRGameManager ir;

    [Header("Audio")]
    public AudioSource audio;

    [Header("Points")]
    public bool isGraded;
    public GameObject pointsUI;

    public void ShowInfoPanel()
    {
        infoUICanvas.gameObject.SetActive(true);

        if (isTuff)
        {
            txtName.text = rockInfo[0].name;
            txtDescription.text = rockInfo[0].description;
            //imgPart.sprite = rockInfo[0].partImage;
            ir.isTuff = true;
            audio.clip = rockInfo[0].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[0].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] {rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for(int i=0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isScoria)
        {
            txtName.text = rockInfo[1].name;
            txtDescription.text = rockInfo[1].description;
            //imgPart.sprite = rockInfo[1].partImage;
            ir.isScoria = true;
            audio.clip = rockInfo[1].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[1].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[0], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isRhyolite)
        {
            txtName.text = rockInfo[2].name;
            txtDescription.text = rockInfo[2].description;
            //imgPart.sprite = rockInfo[2].partImage;
            ir.isRhyolite = true;
            audio.clip = rockInfo[2].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[2].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[0], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isPumice)
        {
            txtName.text = rockInfo[3].name;
            txtDescription.text = rockInfo[3].description;
            //imgPart.sprite = rockInfo[3].partImage;
            ir.isPumice = true;
            audio.clip = rockInfo[3].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[3].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[0], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isPeriodotite)
        {
            txtName.text = rockInfo[4].name;
            txtDescription.text = rockInfo[4].description;
            //imgPart.sprite = rockInfo[4].partImage;
            ir.isPeriodotite = true;
            audio.clip = rockInfo[4].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[4].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[0], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isPegmatite)
        {
            txtName.text = rockInfo[5].name;
            txtDescription.text = rockInfo[5].description;
            //imgPart.sprite = rockInfo[5].partImage;
            ir.isPegmatite = true;
            audio.clip = rockInfo[5].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[5].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[0], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isObsidian)
        {
            txtName.text = rockInfo[6].name;
            txtDescription.text = rockInfo[6].description;
            //imgPart.sprite = rockInfo[6].partImage;
            ir.isObsidian = true;
            audio.clip = rockInfo[6].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[6].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[0], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isGranite)
        {
            txtName.text = rockInfo[7].name;
            txtDescription.text = rockInfo[7].description;
            //imgPart.sprite = rockInfo[7].partImage;
            ir.isGranite = true;
            audio.clip = rockInfo[7].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[7].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[0], rockUI[8], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isGabbro)
        {
            txtName.text = rockInfo[8].name;
            txtDescription.text = rockInfo[8].description;
            //imgPart.sprite = rockInfo[8].partImage;
            ir.isGabbro = true;
            audio.clip = rockInfo[8].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[8].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[0], rockUI[9], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isDiorite)
        {
            txtName.text = rockInfo[9].name;
            txtDescription.text = rockInfo[9].description;
            //imgPart.sprite = rockInfo[9].partImage;
            ir.isDiorite = true;
            audio.clip = rockInfo[9].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[9].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[0], rockUI[10], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isBasalt)
        {
            txtName.text = rockInfo[10].name;
            txtDescription.text = rockInfo[10].description;
            //imgPart.sprite = rockInfo[10].partImage;
            ir.isBasalt = true;
            audio.clip = rockInfo[10].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[10].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[0], rockUI[11] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (isAndesite)
        {
            txtName.text = rockInfo[11].name;
            txtDescription.text = rockInfo[11].description;
            //imgPart.sprite = rockInfo[11].partImage;
            ir.isAndesite = true;
            audio.clip = rockInfo[11].readDesc;
            audio.Play();
            if (!isGraded)
            {
                pointsUI.gameObject.SetActive(true);
                isGraded = true;
            }
            rockUI[11].gameObject.SetActive(true);
            GameObject[] disabledUI = new GameObject[] { rockUI[1], rockUI[2], rockUI[3], rockUI[4], rockUI[5], rockUI[6], rockUI[7], rockUI[8], rockUI[9], rockUI[10], rockUI[0] };
            for (int i = 0; i < disabledUI.Length; i++)
            {
                disabledUI[i].gameObject.SetActive(false);
            }
        }

        if (ir.isTuff && ir.isScoria && ir.isRhyolite && ir.isPumice && ir.isPeriodotite && ir.isPegmatite && ir.isObsidian && ir.isGranite && ir.isGabbro && ir.isDiorite && ir.isBasalt && ir.isAndesite)
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
