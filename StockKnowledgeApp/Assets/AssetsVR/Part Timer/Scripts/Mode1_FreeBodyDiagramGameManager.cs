using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mode1_FreeBodyDiagramGameManager : MonoBehaviour
{
    private bool isComplete;
    public float totalScore = 0;
    public float goal = 150;
    public int time;
    [Header("References")]
    public GameObject correctPoints;
    public GameObject sceneComplete;
    public GameObject items;

    private void Start()
    {
        items.SetActive(false);
        sceneComplete.SetActive(false);
        StartCoroutine(SpawnItem(time));
    }

    private void Update()
    {
        if (totalScore == goal && !isComplete)
        {
            isComplete = true;

            StartCoroutine(Complete(6f));
        }



    }

    public IEnumerator SpawnItem(float time)
    {
        yield return new WaitForSeconds(time); // Time is 10 seconds (Introduction)
        items.SetActive(true);
    }

    public IEnumerator Complete(float time)
    {
        yield return new WaitForSeconds(time);
        sceneComplete.SetActive(true);
    }

}

