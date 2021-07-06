using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_BalloonGameManager : MonoBehaviour
{
    public GameObject balloonObj;
    public Rigidbody balloonPopGameObj;
    public Mode2_BalloonPump balloonPump;

    //Constant
    float maxSize = 1.0f;
    float growthRate = 0.1f;
    float inflationTime = 0;

    public float targetScale;
    float initScale = 0.19f;
    float currentScale = 0.19f;
    public bool isInflating;

    public void Update()
    {
        Balloon();
    }

    public void Balloon()
    {
        //Inflating
        if (isInflating == true)
        {
            balloonObj.transform.localScale = Vector3.one * currentScale;
            currentScale += growthRate * Time.deltaTime;
            inflationTime = inflationTime + Time.deltaTime;
            if (inflationTime >= 1)
            {
                balloonPump.isClickable = true;
                inflationTime = 0;
                isInflating = false;
            }
        } else if (isInflating == false && currentScale > initScale) //Deflating
        {
            balloonObj.transform.localScale = Vector3.one * currentScale;
            currentScale -= growthRate * Time.deltaTime;
            balloonPump.anim.SetBool("isInflating", false);
        }

        //Destroy
        if (currentScale > maxSize)
        {
            BalloonPop();
            Destroy(balloonObj);
        }
        //Debug.Log(currentScale);
    }

    public void BalloonPop()
    {
        Rigidbody BalloonPop = (Rigidbody)Instantiate(balloonPopGameObj, balloonObj.transform.position, balloonObj.transform.rotation);
        BalloonPop.velocity = transform.forward * 1;
    }

}
