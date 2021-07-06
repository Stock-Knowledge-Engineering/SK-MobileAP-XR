using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode1_FreeFallButtonManager : MonoBehaviour
{
    public Mode1_FreeFallAudioManager ff;

    public void BtnFreeFall()
    {
        StartCoroutine(ff.FreefallPressed());
        ff.freeFallButton.interactable = false;
    }

    public void BtnAirResist()
    {
        StartCoroutine(ff.AirResistancePressed());
        ff.airResistanceButton.interactable = false;
    }

}
