using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIgneusRocks : MonoBehaviour
{
    public GameObject IntroPanel;
    public GameObject iir;
    public GameObject eir;

    void Start()
    {
        StartCoroutine(StartInteraction());
        Invoke("StartInteraction", 28f);
    }


    IEnumerator StartInteraction()
    {
        yield return new WaitForSeconds(13f);
        iir.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        eir.gameObject.SetActive(true);
        yield return new WaitForSeconds(15f);
        IntroPanel.gameObject.SetActive(false);
    }
}
