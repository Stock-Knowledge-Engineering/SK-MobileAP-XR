using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mode2_BoyleSwipeController : MonoBehaviour
{
    public float sensitivity = 0.3f;
    public Mode2_BoylesManager mode2_BoylesManager;
    public float swipeThreshold = 25f;
    public UnityEvent OnSwipeUp;
    public UnityEvent OnInputFinished;

    public bool isSwiped;
    public bool isSwipedUp;

    public bool detectSwipeOnlyAfterRelease = false;
    private TouchPhase touchPhase;
    
    private Vector2 fingerDown;
    private Vector2 fingerUp;


    // Start is called before the first frame update
    void Start()
    {
        touchPhase = detectSwipeOnlyAfterRelease ? TouchPhase.Ended : TouchPhase.Moved;
        OnSwipeUp.AddListener(SwipeUp);
        OnInputFinished.AddListener(InputFinished);
        
    }
    
    private void InputFinished() {
        AfterInputFinished();
    }

    private void AfterInputFinished() {
        isSwipedUp = false;
    }

    
    private void Update() {
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {
            this.fingerDown = Input.mousePosition;
            this.fingerUp = Input.mousePosition;
        }
        if (detectSwipeOnlyAfterRelease) {
            if (Input.GetMouseButtonUp(0)) {
                this.fingerDown = Input.mousePosition;
                this.CheckSwipe();
                isSwiped = false;
            }
        } else {
            if (Input.GetMouseButton(0)) {
                this.fingerDown = Input.mousePosition;
                this.CheckSwipe();
            }
            if (Input.GetMouseButtonUp(0)) {
                this.fingerDown = Input.mousePosition;
                isSwiped = false;
            }
        }
        #endif
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                this.fingerDown = touch.position;
                this.fingerUp = touch.position;
            }

            if (touch.phase == touchPhase) {
                this.fingerDown = touch.position;
                this.CheckSwipe();
            }
            if (touch.phase == TouchPhase.Ended) {
                this.fingerDown = touch.position;
                isSwiped = false;
            }
        }
    }

    
    private void CheckSwipe() {

        if (VerticalMove() > swipeThreshold) {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp.Invoke();
                mode2_BoylesManager.SpawnWeight((fingerDown.y - fingerUp.y) * sensitivity);
            }

            OnInputFinished.Invoke();
            isSwiped = true;
            fingerUp = fingerDown;
        }
    }
    float VerticalMove() {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    
    private void SwipeUp() {
        isSwipedUp = true;
    }
}
