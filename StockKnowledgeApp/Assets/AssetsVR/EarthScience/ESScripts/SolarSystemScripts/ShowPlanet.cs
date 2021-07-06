using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlanet : MonoBehaviour
{
    [Header("UI Canvas")]
    public Text txtName;
    public Text txtDescription;
    public GameObject complete;
    public bool isBtnNxt;
    public bool isBtnPrev;
    public GameObject imgBlocker;

    [Header("ScriptableObjects")]
    public SOSolarSystem[] palnetInfo = new SOSolarSystem[10];

    [Header("Planet Objects")]
    public GameObject[] planets = new GameObject[10];

    [Header("Planets")]
    public bool isSun;
    public bool isMercury;
    public bool isVenus;
    public bool isEarth;
    public bool isMars;
    public bool isAsteroidBelt;
    public bool isJupiter;
    public bool isSaturn;
    public bool isUranus;
    public bool isNeptune;

    public GameObject hyperSpace;
    public GameObject asteroidInteractive;

    public SolarSystemGameManager sr;

    [Header("Audio")]
    public AudioSource audio;

    [Header("Points")]
    public bool isGraded;
    public GameObject pointsUI;

    public void ShowNextPlanet()
    {
        GameObject[] planetsToHide = new GameObject[] { planets[0], planets[1], planets[2], planets[3], planets[4], planets[5], planets[6], planets[7], planets[8], planets[9] };
        if (isBtnNxt)
        {
            sr.currentPlanet += 1;
            StartCoroutine(EnableNextPlanet());
            hyperSpace.gameObject.SetActive(true);
            planetsToHide[sr.currentPlanet - 2].gameObject.SetActive(false);
            imgBlocker.gameObject.SetActive(true);
            if(sr.currentPlanet>10)
                sr.currentPlanet = 10;

        }
        if (isBtnPrev)
        {
            sr.currentPlanet -= 1;
            StartCoroutine(EnableNextPlanet());
            hyperSpace.gameObject.SetActive(true);
            planetsToHide[sr.currentPlanet].gameObject.SetActive(false);
            imgBlocker.gameObject.SetActive(true);
            if (sr.currentPlanet < 1)
                sr.currentPlanet = 1;
        }

        if (sr.isSun && sr.isMercury && sr.isVenus && sr.isEarth && sr.isMars && sr.isAsteroidBelt && sr.isJupiter && sr.isSaturn && sr.isUranus && sr.isNeptune)
        {
            Invoke("DelayComplete", 12.5f);
        }
    }

    IEnumerator StartAsteroidInteractive()
    {
        yield return new WaitForSeconds(55f);
        asteroidInteractive.gameObject.SetActive(true); 
    }

    IEnumerator EnableNextPlanet()
    {
        yield return new WaitForSeconds(2f);
        hyperSpace.gameObject.SetActive(false);
        yield return new WaitForSeconds(.2f);
        GameObject[] disabledUI = new GameObject[10];
        //infoUICanvas.gameObject.SetActive(true);
        switch (sr.currentPlanet)
        {
            case 1:
                
                audio.clip = palnetInfo[0].readDesc;
                audio.Play();
                if (!sr.isSun)
                {
                    //pointsUI.gameObject.SetActive(true);
                    sr.isSun = true;
                }

                planets[0].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[1], planets[2], planets[3], planets[4], planets[5], planets[6], planets[7], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                break;
            case 2:
                
                audio.clip = palnetInfo[1].readDesc;
                audio.Play();
                if (!sr.isMercury)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isMercury = true;
                }
                
                planets[1].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[2], planets[3], planets[4], planets[5], planets[6], planets[7], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                break;
            case 3:
                
                audio.clip = palnetInfo[2].readDesc;
                audio.Play();
                if (!sr.isVenus)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isVenus = true;
                }
                
                planets[2].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[3], planets[4], planets[5], planets[6], planets[7], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                break;
            case 4:
                
                audio.clip = palnetInfo[3].readDesc;
                audio.Play();
                if (!sr.isEarth)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isEarth = true;
                }
                planets[3].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[2], planets[4], planets[5], planets[6], planets[7], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                
                break;
            case 5:
                
                audio.clip = palnetInfo[4].readDesc;
                audio.Play();
                if (!sr.isMars)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isMars = true;
                }
                
                planets[4].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[3], planets[2], planets[5], planets[6], planets[7], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                break;
            case 6:
                
                audio.clip = palnetInfo[5].readDesc;
                audio.Play();
                if (!sr.isAsteroidBelt)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isAsteroidBelt = true;
                }
                
                planets[5].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[3], planets[4], planets[2], planets[6], planets[7], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }

                StartCoroutine(StartAsteroidInteractive());
                break;
            case 7:
                
                audio.clip = palnetInfo[6].readDesc;
                audio.Play();
                if (!sr.isJupiter)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isJupiter = true;
                }
               
                planets[6].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[3], planets[4], planets[5], planets[2], planets[7], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                break;
            case 8:
                
                audio.clip = palnetInfo[7].readDesc;
                audio.Play();
                if (!sr.isSaturn)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isSaturn = true;
                }
                planets[7].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[3], planets[4], planets[5], planets[6], planets[2], planets[8], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                
                break;
            case 9:
                sr.isUranus = true;
                audio.clip = palnetInfo[8].readDesc;
                audio.Play();
                if (!sr.isUranus)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isUranus = true;
                }
               
                planets[8].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[3], planets[4], planets[5], planets[6], planets[7], planets[2], planets[9] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }
                break;
            case 10:
                
                audio.clip = palnetInfo[9].readDesc;
                audio.Play();
                if (!sr.isNeptune)
                {
                    pointsUI.gameObject.SetActive(true);
                    sr.isNeptune = true;
                }
               
                planets[9].gameObject.SetActive(true);
                disabledUI = new GameObject[] { planets[0], planets[1], planets[3], planets[4], planets[5], planets[6], planets[7], planets[8], planets[2] };
                for (int i = 0; i < disabledUI.Length; i++)
                {
                    disabledUI[i].gameObject.SetActive(false);
                }                
                break;
        }
        yield return new WaitForSeconds(3f);
        if(sr.currentPlanet == 6)
        {
            imgBlocker.gameObject.SetActive(true);
        }
        else
        {
            imgBlocker.gameObject.SetActive(false);
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

                    ShowNextPlanet();
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
