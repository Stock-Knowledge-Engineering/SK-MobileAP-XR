using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public GameObject lookAtObject;
    private Transform objectTransform;
    
    void Start()
    {
        objectTransform = lookAtObject.GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(objectTransform);
    }
}
