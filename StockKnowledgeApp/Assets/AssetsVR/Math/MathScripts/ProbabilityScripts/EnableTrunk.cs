using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTrunk : MonoBehaviour
{
    public GameObject putBagHere;
    public GameObject triggerAbduction;

    public void PutBagHereActivate()
    {
        putBagHere.gameObject.SetActive(true);
    }

    public void AbductionStart()
    {
        triggerAbduction.gameObject.SetActive(true);
    }
}
