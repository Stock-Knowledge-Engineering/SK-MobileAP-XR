using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Vuforia;

public class Mode2_ConversionGameManager : MonoBehaviour
{
    
    [Header("Model")]
    public int current3DModelInt;
    public int currentDescriptionInt;
    public int TotalQuestionAnswered;
    public GameObject[] _3DModel;

    [Header("UI")]
    public int playerScore;
    public TMP_Text _playerScoreText;
    public TMP_Text _currentPlayerScoreText;
    public TMP_Text _remainingQuestion;



    [Header("Gameobject")]
    public int totalQuestions;
    public GameObject finalScoreUI;
    //public GameObject choicesUI;
    public GameObject correctPoints;
    public GameObject wrongPoints;

    public void Start()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();

    }
    public void Update()
    {
        if (TotalQuestionAnswered == totalQuestions)
        {
            FinalCheck();
        }

        _currentPlayerScoreText.text = playerScore.ToString();
        _remainingQuestion.text = "" + (totalQuestions - TotalQuestionAnswered);
    }

    public void FinalCheck()
    {
        finalScoreUI.SetActive(true);
        _playerScoreText.text = playerScore.ToString() + "  / " + totalQuestions;
    }

    public void ScoreAdd()
    {
        playerScore++;
    }

    public void CorrectAnswer()
    {
        TotalQuestionAnswered++;
        ScoreAdd();
        correctPoints.SetActive(true);
        _3DModel[current3DModelInt].GetComponent<Mode2_ConversionModel>().choices.SetActive(false);
        _3DModel[current3DModelInt].GetComponent<Mode2_ConversionModel>().hasAnswered = true;
    }

    public void IncorrectAnswer()
    {
        TotalQuestionAnswered++;
        wrongPoints.SetActive(true);
        _3DModel[current3DModelInt].GetComponent<Mode2_ConversionModel>().choices.SetActive(false);
        _3DModel[current3DModelInt].GetComponent<Mode2_ConversionModel>().hasAnswered = true;
    }

    public void Pause()

    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();

    }

    public void Resume()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();

    }
}