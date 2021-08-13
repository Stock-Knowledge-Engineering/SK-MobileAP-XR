using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mode1_AnalyticGeometrySwipeController : MonoBehaviour
{
    public UnityEvent OnSwipeHorizontal;
    public UnityEvent OnSwipeVertical;
    public UnityEvent OnPointerDown;
    public UnityEvent OnPointerUp;

    internal float swipeDistance;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private TouchPhase touchPhase;

    bool isEnabled;


    // Start is called before the first frame update
    void Start()
    {
        touchPhase = TouchPhase.Moved;
    }
    

    private void Update() {
        if (!isEnabled) return;

        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {
            this.fingerDown = Input.mousePosition;
            this.fingerUp = Input.mousePosition;
            OnPointerDown.Invoke();
        }
         
        if (Input.GetMouseButton(0)) {
            this.fingerDown = Input.mousePosition;
            this.CheckSwipe();
        }
        if (Input.GetMouseButtonUp(0)) {
            this.fingerDown = Input.mousePosition;
            OnPointerUp.Invoke();
        }

        #endif
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                this.fingerDown = touch.position;
                this.fingerUp = touch.position;
                OnPointerDown.Invoke();
            }

            if (touch.phase == touchPhase) {
                this.fingerDown = touch.position;
                this.CheckSwipe();
            }
            if (touch.phase == TouchPhase.Ended) {
                this.fingerDown = touch.position;
                OnPointerUp.Invoke();
            }
        }
    }

    private void CheckSwipe() {

        if (VerticalMove() > 0 && VerticalMove() > HorizontalValMove()) {
            swipeDistance = fingerDown.y - fingerUp.y;
            OnSwipeVertical.Invoke();
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (HorizontalValMove() > 0 && HorizontalValMove() > VerticalMove()) {
            swipeDistance = fingerDown.x - fingerUp.x;
            OnSwipeHorizontal.Invoke();
            fingerUp = fingerDown;
        }
    }

    float VerticalMove() {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float HorizontalValMove() {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    private void SwipeHorizontal(){
    }
    private void SwipeVertical(){
    }

    public void Enable(bool isEnable){
        isEnabled = isEnable;
    }
}
