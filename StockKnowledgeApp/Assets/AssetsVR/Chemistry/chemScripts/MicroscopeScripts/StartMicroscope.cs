using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMicroscope : MonoBehaviour
{
    public GameObject IntroPanel;

    public Animator animator;

    void Start()
    {
        Invoke("StartInteraction",18f);
    }

    
    void StartInteraction()
    {
        IntroPanel.gameObject.SetActive(false);
        animator.SetBool("isStarted", true);
    }

}
