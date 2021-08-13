using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicManager : MonoBehaviour
{
    private Mode1_Physics_ForceAndInteractionGameManager gameManager;
    public Tire sceneOne;
    [HideInInspector]
    public string selectedObject;
    public AudioManager audioManager;

    [Header("FORCES - SCENE ONE")]
    public TypesOfForces[] _forces;
    [Header("TENSION - SCENE TWO")]
    public Tension[] tension;

    public void Start()
    {
        gameManager = GetComponent<Mode1_Physics_ForceAndInteractionGameManager>();
        
    }


    private void Update()
    {
        if(!gameManager.sceneManager[0].isDone)
        {
            if (selectedObject != "")
            {
                foreach (TypesOfForces f in _forces)
                {
                    f.forceType.SetActive(f.forceName == selectedObject ? true : false);
                    f.description.SetActive(f.forceName == selectedObject ? true : false);
                    if (!f.isScored && f.forceName == selectedObject)
                    {
                        audioManager.PlayClip(f.audioClip);
                        PointSystem();
                        f.isScored = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= _forces.Length - 1; i++)
                {
                    _forces[i].forceType.SetActive(true);
                    _forces[i].description.SetActive(false);
                }
            }

        }


        if (gameManager.sceneManager[0].isDone)
        {
            foreach (Tension t in tension)
            {
                if (selectedObject != "")
                {
                    t.description.SetActive(t.tension == selectedObject ? true : false);
                    if (!t.isScored && t.tension== selectedObject)
                    {
                        audioManager.PlayClip(t.audioClip);
                        PointSystem();
                        t.isScored = true;
                    }
                }
            }
        }

        else
        {
            for (int i = 0; i <= tension.Length - 1; i++)
            {
                tension[i].description.SetActive(false);
            }
        }
    }


    void PointSystem()
    {
        gameManager.playerScore += 50;
        gameManager.correctPoints.SetActive(true);
    }
    public void GetObjectName(string name)
    {
        selectedObject = name;
    }
}

[System.Serializable]
public class TypesOfForces
{
    public string forceName;
    public GameObject forceType;
    public GameObject description;
    public AudioClip audioClip;
    public bool isScored;
}

[System.Serializable]

public class Tension
{
    public string tension;
    public GameObject interactable; 
    public GameObject description;
    public AudioClip audioClip;
    public bool isScored;
}
