using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DartBoard_GameManager : MonoBehaviour
{
    public GameObject[] dartsInScene; //count the number of darts in the scene
    public float currentAccuracyScore; //The final Accuracy score (To update later)
    public float currentPercisionScore; //The final score (To update later)
    public int numberOFDartsInScene; 
    public DartShoot _shoot;
    public ARDart[] _arDart; //Dart GameObject Script
    public float maxDartForce; //Maximume force of the dart
    public bool isGameDone; //if all 5 darts has been fired
    public bool isTuitorialDone;

    //================ FOR PERCISION ===============
    public float[] distanceToOtherDart; //Distance from the first dart 
    public float[] distanceToOtherDartAve; //Average distance to the other darts
    public int[] percisionRate;

    //For UI Canvas
    public TMP_Text textAccuracyScore;
    public TMP_Text textPercisionScore;
    public Slider powerValue;
    public string SceneToBeLoaded;
    public GameObject tuitorialPanel;

    void Start()
    {
        _shoot = GameObject.FindObjectOfType<DartShoot>();
    }

    
    void Update()
    {
        dartsInScene = GameObject.FindGameObjectsWithTag("Dart");
        
        DartNumberLimiter();
        DartBoardScoreCheck();
    }

    public void DartBoardScoreCheck()
    {
        if (numberOFDartsInScene >= 1)
        {
            _arDart[numberOFDartsInScene-1] = dartsInScene[numberOFDartsInScene-1].GetComponent<ARDart>();
            
            //Individual dart score
            if (_arDart[numberOFDartsInScene - 1].distanceToCenter <= 0.05f)
            {
                Debug.Log("Exellent: " + _arDart[numberOFDartsInScene - 1].distanceToCenter);
            } 
            else if (_arDart[numberOFDartsInScene - 1].distanceToCenter <= 0.1f)
            {
                Debug.Log("Very Good: " + _arDart[numberOFDartsInScene - 1].distanceToCenter);
            } 
            else if (_arDart[numberOFDartsInScene - 1].distanceToCenter <= 0.15f)
            {
                Debug.Log("Good: " + _arDart[numberOFDartsInScene - 1].distanceToCenter);
            }
            else if (_arDart[numberOFDartsInScene - 1].distanceToCenter <= 0.2f)
            {
                Debug.Log("Nice: " + _arDart[numberOFDartsInScene - 1].distanceToCenter);
            }
            else if (_arDart[numberOFDartsInScene - 1].distanceToCenter <= 0.25f)
            {
                Debug.Log("Satisfactory: " + _arDart[numberOFDartsInScene - 1].distanceToCenter);
            }
            else
            {
                Debug.Log("No Score: " + _arDart[numberOFDartsInScene - 1].distanceToCenter);
            }

            if (numberOFDartsInScene == 5 && isGameDone == true) //Compute Final Score to Update later
            {

                AccuracyComputation();
                PercisionComputation();
            }
        }
    }

    public void DartNumberLimiter() //Check how many darts are in the scene
    {
        numberOFDartsInScene = dartsInScene.Length;
        if (numberOFDartsInScene >= 5)
        {
            _shoot.canShoot = false;
        }
    }

    public void AccuracyComputation() //Accuracy Computation
    {
        currentAccuracyScore = (_arDart[0].distanceToCenter + _arDart[1].distanceToCenter + _arDart[2].distanceToCenter + _arDart[3].distanceToCenter + _arDart[4].distanceToCenter) / 5;
        
        //Score Rating For Accuracy
        if (currentAccuracyScore <= 0.05f)
        {
            Debug.Log("Exellent Accuracy: " + currentAccuracyScore);
            textAccuracyScore.text = "Exellent Accuracy: " + currentAccuracyScore;
        }
        else if (currentAccuracyScore <= 0.1f)
        {
            Debug.Log("Very Good Accuracy: " + currentAccuracyScore);
            textAccuracyScore.text = "Very Good Accuracy: " + currentAccuracyScore;
        }
        else if (currentAccuracyScore <= 0.15f)
        {
            Debug.Log("Good Accuracy: " + currentAccuracyScore);
            textAccuracyScore.text = "Good Accuracy: " + currentAccuracyScore;
        }
        else if (currentAccuracyScore <= 0.2f)
        {
            Debug.Log("Nice Accuracy: " + currentAccuracyScore);
            textAccuracyScore.text = "Nice Accuracy: " + currentAccuracyScore;
        }
        else if (currentAccuracyScore <= 0.25f)
        {
            Debug.Log("Satisfactory Accuracy: " + currentAccuracyScore);
            textAccuracyScore.text = "Satisfactory Accuracy: " + currentAccuracyScore;
        }
        else
        {
            Debug.Log("Lacking Accuracy: " + currentAccuracyScore);
            textAccuracyScore.text = "Lacking Accuracy: " + currentAccuracyScore;
        }
    }

    public void PercisionComputation() //Percision Computation
    {
        
        //textPercisionScore.text = "Failed to shoot 5 darts on the board"; 
        //=============== Distance to other Dart ==============
        //Dart 0
        distanceToOtherDart[0] = Vector3.Distance(dartsInScene[0].transform.position, dartsInScene[1].transform.position);
        distanceToOtherDart[1] = Vector3.Distance(dartsInScene[0].transform.position, dartsInScene[2].transform.position);
        distanceToOtherDart[2] = Vector3.Distance(dartsInScene[0].transform.position, dartsInScene[3].transform.position);
        distanceToOtherDart[3] = Vector3.Distance(dartsInScene[0].transform.position, dartsInScene[4].transform.position);

        //Dart 1
        distanceToOtherDart[4] = Vector3.Distance(dartsInScene[1].transform.position, dartsInScene[0].transform.position);
        distanceToOtherDart[5] = Vector3.Distance(dartsInScene[1].transform.position, dartsInScene[2].transform.position);
        distanceToOtherDart[6] = Vector3.Distance(dartsInScene[1].transform.position, dartsInScene[3].transform.position);
        distanceToOtherDart[7] = Vector3.Distance(dartsInScene[1].transform.position, dartsInScene[4].transform.position);

        //Dart 2
        distanceToOtherDart[8] = Vector3.Distance(dartsInScene[2].transform.position, dartsInScene[0].transform.position);
        distanceToOtherDart[9] = Vector3.Distance(dartsInScene[2].transform.position, dartsInScene[1].transform.position);
        distanceToOtherDart[10] = Vector3.Distance(dartsInScene[2].transform.position, dartsInScene[3].transform.position);
        distanceToOtherDart[11] = Vector3.Distance(dartsInScene[2].transform.position, dartsInScene[4].transform.position);

        //Dart 3
        distanceToOtherDart[12] = Vector3.Distance(dartsInScene[3].transform.position, dartsInScene[0].transform.position);
        distanceToOtherDart[13] = Vector3.Distance(dartsInScene[3].transform.position, dartsInScene[1].transform.position);
        distanceToOtherDart[14] = Vector3.Distance(dartsInScene[3].transform.position, dartsInScene[2].transform.position);
        distanceToOtherDart[15] = Vector3.Distance(dartsInScene[3].transform.position, dartsInScene[4].transform.position);

        //Dart 4
        distanceToOtherDart[16] = Vector3.Distance(dartsInScene[4].transform.position, dartsInScene[0].transform.position);
        distanceToOtherDart[17] = Vector3.Distance(dartsInScene[4].transform.position, dartsInScene[1].transform.position);
        distanceToOtherDart[18] = Vector3.Distance(dartsInScene[4].transform.position, dartsInScene[2].transform.position);
        distanceToOtherDart[19] = Vector3.Distance(dartsInScene[4].transform.position, dartsInScene[3].transform.position);

        //=============== Distance to other Dart Average ============
        distanceToOtherDartAve[0] = (distanceToOtherDart[0] + distanceToOtherDart[1] + distanceToOtherDart[2] + distanceToOtherDart[3]) / 4;
        distanceToOtherDartAve[1] = (distanceToOtherDart[4] + distanceToOtherDart[5] + distanceToOtherDart[6] + distanceToOtherDart[7]) / 4;
        distanceToOtherDartAve[2] = (distanceToOtherDart[8] + distanceToOtherDart[9] + distanceToOtherDart[10] + distanceToOtherDart[11]) / 4;
        distanceToOtherDartAve[3] = (distanceToOtherDart[12] + distanceToOtherDart[13] + distanceToOtherDart[14] + distanceToOtherDart[15]) / 4;
        distanceToOtherDartAve[4] = (distanceToOtherDart[16] + distanceToOtherDart[17] + distanceToOtherDart[18] + distanceToOtherDart[19]) / 4;

        //Individual Dart Score Rating
        for (int i = 0; i <= 4; i++)
        {
            if (distanceToOtherDartAve[i] <= 0.05f)
            {
                percisionRate[i] = 10;
            } 
            else if (distanceToOtherDartAve[i] <= 0.07f)
            {
                percisionRate[i] = 9;
            }
            else if (distanceToOtherDartAve[i] <= 0.09f)
            {
                percisionRate[i] = 8;
            }
            else if (distanceToOtherDartAve[i] <= 0.11f)
            {
                percisionRate[i] = 7;
            }
            else if (distanceToOtherDartAve[i] <= 0.13f)
            {
                percisionRate[i] = 6;
            }
            else if (distanceToOtherDartAve[i] <= 0.3f)
            {
                percisionRate[i] = 5;
            }
            else if (distanceToOtherDartAve[i] <= 0.4f)
            {
                percisionRate[i] = 3;
            }
        }

        //Score Rating For Percision
        currentPercisionScore = percisionRate[0] + percisionRate[1] + percisionRate[2] + percisionRate[3] + percisionRate[4];

        if (currentPercisionScore >= 45)
        {
            Debug.Log("Exellent Precision: " + currentPercisionScore);
            textPercisionScore.text = "Exellent Precision: " + currentPercisionScore;
        }
        else if (currentPercisionScore >= 40)
        {
            Debug.Log("Very Good Precision: " + currentPercisionScore);
            textPercisionScore.text = "Very Good Precision: " + currentPercisionScore;
        }
        else if (currentPercisionScore >= 35)
        {
            Debug.Log("Good Precision: " + currentPercisionScore);
            textPercisionScore.text = "Good Precision: " + currentPercisionScore;
        }
        else if (currentPercisionScore >= 30)
        {
            Debug.Log("Nice Precision: " + currentPercisionScore);
            textPercisionScore.text = "Nice Precision: " + currentPercisionScore;
        }
        else if (currentPercisionScore >= 25)
        {
            Debug.Log("Satisfactory Precision: " + currentPercisionScore);
            textPercisionScore.text = "Satisfactory Precision: " + currentPercisionScore;
        }
        else if (currentPercisionScore >= 1)
        {
            Debug.Log("Lacking Precision: " + currentPercisionScore);
            textPercisionScore.text = "Lacking Precision: " + currentPercisionScore;
        }
        else
        {
            textPercisionScore.text = "Failed to shoot 5 darts on the board" + currentPercisionScore;
        }
    }


    public void GameReset() //Reload the scene
    {
        SceneManager.LoadScene(SceneToBeLoaded);
    }

    public void VibratePowerValue() //Vibrate the slider (To follow)
    {
        //to follow
    }
}
