using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System;
using System.Text;
using System.IO;
using System.Linq;

public class CurrentUser : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public LoginResponse loginResponse;

    public ExperienceResponse experienceResponse;
    public LevelResponse levelResponse;
    public LevelUpResponse levelUpResponse;

    private static CurrentUser playerInstance;

    public int lvl;
    public int exp;

    //======= "Subject Topics" =======
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


    public string GetRequest(string endpoint)
    {
        var http = (HttpWebRequest)WebRequest.Create(new Uri(string.Format("https://api.stockknowledge.org{0}", endpoint))); //link to login. Insert api here
        //https://api.qa.stockknowledge.org{0}
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
        var http = (HttpWebRequest)WebRequest.Create(new Uri(string.Format("https://api.stockknowledge.org{0}", endpoint))); //link to login. Insert api here
        //https://api.qa.stockknowledge.org{0}
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

    void Awake()
    {
        DontDestroyOnLoad(this);
        //Reset();//To reset values
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    public void Start()
    {
        GetCurrentUserDetails();
    }

    public void Update()
    {
        if (loginResponse.success)
        {
            //LevelCheck();
        }
        SetProgress();
    }

    public void GetCurrentUserDetails()
    {
        var data = new JObject();

        var credential = new JObject();

        credential["username"] = PlayerPrefs.GetString("CurrentUsername");
        credential["password"] = PlayerPrefs.GetString("CurrentPassword");

        data["data"] = credential;

        string content = PostRequest("/login", data);

        loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);
        Debug.Log("======= " + PlayerPrefs.GetString("CurrentUsername"));
        Debug.Log("======= " + PlayerPrefs.GetString("CurrentPassword"));

    }

    public void ScoreUpdate()
    {

    }

    public void LevelCheck()
    {
        var data = new JObject();

        var obj = new JObject();
        obj["userid"] = loginResponse.result[0].userid;

        data["data"] = obj;

        //get player current level
        string content = PostRequest("/player/level", data);
        levelResponse = JsonConvert.DeserializeObject<LevelResponse>(content);

        //get player current experience
        content = PostRequest("/player/experience", data);
        Debug.Log(content);
        experienceResponse = JsonConvert.DeserializeObject<ExperienceResponse>(content);

        //Assign experience
        exp = experienceResponse.result.experience;

        //Assign level
        lvl = levelResponse.result.level;

        //Add level or experience
        obj["level"] = 4; //assign new value ex. 4
        obj["experience"] = 100; //assign new value ex. 100
        obj["userid"] = loginResponse.result[0].userid; //assign user id

        data["data"] = obj;

        if (!levelUpResponse.success)
        {
            content = PostRequest("/player/level-up", data);
            levelUpResponse = JsonConvert.DeserializeObject<LevelUpResponse>(content);
        }

        //Check if success
        if (levelUpResponse.success)
            Debug.Log("Level up success!");
        else
            Debug.Log("Level up failed!");

        //if (exp <= 1000)
        //{
        //    lvl++;
        //    exp = 0;
        //}
    }

    public void SetProgress() 
    {
        /*PlayerPrefs.SetInt("Chemistry", 0);
        PlayerPrefs.SetInt("EarthScience", 0);
        PlayerPrefs.SetInt("Biology", 0);
        PlayerPrefs.SetInt("Math", 0);
        PlayerPrefs.SetInt("Physics", 0);
        PlayerPrefs.Save(); */

        chemProgress = PlayerPrefs.GetInt("Chemistry");
        esProgress = PlayerPrefs.GetInt("EarthScience");
        mathProgress = PlayerPrefs.GetInt("Biology");
        physicsProgress = PlayerPrefs.GetInt("Physics");
    }

    public void Reset() //temporary (make this a debug tool later)
    {

        PlayerPrefs.SetInt("Chemistry", 0);
        PlayerPrefs.SetInt("EarthScience", 0);
        PlayerPrefs.SetInt("Biology", 0);
        PlayerPrefs.SetInt("Math", 0);
        PlayerPrefs.SetInt("Physics", 0);
        PlayerPrefs.Save(); 
    }
}