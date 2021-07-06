/*************************************************************************************
 * 
 * This script will hold the variables for the player level and experience points.
 * This script will also define the individual level progress of each subject/topic.
 * This will be attached on a game/scene/menu manager
 * 
 * **********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [Header("General Info")]
    public int playerLevel;
    public int playerExp;

    [Header("Subject Topics")]
    [Header("Biology")]
    public int bioProgress;

    [Header("Chemistry")]
    public int chemProgress;

    [Header("Earth Science")]
    public int esProgress;

    [Header("Math")]
    public int mathProgress;

    [Header("Physics")]
    public int physicsProgress;


    // Update is called once per frame
    void Update()
    {
        //use prefs or JSON
    }
}
