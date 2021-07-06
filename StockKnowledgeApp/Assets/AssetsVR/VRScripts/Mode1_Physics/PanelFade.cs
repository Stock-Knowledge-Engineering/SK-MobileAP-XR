using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PanelFade : MonoBehaviour
{
    // Used for fading UI Easily.
    [Tooltip("Check to Fade In or Uncheck to Fade Out")]
    public bool isFadeIn; // Check to Fade In , Uncheck for Fade Out
    private bool mFaded = false;
    [Tooltip("Panel or Canvas to Fade")]
    private GameObject panel; // Canvas or Panel to Fade
    private CanvasGroup canvGroup;

    [Header("TIMER")]
    [Tooltip("Countdown for Fade In or Fade Out")]
    public float countDown; // Countdown for Fade In || Fade Out
    [Tooltip("Fading Duration")]
    public float duration = 0.4f; // Fading Duration


    private void Start()
    {
        panel = this.gameObject;
        canvGroup = GetComponent<CanvasGroup>();
        

        if (!isFadeIn)
        {
            canvGroup.alpha = 1;
            StartCoroutine(CountDown(countDown, 1, 0));

        }
        else
        {
            canvGroup.alpha = 0;
            StartCoroutine(CountDown(countDown, 0, 1));
        }
    }
    
    public void Fade()
    {
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

    }



    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;        
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }

    }

    public IEnumerator CountDown(float seconds, float start, float end)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? start : end));

    }






}
