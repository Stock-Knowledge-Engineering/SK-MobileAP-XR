using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMetamorphicRocks : MonoBehaviour
{
    public GameObject IntroPanel;
    public GameObject foliated;
    public GameObject nonfoliated;

    void Start()
    {
        StartCoroutine(StartInteraction());
    }


    IEnumerator StartInteraction()
    {
        yield return new WaitForSeconds(19f);
        foliated.gameObject.SetActive(true);
        yield return new WaitForSeconds(8f);
        nonfoliated.gameObject.SetActive(true);
        yield return new WaitForSeconds(17f);
        IntroPanel.gameObject.SetActive(false);
    }
}
