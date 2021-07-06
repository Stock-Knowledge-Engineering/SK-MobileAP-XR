using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRTMagnet : MonoBehaviour
{
    public bool isMSouth;

    public ParticleSystem ps;

    public GameObject pointsUI;
    public int ptsGraded;

    public void Start()
    {
        StartCoroutine(ChangeParticleDirectionUp());
    }

    public void ChangePolarity()
    {
        if (isMSouth)
        {
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x, -0.03f, transform.localScale.z);
            StartCoroutine(ChangeParticleDirectionDown());
            isMSouth = false;
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x, 0.03f, transform.localScale.z);
            StartCoroutine(ChangeParticleDirectionUp());
            isMSouth = true;
        }

        if (ptsGraded<2)
        {
            pointsUI.gameObject.SetActive(true);
            ptsGraded += 1;
        }

    }

    IEnumerator ChangeParticleDirectionDown()
    {
        var main = ps.main;
        main.gravityModifier = 0.001f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = 0.002f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = 0.003f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = 0.004f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = 0.005f;
        
    }

    IEnumerator ChangeParticleDirectionUp()
    {
        var main = ps.main;
        main.gravityModifier = -0.001f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = -0.002f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = -0.003f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = -0.004f;
        yield return new WaitForSeconds(0.2f);
        main.gravityModifier = -0.005f;
        
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
                    ChangePolarity();
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
