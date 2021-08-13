using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class ChangeOrientationTarget : MonoBehaviour
{
    public GameObject gameobjectToRotate;
    public Button changeOrientationBtn;

    private DefaultTrackableEventHandler target;
    public enum OrientationState {Flat, Standing, Hidden};
    public OrientationState orientationState = OrientationState.Standing;
    private OrientationState lastOrientationState;
    private DefaultTrackableEventHandler defaultTrackableEventHandler;
    int boylesOrientation;
    
    Quaternion initialObjectRotation;
    
    void Awake(){
        target = GetComponent<DefaultTrackableEventHandler>();
        lastOrientationState = orientationState;
        initialObjectRotation = gameobjectToRotate.transform.rotation;
        boylesOrientation = PlayerPrefs.GetInt("boylesOrientation", 0);
    }

    public void InitializeOrientation()
    {

        // if standing
        if (boylesOrientation == 0) {
            orientationState = OrientationState.Standing;
            Vector3 objectRotation = initialObjectRotation.eulerAngles;
            objectRotation.x -= 90;
            gameobjectToRotate.transform.localRotation = Quaternion.Euler(objectRotation);
        } else //if flat
        {
            orientationState = OrientationState.Flat;
            gameobjectToRotate.transform.localRotation = initialObjectRotation;
        }
    }

    public void ChangeOrientation(){
        if (boylesOrientation == 0) {
            // orientationState = OrientationState.Flat;
            // // Physics.gravity = new Vector3(0, -9.81f, 0);
            // transform.rotation = Quaternion.Euler(0, 0, 0);
            // gameobjectToRotate.transform.localRotation = initialObjectRotation;
            PlayerPrefs.SetInt("boylesOrientation", 1);
        } else {
            // orientationState = OrientationState.Standing;
            // transform.rotation = Quaternion.Euler(-90, 0, 0);
            // // Physics.gravity = new Vector3(0, 0, -9.81f);
            // Vector3 objectRotation = initialObjectRotation.eulerAngles;
            // objectRotation.x -= 90;
            // gameobjectToRotate.transform.localRotation = Quaternion.Euler(objectRotation);
            PlayerPrefs.SetInt("boylesOrientation", 0);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void TargetFound()
    {
        orientationState = lastOrientationState;
        changeOrientationBtn.gameObject.SetActive(true);
        InitializeOrientation();
    }
    private void TargetLost()
    {
        orientationState = OrientationState.Hidden;
        changeOrientationBtn.gameObject.SetActive(false);
    }


    
    void OnEnable(){
        target.OnTargetFound.AddListener(TargetFound);
        target.OnTargetLost.AddListener(TargetLost);
    }

    void OnDisable(){
        target.OnTargetFound.RemoveListener(TargetFound);
        target.OnTargetLost.RemoveListener(TargetLost);
    }

}
