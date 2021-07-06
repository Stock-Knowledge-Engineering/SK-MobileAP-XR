using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ChangeOrientationTarget : MonoBehaviour
{
    public GameObject gameobjectToRotate;
    public Button changeOrientationBtn;

    private DefaultTrackableEventHandler target;
    public enum OrientationState {Flat, Standing, Hidden};
    public OrientationState orientationState = OrientationState.Flat;
    private OrientationState lastOrientationState;
    
    Quaternion initialObjectRotation;

    void Awake(){
        target = GetComponent<DefaultTrackableEventHandler>();
        lastOrientationState = orientationState;
        initialObjectRotation = gameobjectToRotate.transform.rotation;
    }

    public void ChangeOrientation(){
        if (orientationState == OrientationState.Standing) {
            orientationState = OrientationState.Flat;
            // Physics.gravity = new Vector3(0, -9.81f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            gameobjectToRotate.transform.localRotation = initialObjectRotation;
        } else if (orientationState == OrientationState.Flat) {
            orientationState = OrientationState.Standing;
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            // Physics.gravity = new Vector3(0, 0, -9.81f);
            Vector3 objectRotation = initialObjectRotation.eulerAngles;
            objectRotation.x -= 90;
            gameobjectToRotate.transform.localRotation = Quaternion.Euler(objectRotation);
        }

        lastOrientationState = orientationState;
    }

    

    private void TargetFound()
    {
        orientationState = lastOrientationState;
        changeOrientationBtn.gameObject.SetActive(true);
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
