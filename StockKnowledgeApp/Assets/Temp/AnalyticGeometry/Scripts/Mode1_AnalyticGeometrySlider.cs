using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mode1_AnalyticGeometrySlider : MonoBehaviour,IPointerUpHandler, IPointerDownHandler
{
    Slider slider;
    public GameObject movablePlane;
    public GameObject handle;
    public Animator handleAnimator;
    public Color activeColor = Color.green;
    public Image fillImage;
    Mode1_AnalyticGeometrySnapArea currentSnapArea;
    Mode1_AnalyticGeometrySnapArea lastSnapArea;

    Mode1_AnalyticGeometrySnapArea[] snapAreas;
    void Start()
    {
        slider = GetComponent<Slider>();
        snapAreas = GetComponentsInChildren<Mode1_AnalyticGeometrySnapArea>();
        slider.onValueChanged.AddListener(OnValueChanged);
        fillImage.color = activeColor;
        UpdateColor();

        // activate first snap area
        lastSnapArea = snapAreas[0];
        snapAreas[0].Activate(true);
    }

    private void OnValueChanged(float newVal)
    {
        movablePlane.transform.eulerAngles = Vector3.forward * newVal * -80f;

        UpdateColor();
    }

    private void UpdateColor()
    {
        // Change to active color when value is equal or higher
        foreach(Mode1_AnalyticGeometrySnapArea snapArea in snapAreas) {
            if (slider.value >= snapArea.sliderValue - 0.1f) {
                snapArea.ChangeColor(activeColor);
            } else {
                snapArea.ResetColor();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handleAnimator.SetBool("isSnap", true);
        currentSnapArea = snapAreas[0];

        Mode1_AnalyticGeometrySnapArea tempSnapArea = snapAreas[0];
        // check for snap area if mouse is release
        foreach(Mode1_AnalyticGeometrySnapArea snapArea in snapAreas) {
            float difference = Mathf.Abs(snapArea.sliderValue - slider.value);
            float lastDifference = Mathf.Abs(tempSnapArea.sliderValue - slider.value);
            
            if (difference < lastDifference) {
                currentSnapArea = snapArea;
            } 
            tempSnapArea = snapArea;
            
            if (snapArea.sliderValue > slider.value) break;
        }
        slider.value = currentSnapArea.sliderValue;
        lastSnapArea.Activate(false);
        currentSnapArea.Activate(true);
        lastSnapArea = currentSnapArea;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        handleAnimator.SetBool("isSnap", false);
    }
}
