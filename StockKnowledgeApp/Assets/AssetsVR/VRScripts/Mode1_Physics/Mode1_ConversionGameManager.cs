using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode1_ConversionGameManager : MonoBehaviour
{
    private bool isComplete;
    public float totalScore = 0;
    [Header("References")]
    public GameObject correctPoints;
    public GameObject sceneComplete;
    public GameObject items;
    
    

    private void Start()

    {
        items.SetActive(false);
        sceneComplete.SetActive(false);
        StartCoroutine(SpawnItem(10));


    }

    private void Update()
    {
        if (totalScore == 250 && !isComplete) 
        {
            isComplete = true;
            sceneComplete.SetActive(true);
        }
    }

    public IEnumerator SpawnItem(float time)
    {
        yield return new WaitForSeconds(time); // Time is 10 seconds (Introduction)
        items.SetActive(true);


    }



}


