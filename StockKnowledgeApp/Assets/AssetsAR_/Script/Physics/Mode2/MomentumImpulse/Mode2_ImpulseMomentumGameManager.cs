using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Vuforia;

public class Mode2_ImpulseMomentumGameManager : MonoBehaviour
{
    private Mode2_ImpulseMomentumQuestionManager questionManager;
    private bool isComplete;
    public float totalScore = 0;

    [Header("References")]
    public GameObject correctPoints;
    public GameObject wrongPoints;
    public GameObject sceneComplete;
    public MeshRenderer modelRenderer;
    public GameObject userInterface;
    /*private TouchScreenKeyboard mobileKeyboard;*/

    [Header("UI")]
    public GameObject finalScoreUI;

    public GameObject correct;
    public TextMeshProUGUI _playerScoreText;
    private int totalQuestions = 4;
    public int playerScore;
    public int totalQuestionAnswered;
    public TextMeshProUGUI completedText;



    public void Start()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
    }



    void Update()
    {
        userInterface.SetActive(modelRenderer.enabled ? true : false);



        if (totalQuestionAnswered == 4 && !isComplete)
        {
            isComplete = true;
            sceneComplete.SetActive(true);
            completedText.text = "Total Correct Answer: " + playerScore / 50 +
            "\nTotal Questions:" + totalQuestionAnswered +
            "\nTotal Score: " + playerScore;
        }

        _playerScoreText.text = playerScore.ToString();


    }

    public void ScoreAdd()
    {
        playerScore += 50;
    }


    public void CorrectAnswer()
    {
        totalQuestionAnswered++;
        ScoreAdd();
        correctPoints.SetActive(true);
    }

    public void IncorrectAnswer()
    {
        totalQuestionAnswered++;
        wrongPoints.SetActive(true);

    }

    public void FinalCheck()
    {
        finalScoreUI.SetActive(true);
        _playerScoreText.text = playerScore.ToString() + "  / " + totalQuestions;
    }


    /*
        public void KeyboardTest()
        {
            TouchScreenKeyboard mobileKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, true);
            if (mobileKeyboard.done)
            {

            }
        }*/

    public void Pause()

    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();

    }

    public void Resume()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();

    }


}
