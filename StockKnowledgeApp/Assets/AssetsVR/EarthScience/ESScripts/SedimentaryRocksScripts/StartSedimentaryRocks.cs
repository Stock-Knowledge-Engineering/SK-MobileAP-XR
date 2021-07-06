using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSedimentaryRocks : MonoBehaviour
{
    public GameObject IntroPanel;
    public GameObject clastic;
    public GameObject chemical;
    public GameObject organic;

    void Start()
    {
        StartCoroutine(StartInteraction());
    }


    IEnumerator StartInteraction()
    {
        yield return new WaitForSeconds(7f);
        clastic.gameObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        chemical.gameObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        organic.gameObject.SetActive(true);
        yield return new WaitForSeconds(17f);
        IntroPanel.gameObject.SetActive(false);
    }
}