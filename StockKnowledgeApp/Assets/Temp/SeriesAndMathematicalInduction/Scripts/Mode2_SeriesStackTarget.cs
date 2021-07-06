using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_SeriesStackTarget : MonoBehaviour
{
    internal bool currentStack;
    internal int stackSuccessCount = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveStack(){
        // enable stack to be targettable
        foreach (Mode2_SeriesPrismTarget target in GetComponentsInChildren<Mode2_SeriesPrismTarget>()) {
            target.EnableTargetStack(true);
            currentStack = true;
        }
    }

    public void ResetStack(){
        foreach (Mode2_SeriesPrismTarget target in GetComponents<Mode2_SeriesPrismTarget>()) {
            currentStack = false;
            target.EnableTargetStack(false);
        }
        stackSuccessCount = 0;
    }

    public void IncrementStackSuccessCount()
    {
        stackSuccessCount++;
        if (stackSuccessCount == 3) {
            GetComponentInParent<Mode2_StackTargetManager>().UpdateActiveStack(1);
        }
    }
}
