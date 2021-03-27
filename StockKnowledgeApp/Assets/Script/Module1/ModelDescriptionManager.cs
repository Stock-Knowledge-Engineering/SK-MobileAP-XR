using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public bool isThereAnim;
    public TMP_Text pointedObjectNameText;

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
            _aRModule1_GameManager.current3DModelInt = modelNumber;
            isActive = true;
            canvasContent.SetActive(true);
            Debug.Log("GameObject: " + modelNumber + " Is active");
        }
        else if (GetComponent<MeshRenderer>().enabled == false)
        {
            canvasContent.SetActive(false);
            isActive = false;
        }
    }
}
