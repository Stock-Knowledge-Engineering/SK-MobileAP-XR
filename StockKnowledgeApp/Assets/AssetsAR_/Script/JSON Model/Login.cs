using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System;
using System.Text;
using System.IO;

public class Login : MonoBehaviour
{
    //=============== Login GameObjects ===================
    public TMP_InputField userNameText;
    public TMP_InputField passwordText;
    public TMP_Text errorMessageText;
    public Toggle RememberMeToggle;
    //public TMP_Text currentUserText; //debug
    public Button EyeButton;

    public string _userNameText; //remove once not needed
    public string _passwordText;
    bool usernameExist;
    bool rememberMeIsTrue;

    //public LoginResponse loginResponse;
    public CurrentUser _currentUser;
    private static readonly HttpClient client = new HttpClient();

    public string SERVER_DOMAIN;

    public void Awake() //Check if the user pressed rememberme
    {
        PlayerPrefs.SetString("IsRemembertrue", "true");
        _currentUser = GameObject.FindObjectOfType<CurrentUser>();
        //currentUserText.text = PlayerPrefs.GetString("CurrentUsername");
        //DoLogin();
        RememberMeCheck();
    }

    public void LoginCheck()//checking if username exist
    {
        if (userNameText.text == "" || passwordText.text == "")
        {
            errorMessageText.text = "Please fill out the username and password fields";
        }
        else {
            if (usernameExist == true)
            {
                //existing user
                Debug.Log("=======existing user=======");
                PasswordCheck();
            }
            else if (usernameExist == false)
            {
                errorMessageText.text = "Username does not exist";
                Debug.Log("Username does not exist");
            }
        }
    }

    public void PasswordCheck() //checking if correct password
    {
        if (_currentUser.loginResponse.success == true) //won't really do anything this is here just for login testing
        {
            //Debug.Log(loginResponse.result.ToString());
            errorMessageText.text = "";
            //correct password
        }
        else if (_currentUser.loginResponse.success == false)
        {
            //Incorrect password
            errorMessageText.text = "Incorrect password";
        }
    }

    public string GetRequest(string endpoint)
    {
        var http = (HttpWebRequest)WebRequest.Create(new Uri(string.Format("{0}{1}", SERVER_DOMAIN, endpoint))); //link to login. Insert api here
        http.Accept = "application/json";
        http.ContentType = "application/json";
        http.Method = "GET";

        ASCIIEncoding encoding = new ASCIIEncoding();

        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        var content = sr.ReadToEnd();

        return content.ToString();
    }

    public string PostRequest(string endpoint, JObject data)
    {
        var http = (HttpWebRequest)WebRequest.Create(new Uri(string.Format("{0}{1}", SERVER_DOMAIN, endpoint))); //link to login. Insert api here
        http.Accept = "application/json";
        http.ContentType = "application/json";
        http.Method = "POST";

        ASCIIEncoding encoding = new ASCIIEncoding();
        Byte[] bytes = encoding.GetBytes(data.ToString());

        Stream newStream = http.GetRequestStream();
        newStream.Write(bytes, 0, bytes.Length);
        newStream.Close();

        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        var content = sr.ReadToEnd();

        return content.ToString();
    }

    public void DoLogin()
    {
        var data = new JObject();

        var credential = new JObject();

        credential["username"] = userNameText.text;
        credential["password"] = passwordText.text;

        data["data"] = credential;
        string content = _currentUser.PostRequest("/login", data);

        _currentUser.loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);
        Debug.Log(userNameText.text);
        Debug.Log(passwordText.text);

        if (_currentUser.loginResponse.success)
        {
            Debug.Log(_currentUser.loginResponse.result[0].username);
            //errorMessageText.text = "";
            RememberMe();
            SceneManager.LoadScene("Dashboard");
        }
        string usernameContent = _currentUser.GetRequest(String.Format("/register/verify/username?value={0}", userNameText.text));
        usernameExist = JsonConvert.DeserializeObject<bool>(usernameContent);

        LoginCheck();
    }

    public void RememberMe()
    {
        if (RememberMeToggle.isOn == true)
        {
            rememberMeIsTrue = true;
            PlayerPrefs.SetString("IsRemembertrue", "true");
            PlayerPrefs.Save();
        }
        else if (RememberMeToggle.isOn == false)
        {
            rememberMeIsTrue = false;
            PlayerPrefs.SetString("IsRemembertrue", "false");
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetString("CurrentUsername", userNameText.text);
        PlayerPrefs.SetString("CurrentPassword", passwordText.text);
        PlayerPrefs.Save();
    }

    public void RememberMeCheck()
    {
        Debug.Log("Remeber Value=====" + PlayerPrefs.GetString("IsRemembertrue"));
        if (PlayerPrefs.GetString("IsRemembertrue") == "true")
        {
            Debug.Log("IsRemembertrue = true");
            userNameText.text = PlayerPrefs.GetString("CurrentUsername");
            passwordText.text = PlayerPrefs.GetString("CurrentPassword");
            DoLogin();
        }
        else if (PlayerPrefs.GetString("IsRemembertrue") == "false")
        {
            Debug.Log("IsRemembertrue = false"); //Play as normal
        }
    }

    public void DebugLogin()
    {
        /*userNameText.text = "sample";
        passwordText.text = "SampleStudent@1"; */

        //DoLogin();
    }

    public void Eye()
    {
        if (passwordText.contentType == TMP_InputField.ContentType.Password)
        {
            passwordText.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            passwordText.contentType = TMP_InputField.ContentType.Password;
            EyeButton.interactable = false;
            EyeButton.interactable = true;
        }
        passwordText.ForceLabelUpdate();
    }
}
