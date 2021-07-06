using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    
    void Awake()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Input.gyro.rotationRateUnbiased.x/2, -Input.gyro.rotationRateUnbiased.y, 0);
    }
}
