using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Metamorphic Rock", menuName = "MetamorphicRock")]
public class SOMetamorphicRocks : ScriptableObject
{
    public new string name;
    public string description;

    //public Sprite partImage;

    public AudioClip readDesc;
}
