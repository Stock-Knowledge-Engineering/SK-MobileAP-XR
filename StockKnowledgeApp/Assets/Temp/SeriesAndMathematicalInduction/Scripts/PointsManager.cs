using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PointsManager : MonoBehaviour
{
    private static PointsManager _instance;
    public static PointsManager Instance { get { return _instance; } }
    public int currentScore = 0;
    public int incrementScore = 50;
    public float showInSeconds = 1f;
    public TMP_Text totalScoreText;

    [Header("SFX")] 
    public AudioClip sfxCorrect;
    public AudioClip sfxIncorrect;

    [Header("UI")] 
    public GameObject pointsUI;
    public GameObject incorrectUI;
    

    AudioSource audioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void AddPoints() {
        currentScore += incrementScore;
        StartCoroutine(ShowPointsUI());
        totalScoreText?.SetText(currentScore.ToString());
    }

    public void Incorrect() {
        StartCoroutine(ShowIncorrectUI());
    }

    private IEnumerator ShowIncorrectUI()
    {
        incorrectUI.SetActive(true);
        audioSource.PlayOneShot(sfxIncorrect);
        yield return new WaitForSeconds(showInSeconds);
        incorrectUI.SetActive(false);
    }
    private IEnumerator ShowPointsUI()
    {
        pointsUI.SetActive(true);
        audioSource.PlayOneShot(sfxCorrect);
        yield return new WaitForSeconds(showInSeconds);
        pointsUI.SetActive(false);
    }

}
