using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mode1_AnalyticGeometryConicSection : MonoBehaviour
{
    public Mode1_AnalyticGeometrySnapArea rotationSnapArea;
    public float minPositionY;
    public float maxPositionY;
    public float offset;
    public LocRotScale bottomNappeAdjustments;
    public GameObject descriptionPanel;
    
    
    [Header("Trigger on first snap")]
    public UnityEvent onFirstSnap;
    
    [Header("Trigger each time it snaps")]
    public UnityEvent onSnap;
    private Vector3 initPos;
    private Vector3 initScale;
    private Quaternion initRot;
    bool isFirstSnap;

    public void Initiate(){
        initPos = transform.position;
        initScale = transform.localScale;
        initRot = transform.rotation;
    }

    public void SnapPlane(Mode1_AnalyticMovablePlane plane)
    {
        // Check if plane is under or above
        float distance = plane.transform.position.y - plane.initPosition.y;
        Vector3 tempPlanePos = plane.transform.position;

        // if distance is more than zero, then it is upper nappe
        if (distance > 0) {
            // if upper nappe, just set plane position to conic section position
            tempPlanePos.y = initPos.y;
            transform.position = initPos;
            transform.localScale = initScale;
            transform.rotation = initRot;
            tempPlanePos.y += offset;
        }
        // otherwise, lower nappe
        else {
            // if lower nappe, then we need to minus the distance to the center
            tempPlanePos.y = plane.initPosition.y + (plane.initPosition.y - initPos.y);

            transform.localPosition = bottomNappeAdjustments.position;
            transform.localScale = bottomNappeAdjustments.scale;
            transform.localRotation = Quaternion.Euler(bottomNappeAdjustments.rotation);
            tempPlanePos.y -= offset; 
        }
        // apply position
        plane.transform.position = tempPlanePos;
        
        // apply rotation to plane
        plane.transform.localRotation = initRot;


        // show the conic section
        gameObject.SetActive(true);

        // Invoke events
        if (!isFirstSnap) {
            plane.IncrementCount();
            FirstSnapEvent();
            isFirstSnap = true;
        }
        OnSnapEvent(plane);
    }

    private void OnSnapEvent(Mode1_AnalyticMovablePlane plane)
    {
        if (descriptionPanel) {
            descriptionPanel.transform.position = plane.transform.position;
            descriptionPanel.SetActive(true);
        } 
        onSnap.Invoke();
    }
    
    void OnDisable(){
        if (descriptionPanel) descriptionPanel.SetActive(false);
    }

    private void FirstSnapEvent()
    {
        onFirstSnap.Invoke();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}

[System.Serializable]
public class LocRotScale{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale = Vector3.one;
}
