using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update\
    private Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.LookRotation(transform.position - _mainCamera.transform.position);
    }
}
