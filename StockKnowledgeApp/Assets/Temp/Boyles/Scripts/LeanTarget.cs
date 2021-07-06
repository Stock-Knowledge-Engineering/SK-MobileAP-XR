using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LeanTarget : MonoBehaviour
{


    public enum LeanState {Rotate, Scale, Hidden};
    public Button rotateOrScaleBtn;

    internal LeanState currentLeanState = LeanState.Rotate;
    private LeanState lastLeanState;
    public GameObject[] leanGameObjects;

    private DefaultTrackableEventHandler target;
    
    void Awake(){
        target = GetComponent<DefaultTrackableEventHandler>();
        lastLeanState = currentLeanState;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (lastLeanState != currentLeanState) {
            OnStateChange(currentLeanState);
            lastLeanState = currentLeanState;
        }
        
    }

    void OnEnable(){
        target.OnTargetFound.AddListener(TargetFound);
        target.OnTargetLost.AddListener(TargetLost);
    }

    void OnDisable(){
        target.OnTargetFound.RemoveListener(TargetFound);
        target.OnTargetLost.RemoveListener(TargetLost);
    }

    private void TargetFound()
    {
        currentLeanState = LeanState.Rotate;
    }
    private void TargetLost()
    {
        currentLeanState = LeanState.Hidden;
    }


    public void RotateOrScale(){
        if (currentLeanState == LeanState.Rotate) {
            currentLeanState = LeanState.Scale;
            rotateOrScaleBtn.GetComponentInChildren<TMP_Text>().SetText("Scale");
        } else if (currentLeanState == LeanState.Scale) {
            currentLeanState = LeanState.Rotate;
            rotateOrScaleBtn.GetComponentInChildren<TMP_Text>().SetText("Rotate");
        }
    }

    void OnStateChange(LeanState currentLeanState)
    {
        if (currentLeanState != LeanState.Hidden)
        {
            rotateOrScaleBtn.gameObject.SetActive(true);
            
            if (currentLeanState == LeanState.Rotate) 
            {
                foreach(GameObject obj in leanGameObjects) {
                    obj.GetComponent<LeanRotate>().enabled = true;
                    obj.GetComponent<LeanScale>().enabled = false;
                }
            } else if (currentLeanState == LeanState.Scale) 
            {
                foreach(GameObject obj in leanGameObjects) {
                    obj.GetComponent<LeanRotate>().enabled = false;
                    obj.GetComponent<LeanScale>().enabled = true;
                }
            }
        }
        else
        {
            rotateOrScaleBtn.gameObject.SetActive(false);
            foreach(GameObject obj in leanGameObjects) {
                obj.GetComponent<LeanRotate>().enabled = false;
                obj.GetComponent<LeanScale>().enabled = false;
            }
        }
    }
}
