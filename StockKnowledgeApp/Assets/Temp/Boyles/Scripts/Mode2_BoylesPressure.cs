using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Mode2_BoylesPressure : MonoBehaviour
{
    public float maxVolume = 10f;
    public Mode2_BoylesManager mode2_BoylesManager;

    private Vector3 initialScale;
    private Vector3 targetScale;
    private int weightCount;
    private float volumeDecrease;
    private List<Mode2_BoylesWeight> weightsInside;
    void Start(){
        initialScale = transform.parent.localScale;
        volumeDecrease = initialScale.y / maxVolume;
        Initialize();
    }

    private void Initialize()
    {
        // I separated it to Start so that I could just call it if I want to reset
        weightCount = 0;
        targetScale = initialScale;
        weightsInside = new List<Mode2_BoylesWeight>();
        transform.parent.localScale = initialScale;    
    }

    void Update(){
        transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, targetScale, 0.1f);
    }
    
    public void IncreaseWeight(Mode2_BoylesWeight weight)
    {
        if(!weightsInside.Contains(weight)) {
            weightsInside.Add(weight);
            weightCount++;
            UpdateScale();
        }

    }

    // public void DecreaseWeight() {
    //     if (weightsInside.Count != 0) {
    //         weightsInside[weightsInside.Count - 1].gameObject.SetActive(false);
    //         weightsInside.RemoveAt(weightsInside.Count - 1);
    //         weightCount--;
    //         UpdateScale();
    //     }
    // }

    public void Reset()
    {
        // clear all active weights first
        foreach(Mode2_BoylesWeight boylesWeight in weightsInside) {
            boylesWeight.gameObject.SetActive(false);
        }

        Initialize();
    }

    public void DecreaseWeight(Mode2_BoylesWeight weight)
    {
        if(weightsInside.Contains(weight)) {
            weightsInside.Remove(weight);
            weightCount--;
            UpdateScale();
        }
    }

    private void UpdateScale()
    {
        Vector3 scale = targetScale;
        scale.y = initialScale.y + (-volumeDecrease * (weightCount));
        targetScale = scale;

        mode2_BoylesManager.SetPressure(maxVolume/(maxVolume-weightCount), weightCount);
    }
}
