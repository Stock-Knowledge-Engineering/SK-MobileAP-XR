/*************************************************************************************
 * 
 * This script will be attached on the mode buttons in the main menu.
 * This script will identify if the button is unlocked or not.
 * This gets the data from the player level script.
 * Input a value on the progressReq variable to set the unlock requirements.
 * Add conditions in the update for the other subject/topics
 * 
 * **NOTE: Use Camel Case for the string ID - "CamelCase"
 * 
 * **********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCondition : MonoBehaviour
{
    //public PlayerLevel playerLevel;

    public CurrentUser currentUser;

    public int progressReq;

    public Button btnMe;

    public GameObject Lockimage;

    [Header("Button Identifier")]
    public string buttonID;

    private void Start()
    {
        btnMe = GetComponent<Button>();
        currentUser = GameObject.FindObjectOfType<CurrentUser>();
    }

    // Update is called once per frame
    void Update()
    {
        //for chemistry
        if(progressReq <= currentUser.chemProgress && buttonID == "Chemistry")
        {
            //unlock this mode
            btnMe.interactable = true;
            Debug.Log("Chemistry button interactable");
            Lockimage.SetActive(false);
        }
        else if(progressReq > currentUser.chemProgress && buttonID == "Chemistry")
        {
            btnMe.interactable = false;
            Lockimage.SetActive(true);
        }

        //for earth science
        if (progressReq <= currentUser.esProgress && buttonID == "EarthScience")
        {
            //unlock this mode
            btnMe.interactable = true;
            Lockimage.SetActive(false);
        }
        else if (progressReq > currentUser.esProgress && buttonID == "EarthScience")
        {
            btnMe.interactable = false;
        }

        //for biology
        if (progressReq <= currentUser.bioProgress && buttonID == "Biology")
        {
            //unlock this mode
            btnMe.interactable = true;
            Lockimage.SetActive(false);
        }
        else if (progressReq > currentUser.bioProgress && buttonID == "Biology")
        {
            btnMe.interactable = false;
        }

        //for math
        if (progressReq <= currentUser.mathProgress && buttonID == "Math")
        {
            //unlock this mode
            btnMe.interactable = true;
            Lockimage.SetActive(false);
        }
        else if (progressReq > currentUser.mathProgress && buttonID == "Math")
        {
            btnMe.interactable = false;
        }

        //for physics
        if (progressReq <= currentUser.physicsProgress && buttonID == "Physics")
        {
            //unlock this mode
            btnMe.interactable = true;
            Lockimage.SetActive(false);
        }
        else if (progressReq > currentUser.physicsProgress && buttonID == "Physics")
        {
            btnMe.interactable = false;
        }
    }
    
}
