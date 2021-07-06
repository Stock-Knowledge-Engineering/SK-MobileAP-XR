using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMillikansInfoUI : MonoBehaviour
{
    public GameObject InfoUI;

    public void ShowInfoUI()
    {
        InfoUI.gameObject.SetActive(true);
    }
}
