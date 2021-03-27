using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectOvertime : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject[] RotatingObject;

    public void Update()
    {
        RotateThis();
    }

    public void RotateThis()
    {
        for (int i = 0; i < RotatingObject.Length; i++)
        {
            RotatingObject[i].transform.Rotate(Vector3.left * (rotationSpeed * Time.deltaTime));
        }
        //RotatingObject[i].transform.Rotate(Vector3.left * (rotationSpeed * Time.deltaTime));
    }
}
