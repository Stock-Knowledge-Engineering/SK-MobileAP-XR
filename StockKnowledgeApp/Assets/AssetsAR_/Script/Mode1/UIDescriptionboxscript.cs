using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDescriptionboxscript : MonoBehaviour
{
    public ARModule1_GameManager _aRModule1_GameManager;
    public int descriptionQue;
    public int pointHereQue; //determine where the linerenderer will point
    public int animToPlayInt; //detarmines what animation the 3d model will play
    public bool isEnd; //check if this is the end fo the decriptionCard
    public bool isScanned;

    public void Start()
    {
        _aRModule1_GameManager = GameObject.FindObjectOfType<ARModule1_GameManager>();
        
    }

    public void Update()
    {
        if (isEnd == true)
        {

        }
    }
}
