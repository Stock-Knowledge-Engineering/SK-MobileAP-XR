using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;

public class Tire : MonoBehaviour
{
    Vector3 startPos;
    private Rigidbody rb;
    public GameObject descriptionCanvas;
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    public void StartScene()
    {
        transform.position = startPos;
        rb.isKinematic = false;
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        rb.isKinematic = true;
        descriptionCanvas.SetActive(true);
    }







}
