using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1_AnalyticGeometrySnapArea : MonoBehaviour
{
    public float sliderValue;
    Image image;
    Color initColor;
    internal bool isActive;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        initColor = image.color;
    }

    public void ChangeColor(Color color){
        image.color = color;
    }

    public Color GetColor(){
        return image.color;
    }

    public void ResetColor(){
        ChangeColor(initColor);
    }

    public void Activate(bool isActive) {
        this.isActive = isActive;
    }

}
