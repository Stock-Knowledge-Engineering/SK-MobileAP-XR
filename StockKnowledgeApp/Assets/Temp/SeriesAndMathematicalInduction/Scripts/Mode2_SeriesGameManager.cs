using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_SeriesGameManager : MonoBehaviour
{
    private static Mode2_SeriesGameManager _instance;
    public static Mode2_SeriesGameManager Instance { get { return _instance; } }
    
    public GameObject[] enableOnStackChallengeComplete;
    public GameObject[] disableOnStackChallengeComplete;
    public GameObject prismsParent;


    public Mode2_SeriesPlayer player;
    internal int maxPrisms;
    internal int currentPrismsCount;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start(){
        // First, identify the target stacks at the bottom
        maxPrisms = prismsParent.GetComponentsInChildren<Mode2_SeriesPrism>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Cheat
        if (Input.GetKeyUp(KeyCode.Keypad0)) {
            Mode2_SeriesGameManager.Instance.Win();
        }
    }

    public void Win()
    {
        foreach(GameObject obj in enableOnStackChallengeComplete)
            obj.SetActive(true);
        foreach(GameObject obj in disableOnStackChallengeComplete)
        obj.SetActive(false);
    }
}
