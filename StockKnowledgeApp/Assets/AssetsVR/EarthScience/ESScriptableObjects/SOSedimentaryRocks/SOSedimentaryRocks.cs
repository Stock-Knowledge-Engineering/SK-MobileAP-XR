using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sedimentary Rock", menuName = "SedimentaryRock")]
public class SOSedimentaryRocks : ScriptableObject
{
    public new string name;
    public string description;

    //public Sprite partImage;

    public AudioClip readDesc;
}
