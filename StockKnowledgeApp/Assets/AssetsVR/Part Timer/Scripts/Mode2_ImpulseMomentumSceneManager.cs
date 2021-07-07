using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_ImpulseMomentumSceneManager : MonoBehaviour
{
    public Mode2_ImpluseMomentumQuestionManager questionManager;
    [Header("Tennis Ball Movement")]
    public GameObject tennisBall;
    public GameObject positionParent;
    private Vector3[] targetPosition;
    private Quaternion[] targetRotation;
    private Transform[] positions;
    public float smoothFactor = 2;

    void Awake()
    {
      
        questionManager = this.GetComponent<Mode2_ImpluseMomentumQuestionManager>();
        positions = positionParent.GetComponentsInChildren<Transform>();



        targetPosition = new Vector3[positions.Length];
        targetRotation = new Quaternion[positions.Length];


    }

    private void Start()
    {
       /* GetFirstPosition();*/


    }
    void Update()
    {
        GetFirstPosition();
        for (int i = 0; i <= positions.Length - 1; i++)
            {
                if (questionManager.dropdownMenu.value == i)
                {
                    tennisBall.transform.position = Vector3.Lerp(tennisBall.transform.position, targetPosition[i], Time.deltaTime * smoothFactor);
                    tennisBall.transform.rotation = Quaternion.Slerp(tennisBall.transform.rotation, targetRotation[i], Time.deltaTime * smoothFactor);
                }
            }
        

    }


    void GetFirstPosition() //This stores the data of the following starting rotation and position inside the array Quaternion and also the Vector
    {
        for (int i = 0; i <= positions.Length-1; i++)
        {
            targetPosition[i] = positions[i].position;
            targetRotation[i] = positions[i].rotation;
        }
    }
}
