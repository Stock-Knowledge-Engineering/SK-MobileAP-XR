using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_ConversionModel : MonoBehaviour
{
    [Header("Reference")]
    public Mode2_ConversionGameManager _ConversionGameManager;
    public string soundName;
    public bool hasAnswered = false;
    public int modelNum;
    public GameObject choices;
    public MeshRenderer meshRenderer;

    public GameObject correctAnswer;
    [Header("Model Properties")]
    public bool isOptionOne;
    public bool isOptionTwo;
    public bool isOptionThree;
    
    
    public void Start()
    {
        _ConversionGameManager = GameObject.FindObjectOfType<Mode2_ConversionGameManager>();
    }

    public void Update()
    {
        if (meshRenderer.enabled == true)
        {

            _ConversionGameManager.current3DModelInt = modelNum;
            if (hasAnswered == false)
            {
                choices.SetActive(true);
            }

            if (hasAnswered == true) 
            {
                correctAnswer.SetActive(true);

            }
        }
        else if (meshRenderer.enabled == false)
        {
            choices.SetActive(false);
            correctAnswer.SetActive(false);

        }
    }




}
