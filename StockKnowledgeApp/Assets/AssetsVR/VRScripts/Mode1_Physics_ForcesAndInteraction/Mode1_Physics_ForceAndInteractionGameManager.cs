using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mode1_Physics_ForceAndInteractionGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneManagement[] sceneManager;
    public AudioManager audioManager;

    public GameObject sceneComplete;
    public int time;
    public int _currentScene;
    public bool selectedItem = false;
    public GameObject nextTopic;
    [Header("Point System")]
    public GameObject correctPoints;
    public int playerScore;
    public int totalScore;
    public int goalScore;
    private bool isComplete = false;

    [Header("Fade")]
    public GameObject fadeToBlack;


    void Start()
    {
        sceneManager[_currentScene].startButton.SetActive(false);
        sceneComplete.SetActive(false);
        StartCoroutine(SpawnItem(time));
    }


    // Update is called once per frame
    void Update()
    {
        if (!isComplete && playerScore == 350)
        {
            sceneComplete.SetActive(true);
            isComplete = true;
        }


        if (playerScore == 150)
        {
            Invoke("NextTopic", 3f);
        }

        
    }
    public IEnumerator SpawnItem(float time)
    {
        yield return new WaitForSeconds(time); // Time is 10 seconds (Introduction)
        sceneManager[_currentScene].startButton.SetActive(true);
    }

    public void MoveToNextScene()
    {
        StartCoroutine(FadeBlackScreen(2));
    }

    public IEnumerator FadeBlackScreen(float time)
    {
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(time); // Time is 10 seconds (Introduction)
        sceneManager[_currentScene].scenes.SetActive(false);
        sceneManager[_currentScene].isDone = true;
        _currentScene++;
        sceneManager[_currentScene].scenes.SetActive(true);
        fadeToBlack.SetActive(false);
        audioManager.Play(2);

    }

    void NextTopic()
    {
        nextTopic.SetActive(true); 
        
    }



}


[System.Serializable]
public class SceneManagement
{
    [Header("SCENE MANAGER")]
    public GameObject scenes;
    public bool isDone;
    public GameObject startButton;
}
