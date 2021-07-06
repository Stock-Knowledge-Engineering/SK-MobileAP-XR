using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescriptionScanner : MonoBehaviour
{
    public int currentDescriptionQue; //start with 2
    //public TMP_Text currentTextQue;
    public int currentAnimQue;
    public bool isScanStarted;
    public int pointInt;
    public int currentLineRendererPoint;
    public ARModule1_GameManager _aRModule1_GameManager;

    public void Awake()
    {
        //currentTextQue.text = GameObject.Find("Description-Text");
        _aRModule1_GameManager = GameObject.FindObjectOfType<ARModule1_GameManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject descriptionGameObject = col.gameObject; 
        if (col.gameObject.tag == "UIDescriptionbox") //check if the gameobject that was hit has a tag of "UIDescriptionbox"
        {
            isScanStarted = true;
            if (descriptionGameObject.GetComponent<UIDescriptionboxscript>().isScanned == false)
            {
                descriptionGameObject.GetComponent<Image>().color = new Color32(0, 89, 225, 225);
                descriptionGameObject.GetComponent<UIDescriptionboxscript>().isScanned = true;
                _aRModule1_GameManager.Point();
            }
            currentLineRendererPoint = descriptionGameObject.GetComponent<UIDescriptionboxscript>().pointHereQue;
            currentDescriptionQue = descriptionGameObject.GetComponent<UIDescriptionboxscript>().descriptionQue; //get the int for the description from the UIDescriptionboxscipt
            currentAnimQue = descriptionGameObject.GetComponent<UIDescriptionboxscript>().animToPlayInt; //get the int for the animation from the UIDescriptionboxscipt
            _aRModule1_GameManager.DisplayThisConent();
            _aRModule1_GameManager.newcontentIndicator.SetActive(true);
        }
    }
}
