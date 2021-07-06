using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mode2_RocksandMineralsGameManager : MonoBehaviour
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
    public GameObject finalScoreUI;
    //public GameObject choicesUI;
    public GameObject correctPoints;
    public GameObject wrongPoints;

    public void Update()
    {
        if (TotalQuestionAnswered == 31)
        {
            FinalCheck();
        }

        _currentPlayerScoreText.text = playerScore.ToString();
        _remainingQuestion.text = "" + (31 - TotalQuestionAnswered);
    }

    public void FinalCheck()
    {
        finalScoreUI.SetActive(true);
        _playerScoreText.text = playerScore.ToString() + "  /  31";
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
        _3DModel[current3DModelInt].GetComponent<Mode2_RocksandMineralsModel>().choices.SetActive(false);
        _3DModel[current3DModelInt].GetComponent<Mode2_RocksandMineralsModel>().hasAnswered = true;
    }

    public void IncorrectAnswer()
    {
        TotalQuestionAnswered++;
        wrongPoints.SetActive(true);
        _3DModel[current3DModelInt].GetComponent<Mode2_RocksandMineralsModel>().choices.SetActive(false);
        _3DModel[current3DModelInt].GetComponent<Mode2_RocksandMineralsModel>().hasAnswered = true;
    }
}