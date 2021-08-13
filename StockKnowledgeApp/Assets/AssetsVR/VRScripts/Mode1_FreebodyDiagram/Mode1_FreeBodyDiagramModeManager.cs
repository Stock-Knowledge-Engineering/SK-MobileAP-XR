using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mode1_FreeBodyDiagramModeManager : MonoBehaviour
{
    public AudioManager audioManager;
    private Mode1_FreeBodyDiagramGameManager gameManager;
    public PointSystem[] pointSystem;
    //FreeBodyDiagram Reference
    #region 
    [Header("FREE DIAGRAM MODEL")]
    public GameObject head;
    public GameObject tail;
    private Rigidbody head_rb;
    private Rigidbody tail_rb;
    public GameObject rope;
    private Transform[] modelTransform;
    private Vector3[] startPos;
    private Quaternion[] startRot;
    public float tailMass;
    #endregion //FreeBody Diagram Model 
    

    [Header("UI")]
    public TextMeshProUGUI contents;
    public GameObject frictionFK;
    public int _currentMode;
    private string _currentText;
    public GameObject rightArrow;
    public GameObject downArrow;
    public GameObject frictionlessCanvas;
    public GameObject nextButton;
    public GameObject prevButton;

    /*public CurrentUser currentUser;*/
    private int numOfInteractables;

    public string subject;
    public string topic;
    public string objectName;

    [Header("Parts")]
    public GameObject part_One;
    public GameObject part_Two;
    
  
    void Awake()
    {
        head_rb = head.GetComponent<Rigidbody>();
        tail_rb = tail.GetComponent<Rigidbody>();
        modelTransform = rope.GetComponentsInChildren<Transform>();
        // Creates a number of element in an array where it depends on the length of model Transform array
        startPos = new Vector3[modelTransform.Length]; 
        startRot = new Quaternion[modelTransform.Length];

        /*currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();*/
    }
    void Start()
    {
        gameManager = this.GetComponent<Mode1_FreeBodyDiagramGameManager>();
        GetFirstPosition();

        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
        numOfInteractables = interactables.Length;
    }

    void Update()
    {
        SetObject();

        if (_currentMode != 3)
        { 
        ResetPosition();
        }

        

        if (!pointSystem[_currentMode].isScored)
        {
            PointSystem();
        }


        switch (_currentMode)
        {
            case 0:
                {
                    _currentText = "What is a Freebody Diagram?";
                    break;
                }
            case 1:
                {
                    //MODE 1
                    _currentText = "Velocity and acceleration are NOT forces applied to objects. ";
/*
                    currentUser.AddUserGamePoint(subject, topic, "Step-1", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Step-1");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, subject, topic, 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);*/

                    break;
                }

            case 2:
                {
                    //MODE 2



                    _currentText = "The arrows from the point are indicating forces ACTING ON the object.";

/*                    currentUser.AddUserGamePoint(subject, topic, "Step-2", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Step-2");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, subject, topic, 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);*/

                    break;
                }

            case 3:
                {
/*                    currentUser.AddUserGamePoint(subject, topic, "Step-3", 50);

                    //count interacted object in the scene
                    int totalInteractedObject = currentUser.CountInteractedObject("Step-3");

                    //Log Player Experience
                    currentUser.AddPlayerExperience(totalInteractedObject, numOfInteractables, subject, topic, 25);

                    //Level Up Player
                    currentUser.PlayerLevelUp(totalInteractedObject, numOfInteractables);*/

                    //MODE 3
                    head_rb.isKinematic = false;
                    head_rb.useGravity = true;
                    tail_rb.mass = tailMass;
                    _currentText = "Tension pull is upward (positive) while Weight is downward(negative)";
                    break;
                }


            case 4: //Frictionless part 1
                {
                    showPart(true, false);
                    _currentText = "<b>Frictionless Part I</b><br>x-axis  F = T =  m<sub>1</sub> a <br> y-axis n - w<sub>1</sub> = 0 ";
                    break;
                }


            case 5: //Frictionless part 2
                {
                    frictionlessCanvas.SetActive(true);
                    showPart(false, true);
                    _currentText = "<b>Frictionless Part II</b><br> x-axis F = 0 <br>  y - axis F = T - w <sub>2</sub> = m<sub>2</sub>a";
                  
                    break;
                }

            case 6: // Friction part 1
                {
                    showPart(true, false);
                    frictionlessCanvas.SetActive(true);
                    _currentText = "<b>Friction Part I </b><br>x-axis  F = T -  f<sub>k</sub>  =  m<sub>1</sub>a <br> y-axis F = n - w = 0 ";


                    break;
                }
            case 7: // Friction part 2
                {

                    showPart(false, true);
                    frictionlessCanvas.SetActive(true);
                    _currentText = "<b>Friction Part II </b> <br>x-axis  F = 0 <br> y-axis  F = T - w<sub>w</sub> =  m<sub>2</sub>a  ";
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void showPart(bool One, bool Two)
    {
        part_One.SetActive(One);
        part_Two.SetActive(Two);
    }
    public void Mode(int currentMode)
    {
        _currentMode = currentMode;
    }
    public void Next()
    {
        audioManager.Play(_currentMode+1);

        _currentMode++;
    }
    public void Back()
    {
        audioManager.Play(_currentMode-1);
        _currentMode--;
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
    void SetObject()
    {
        contents.text = _currentText;
        frictionlessCanvas.SetActive(_currentMode == 4 ? true : false);
        frictionFK.SetActive(_currentMode == 6 ? true : false);
        rightArrow.SetActive(_currentMode == 2 ? true : false);
        downArrow.SetActive(_currentMode == 2 ? true : false);
        nextButton.SetActive(_currentMode != 7 ? true : false);
        prevButton.SetActive(_currentMode != 0 ? true : false);

    }

    void PointSystem()
    {
       pointSystem[_currentMode].isScored = true;
       gameManager.totalScore += 50;
       gameManager.correctPoints.SetActive(true); 
    }
}

[System.Serializable]
public class PointSystem
{
    public bool isScored;
}