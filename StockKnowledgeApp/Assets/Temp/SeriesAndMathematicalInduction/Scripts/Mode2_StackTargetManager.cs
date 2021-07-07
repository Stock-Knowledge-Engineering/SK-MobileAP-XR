using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_StackTargetManager : MonoBehaviour
{
    Mode2_SeriesStackTarget[] stacks; 
    internal int currentCount = 0;
    int stackCount;
    
    void Start(){
        stacks = GetComponentsInChildren<Mode2_SeriesStackTarget>();
        stackCount = stacks.Length;
        UpdateActiveStack();
    }

    public void UpdateActiveStack(int increment = 0){
        if (currentCount >= stackCount - 1) return;
        currentCount += increment;
        Mode2_SeriesStackTarget currentStack = stacks[currentCount];
        currentStack.SetActiveStack();
    }
}
