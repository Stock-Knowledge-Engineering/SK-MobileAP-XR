using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //public TMP_Text userNameText;
    //public TMP_Text passwordText;
    public TMP_InputField userNameText;
    public TMP_InputField passwordText;
    public TMP_Text errorMessageText;

    public string _userNameText;
    public string _passwordText;

    public LoginResponse loginResponse;

    public UsernameResponse usernameResponse;
    private static readonly HttpClient client = new HttpClient();


    public void UsernameCheck()
    {
        if (usernameResponse.success == true)
        {
            //existing user
            Debug.Log("=======existing user=======");
        }
    }

    public void PasswordCheck() //checking if correct password
    {
        if (loginResponse.success == true)
        {
            Debug.Log(loginResponse.result.ToString());
            //correct password
        }
        else if (loginResponse.success == false)
        {
            //Incorrect password
            errorMessageText.text = "Incorrect password";
        }
    }

    public string GetRequest(string endpoint)
    {
        var http = (HttpWebRequest)WebRequest.Create(new Uri(string.Format("", endpoint))); //link to login. Insert api here
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
        var http = (HttpWebRequest)WebRequest.Create(new Uri(string.Format("", endpoint))); //link to login. Insert api here
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

        string content = PostRequest("/login", data);

        loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);


        if (loginResponse.success)
        {
            Debug.Log(loginResponse.result[0].username);
            SceneManager.LoadScene("Dashboard");
        }


        string usernameContent = GetRequest(String.Format("/register/verify/username?value={0}", _userNameText));
        bool usernameExist = JsonConvert.DeserializeObject<bool>(usernameContent);

        Debug.Log(usernameExist);

    }
}
