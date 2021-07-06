using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_BalloonPump : MonoBehaviour
{
    public Mode2_BalloonGameManager mode2_BalloonGameManager;
    public Animator anim;
    public bool isClickable;

    public void OnMouseDown()
    {
        if (isClickable == true) {
            isClickable = false;
            anim.SetBool("isInflating", true);
            mode2_BalloonGameManager.isInflating = true;
            Debug.Log("clcked");
        }
    }
}
