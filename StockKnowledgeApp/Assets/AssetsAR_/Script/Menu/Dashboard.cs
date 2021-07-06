using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dashboard : MonoBehaviour
{
    public TMP_Text studentName;
    //public TMP_Text lastName;
    public CurrentUser _currentUser;

    
    public void Start()
    {
        _currentUser = GameObject.FindObjectOfType<CurrentUser>();
    }

    public void Update()
    {
        Debug.Log("");
        studentName.text = _currentUser.loginResponse.result[0].firstname;
        //studentName.text = _currentUser.loginResponse.result[0].lastname + ", " + _currentUser.loginResponse.result[0].middlename + " " + _currentUser.loginResponse.result[0].firstname;
        //studentName.text = _currentUser.loginResponse.result[0].username;
    }

    public void BackButton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Do something
            }
        }
    }
}
