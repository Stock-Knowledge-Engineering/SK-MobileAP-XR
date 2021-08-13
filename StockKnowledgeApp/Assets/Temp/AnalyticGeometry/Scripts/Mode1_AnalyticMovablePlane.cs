using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Mode1_AnalyticMovablePlane : MonoBehaviour
{
    // public Mode1_AnalyticGeometrySwipeController swipeController;
    [Header("Set Plane Movable")]
    public bool isLocked;


    [Header("Snap and Move Settings")]
    public float moveSensitivity = 0.002f;
    public Mode1_AnalyticGeometrySwipeController swipeController;
    public float upperBoundary;
    public float lowerBoundary;

    [Header("Conic Sections")]
    public Mode1_AnalyticGeometryConicSection[] conicSections;
    Mode1_AnalyticGeometryConicSection lastActiveConicSection = null;
    internal Vector3 initPosition;

    public TMP_Text conicSectionCountText;

    public UnityEvent onConicSectionsCompleted;


    int conicSectionFoundCount = 0;

    void Start()
    {
        swipeController.OnSwipeVertical.AddListener(OnSwipeVertical);
        swipeController.OnPointerUp.AddListener(OnPointerUp);
        swipeController.OnPointerDown.AddListener(OnPointerDown);
        initPosition = transform.position;

        Array.ForEach(conicSections, conicSection => conicSection.Initiate());
    }

    void Update()
    {
        
    }

    public void OnSwipeVertical(){
        if (isLocked) return;
        // Move plane vertical or horizontal
        Vector3 pos = transform.localPosition;
        pos.y += swipeController.swipeDistance * moveSensitivity;
        pos.y = Mathf.Clamp(pos.y, lowerBoundary, upperBoundary);
        transform.localPosition = pos;
    }

    
    private void OnPointerUp()
    {
        if (isLocked) return;

        // on touch release, should snap on area
        foreach(Mode1_AnalyticGeometryConicSection conicSection in conicSections) {
            if (!conicSection.rotationSnapArea.isActive) continue;

            float planePosAbs = Mathf.Abs(transform.localPosition.y);
            float lockMin = conicSection.minPositionY;
            float lockMax = conicSection.maxPositionY;

            // if plane position falls between min and max
            if (planePosAbs >= lockMin && planePosAbs <= lockMax) {
                // detect if it is on bottom nappe
                conicSection.SnapPlane(this);
                lastActiveConicSection = conicSection;
                break;
            }
        }
    }

    private void OnPointerDown(){
        if (isLocked) return;

        // remove conic section if pointer is down
        if (lastActiveConicSection) lastActiveConicSection.Hide();
        lastActiveConicSection = null;
    }

    public void IncrementCount()
    {
        conicSectionFoundCount++;
        conicSectionCountText?.SetText(conicSectionFoundCount.ToString());

        // if completed, then wait for the audio to end before showing complete
        if (conicSectionFoundCount == conicSections.Length){
            StartCoroutine(ShowCompleted());
        }
    }

    private IEnumerator ShowCompleted()
    {
        yield return new WaitForSeconds(1f);
        while (FXSoundSystem.Instance.audioSource.isPlaying) yield return null;
        onConicSectionsCompleted.Invoke();
    }

    public void SetLocked(bool isLocked) {
        this.isLocked = isLocked;
    }
}