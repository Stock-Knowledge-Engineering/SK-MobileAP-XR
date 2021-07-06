using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
{
    int x;
    
    void Start()
    {
        x = 8 / 2 * (2 + 2);
        Debug.Log("Answer = " + x);
    }
}
