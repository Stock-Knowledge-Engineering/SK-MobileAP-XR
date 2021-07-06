using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSolarSystem : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject introText;
    public GameObject controller;
    public GameObject objectEarth;
    public GameObject lightSpeed;
    public GameObject objectSun;


    void Start()
    {
        StartCoroutine(StartInteraction());
    }


    IEnumerator StartInteraction()
    {
        yield return new WaitForSeconds(5f);
        objectEarth.gameObject.SetActive(false);
        lightSpeed.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        introText.gameObject.SetActive(false);

        yield return new WaitForSeconds(27f);
        controller.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        lightSpeed.gameObject.SetActive(false);
        objectSun.gameObject.SetActive(true);

        yield return new WaitForSeconds(23f);
        introPanel.gameObject.SetActive(false);
    }
}
