using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GazeObjectV2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public UnityEvent OnGaze;
    [Header("Gaze")]
    public ToggleTouchGaze ttg;
    public float gazeTime = 2f;

    private float gazeTimer;
    public Image radialImage;
    private bool isRadialFilled;
    private bool isObjectGazed;

    public void OnPointerEnter(PointerEventData eventData)
    { 
        GazeAtObject();
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {  
        ResetProgress();
    }

    public virtual void GazeAtObject()
    {
        if (ttg.isGaze)
        {
            isRadialFilled = false;
            isObjectGazed = true;
        }
    }

    void LateUpdate()
    {
        if (isObjectGazed)
        {
            if (!isRadialFilled)
            {
                gazeTimer += Time.deltaTime;
                radialImage.fillAmount = gazeTimer / gazeTime;

                if (gazeTimer >= gazeTime)
                {
                    isRadialFilled = true;
                    ResetProgress();
                    OnGaze.Invoke();

                    // if onclick is detected, then invoke
                    Button btnComponent = GetComponent<Button>();
                    if (btnComponent) btnComponent.onClick.Invoke();

                    // if event trigger component is detected with onclick, then invoke
                    EventTrigger eventTrigger = GetComponent<EventTrigger>();
                    if (eventTrigger) eventTrigger.OnPointerClick(null);
                }
            }
        }

    }

    public virtual void ResetProgress()
    {
        isObjectGazed = false;
        gazeTimer = 0f;
        radialImage.fillAmount = 0f;
    }

}
