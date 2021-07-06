using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainLevelTemp : MonoBehaviour
{
    //Temporary Script

    public CurrentUser currentUser;
    public bool isLevelDone;
    public string subjectID;

    public void Start()
    {
        currentUser = GameObject.FindObjectOfType<CurrentUser>();

        //Will gain level upon entering this stage
    }

    public void Update()
    {
        if (isLevelDone == false)
        {
            PlayerPrefs.SetInt(subjectID, (PlayerPrefs.GetInt(subjectID) + 10));
            isLevelDone = true;
        }
    }
}
