using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using TMPro;
using UnityEngine;

public class RotateOrScale : MonoBehaviour
{
    bool isRotateOrScale;
    public TMP_Text RotateOrScaleString;
    public void Toggle() //false = Rotate & true = Scale
    {
        isRotateOrScale = !isRotateOrScale;
        if (!isRotateOrScale)
        {
            RotateOrScaleString.text = "Rotate";
        } else
        {
            RotateOrScaleString.text = "Scale";
        }
        GetComponent<LeanRotate>().enabled = !isRotateOrScale;
        GetComponent<LeanScale>().enabled = isRotateOrScale;
    }
}
