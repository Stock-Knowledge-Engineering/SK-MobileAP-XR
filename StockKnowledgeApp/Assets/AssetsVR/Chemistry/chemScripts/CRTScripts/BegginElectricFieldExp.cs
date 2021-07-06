using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BegginElectricFieldExp : MonoBehaviour
{
    public ParticleSystem ps;

    public bool isElectroFieldClicked = false;
    public bool isActive;

    public Animator animator;
    public GameObject efCanvas;
    public GameObject magnet;

    public GameObject pointsUI;
    public bool isGraded;

    public void BegginExperiemt()
    {
        animator.SetBool("isClicked",true);
        efCanvas.gameObject.SetActive(true);
        StartCoroutine(ChangeParticleDirection());
        if (!isGraded)
        {
            pointsUI.gameObject.SetActive(true);
            isGraded = true;
        }
    }

    IEnumerator ChangeParticleDirection()
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
        yield return new WaitForSeconds(20f);
        animator.SetBool("isClicked", false);
        main.gravityModifier = 0.0f;
        magnet.gameObject.SetActive(true);
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
                    BegginExperiemt();
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
