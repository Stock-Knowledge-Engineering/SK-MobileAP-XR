using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PointsManager : MonoBehaviour
{
    private static PointsManager _instance;
    public static PointsManager Instance { get { return _instance; } }
    public int currentScore = 0;
    public int incrementScore = 50;
    public float showInSeconds = 1f;

    [Header("UI")] 
    public AudioClip sfx;

    [Header("UI")] 
    public GameObject pointsUI;

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
    }

    private IEnumerator ShowPointsUI()
    {
        pointsUI.SetActive(true);
        audioSource.PlayOneShot(sfx);
        yield return new WaitForSeconds(showInSeconds);
        pointsUI.SetActive(false);
    }

}
