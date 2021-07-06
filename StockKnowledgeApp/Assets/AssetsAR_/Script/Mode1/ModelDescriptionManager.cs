using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Touch;

public class ModelDescriptionManager : MonoBehaviour
{
    public int modelNumber;
    public string[] subjectNameString;
    [TextArea(10, 10)]
    public string[] subjectDescriptionString;
    public AudioClip[] audioClipDescription;
    public Animator _anim;
    public GameObject[] points; //Where the line renderer will be placed
    public GameObject sphere; //for the first point of the line renderer
    public GameObject canvasContent; //Where the card content is
    public ARModule1_GameManager _aRModule1_GameManager;
    public bool isActive = false;
    public bool hasRead;
    public bool isOrientationChange;
    public bool isThereAnim;
    public TMP_Text pointedObjectNameText;
    public bool isDone;

    void Start()
    {
        _aRModule1_GameManager = GameObject.FindObjectOfType<ARModule1_GameManager>();
    }

    
    void Update()
    {
        ActiveCheck();
    }

    void ActiveCheck()
    {
        if (GetComponent<MeshRenderer>().enabled == true)
        {
            isActive = true;
            TargetModel();
            Debug.Log("GameObject: " + modelNumber + " Is active");
            if (_aRModule1_GameManager.isRotateOrScale == false) //false = Rotate & true = Scale
            {
                this.gameObject.GetComponent<LeanRotate>().enabled = true;
                this.gameObject.GetComponent<LeanScale>().enabled = false;
            } else if (_aRModule1_GameManager.isRotateOrScale == true)
            {
                this.gameObject.GetComponent<LeanRotate>().enabled = false;
                this.gameObject.GetComponent<LeanScale>().enabled = true;
            }
        }
        else if (GetComponent<MeshRenderer>().enabled == false)
        {
            canvasContent.SetActive(false);
            this.gameObject.GetComponent<LeanRotate>().enabled = false;
            this.gameObject.GetComponent<LeanScale>().enabled = false;
            isActive = false;
        }
    }

    public void TargetModel()
    {
        _aRModule1_GameManager.current3DModelInt = modelNumber;
        canvasContent.SetActive(true);
        Debug.Log("GameObject: " + modelNumber + " Is Clicked");
    }
}
