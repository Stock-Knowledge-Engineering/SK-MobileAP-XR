using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Microscope Part", menuName = "MSParts")]
public class MicroscopeComponents : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite partImage;

    public AudioClip readDesc;
}
