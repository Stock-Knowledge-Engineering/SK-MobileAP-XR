using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Onmouse : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Model Clicked");
    }

    public void TargetModel()
    {
        
        Debug.Log("Model Clicked2");
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("OnPointerDown called.");
    }
}
