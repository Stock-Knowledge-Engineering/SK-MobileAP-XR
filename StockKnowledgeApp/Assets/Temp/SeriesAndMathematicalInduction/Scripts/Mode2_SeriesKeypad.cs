using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Mode2_SeriesKeypad : MonoBehaviour
{
    public Button delButton;
    public TMP_Text inputText;
    public string targetValue;
    public UnityEvent onTargetValueEntered;
    public bool disableOnTargetValueEntered;
    private TMP_Text[] nums;

    bool isTyped;
    // Start is called before the first frame update
    void Start()
    {
        nums = GetComponentsInChildren<TMP_Text>();
        foreach(TMP_Text num in nums) {
            num.GetComponentInParent<Button>().onClick.AddListener(
                delegate{ RegisterClick(num.text); });
        }
    }

    private void RegisterClick(string text)
    {
        if (!isTyped) {
            inputText.text = "";
            isTyped = true;
        }
        inputText.text += text;
        if (inputText.text.Equals(targetValue)) {
            onTargetValueEntered.Invoke();
            if (disableOnTargetValueEntered) DisableOnTargetValueEntered();
        } 
    }

    private void DisableOnTargetValueEntered()
    {
        foreach(TMP_Text num in nums) {
            num.GetComponentInParent<Button>().interactable = false;
        }
        delButton.interactable = false;
    }

    public void DeleteChar() {
        if (inputText.text.Length > 1) {
            inputText.text = inputText.text.Remove(inputText.text.Length - 1);
        } else {
            inputText.text = "0";
            isTyped = false;
        }
    }

}
