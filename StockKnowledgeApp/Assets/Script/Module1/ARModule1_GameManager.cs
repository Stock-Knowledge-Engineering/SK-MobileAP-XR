using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARModule1_GameManager : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    public DescriptionScanner _descriptionScanner; //reference script for the description scanner

    //Description
    public int current3DModelInt;
    public int currentDescriptionInt;
    public AudioSource _audioSource;
    [Header("3D Models")]
    public GameObject[] _3DModel;
    [Header("GameObject")]
    public GameObject newcontentIndicator;
    public GameObject scrollViewContainer;
    public GameObject contentButton;
    public GameObject descriptionPanel;
    public GameObject StartDiscussionBox;
    [Header("Text Mesh Pro")]
    public TMP_Text _subjectNameText;
    public TMP_Text _pointedObjectNameText;
    public TMP_Text _subjectDescriptionText;
    public bool isStartClicked;

    private void Start()
    {
        _lineRenderer.enabled = false;
        //points = GameObject.FindGameObjectsWithTag("LineRendererPoint");
    }

    public void Update()
    {
        _descriptionScanner = GameObject.FindObjectOfType<DescriptionScanner>();
        LineRenderedPosition();
        //FaceCamera();
        ModelDetectCheck();
    }

    public void ModelDetectCheck()
    {
        if (_3DModel[current3DModelInt].GetComponent<Renderer>().isVisible == true && isStartClicked == false)
        {
            Debug.Log("Model detected");
            StartDiscussionBox.SetActive(true);
        }
    }

    public void StartDiscussion()
    {
        isStartClicked = true;
        Debug.Log("Starting the Discussion");
        contentButton.SetActive(true);
        scrollViewContainer.SetActive(true);
    }

    /* public void DisplayNextContent() //button to display the next content
    {
        if (_3DModel[0].GetComponent<ModelDescriptionManager>().subjectNameString.Length < currentDescriptionInt)
        {
            EndofContent();
        }
        else if (_3DModel[0].GetComponent<ModelDescriptionManager>().subjectNameString.Length >= currentDescriptionInt)
        {
            currentDescriptionInt++;
            DisplayThisConent();
        }
    } */

    public void DisplayThisConent()
    {
        if (_descriptionScanner.isScanStarted == true)
        {
            Debug.Log("currentDescriptionInt: " + _descriptionScanner.currentDescriptionQue);
            _lineRenderer.enabled = true;
            _subjectNameText.text = _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().subjectNameString[_descriptionScanner.currentDescriptionQue];
            _subjectDescriptionText.text = _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().subjectDescriptionString[_descriptionScanner.currentDescriptionQue];
            _audioSource.clip = _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().audioClipDescription[_descriptionScanner.currentDescriptionQue];
            if (_3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().isThereAnim == true)
            {
                _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>()._anim.SetInteger("AnimationToPlay", _descriptionScanner.currentAnimQue);
            }
            
            _pointedObjectNameText = _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().pointedObjectNameText;
            _pointedObjectNameText.text = _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().subjectNameString[_descriptionScanner.currentDescriptionQue];
            if (newcontentIndicator.activeSelf)
            {
                newcontentIndicator.SetActive(false);
            }
        }
    }

    public void LineRenderedPosition() //change and update where the line renderer will point
    {
        if (_3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().isActive == true && _descriptionScanner.isScanStarted == true)
        {
            _lineRenderer.SetPosition(0, _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().points[0].transform.position);
            _lineRenderer.SetPosition(1, _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().points[1].transform.position); //Line render to the gameobject
            _lineRenderer.SetPosition(2, _3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().points[_descriptionScanner.currentLineRendererPoint].transform.position);
        } else if (_3DModel[current3DModelInt].GetComponent<ModelDescriptionManager>().isActive == false)
        {
            _lineRenderer.enabled = false;
        }
    }

    public void ShowDialogueBox()
    {
        if (descriptionPanel.activeSelf)
        {
            descriptionPanel.SetActive(false);
            _lineRenderer.enabled = false;
        }
        else
        {
            descriptionPanel.SetActive(true);
        }
    }

    public void PlayAudioDescription()
    {
        _audioSource.Play();
    }

    public void FaceCamera()
    {
        //Descriptionbox.transform.LookAt(Camera.main.transform);
    }

    void EndofContent()
    {
        Debug.Log("End of Content"); //if the user goes to the end of the UIDescriptionbox
    }
}
