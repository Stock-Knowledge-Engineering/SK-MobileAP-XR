using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mode1_FreeBodyDiagramModeManager : MonoBehaviour
{


    [Header("FREE DIAGRAM MODEL")]
    public GameObject head;
    public GameObject tail;
    private Rigidbody head_rb;
    private Rigidbody tail_rb;
    public GameObject rope;
    private Transform[] modelTransform;
    private Vector3[] startPos;
    private Quaternion[] startRot;


    [Header("UI")]
    public TextMeshProUGUI contents;
    public int _currentMode;
    private string _currentText;
    public GameObject rightArrow;
    public GameObject downArrow;


     void Awake()
    {
        head_rb = head.GetComponent<Rigidbody>();
        tail_rb = tail.GetComponent<Rigidbody>();
        modelTransform = rope.GetComponentsInChildren<Transform>();

        // Creates a number of element in an array where it depends on the length of modelTransform array
        startPos = new Vector3[modelTransform.Length]; 
        startRot = new Quaternion[modelTransform.Length];
    }
    void Start()
    {
        GetFirstPosition();

        
        rightArrow.SetActive(false);
        downArrow.SetActive(false);
    }

    void Update()
    {


        contents.text = _currentText;

        if (_currentMode != 2)
        {
            rightArrow.SetActive(false);
            downArrow.SetActive(false);
        }
        switch (_currentMode)
        {
            case 0:
                {
                    _currentText = "Click the first button to proceed.";
                    break;
                }
            case 1:
                {
                    //MODE 1
                    ResetPosition();
                    _currentText = "Velocity and acceleration are NOT forces applied to objects. ";
                    break;
                }

            case 2:
                {
                    //MODE 2
                    
                    rightArrow.SetActive(true);
                    downArrow.SetActive(true);
                    _currentText = "The arrows from the point are indicating forces ACTING ON the object.";
                    ResetPosition();
                    break;

                }

            case 3:
                {
                    //MODE 3
                    head_rb.isKinematic = false;
                    head_rb.useGravity = true;
                    tail_rb.mass = 1;
                    _currentText = "Tension pull is upward (positive) while Weight is downward(negative)";
                    break;
                }

            default:
                {
                    break;
                }
        }


    


    }

    public void Mode(int currentMode)
    {
        _currentMode = currentMode;
    }



    void ResetPosition() // Gets the starting position and rotation 
    {

        for (int i = 0; i <= modelTransform.Length - 1; i++)
        {
           modelTransform[i].position = startPos[i] ;
            modelTransform[i].rotation = startRot[i];

        }
    }

    void GetFirstPosition() //This stores the data of the following starting rotation and position inside the array Quaternion and also the Vector
    {
        for (int i = 0; i <= modelTransform.Length - 1; i++)
        {
            startPos[i] = modelTransform[i].position;
            startRot[i] = modelTransform[i].rotation;
        }
    }
}
