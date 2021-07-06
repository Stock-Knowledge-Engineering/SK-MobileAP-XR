using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMillikans : MonoBehaviour
{
    public GameObject IntroPanel;
    public GameObject InfoPanel;


    void Start()
    {
        Invoke("StartInteraction", 23f);
        Invoke("ShowParts", 18.5f);
    }

    void ShowParts()
    {
        InfoPanel.gameObject.SetActive(true);
    }

    void StartInteraction()
    {
        IntroPanel.gameObject.SetActive(false);
    }
}
