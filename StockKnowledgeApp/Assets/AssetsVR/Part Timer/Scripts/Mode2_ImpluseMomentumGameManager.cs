using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mode2_ImpluseMomentumGameManager : MonoBehaviour
{
    private bool isComplete;
    public float totalScore = 0;
    [Header("References")]
    public GameObject correctPoints;
    public GameObject sceneComplete;




    void Update()
    {
        if (totalScore == 200 && !isComplete)
        {
            isComplete = true;
            sceneComplete.SetActive(true);
        }
    }






}
