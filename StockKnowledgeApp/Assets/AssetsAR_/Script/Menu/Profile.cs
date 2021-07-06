using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour
{
    [Header("Header")]
    public TMP_Text studentName;
    public TMP_Text schoolName;
    public TMP_Text gradeLevel;

    [Header("Body")]
    public Slider subject;
    public CurrentUser _currentUser;

    private void Awake()
    {
        _currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_currentUser = GameObject.FindObjectOfType<CurrentUser>();
    }

    // Update is called once per frame
    void Update()
    {

        Display();
    }

    public void Display()
    {
        studentName.text = _currentUser.loginResponse.result[0].firstname + " " + _currentUser.loginResponse.result[0].middlename + " " + _currentUser.loginResponse.result[0].lastname;
        schoolName.text = _currentUser.loginResponse.result[0].title;
        //gradeLevel.text = string.Format("{0}", _currentUser.loginResponse.result[0]);
    }

    public void Logout(string scene)
    {
        PlayerPrefs.SetString("CurrentUsername", "");
        PlayerPrefs.SetString("CurrentPassword", "");
        PlayerPrefs.SetString("IsRemembertrue", "false");

        SceneManager.LoadScene(scene);
    }
}
