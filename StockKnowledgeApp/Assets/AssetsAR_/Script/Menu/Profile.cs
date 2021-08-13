using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Profile : MonoBehaviour
{
    [Header("Header")]
    public TMP_Text studentName;
    public TMP_Text schoolName;
    public TMP_Text gradeLevel;
    public Slider experienceSlider;
    public TMP_Text levelText;

    [Header("Body")]
    public Slider subject;
    public CurrentUser _currentUser;

    LevelResponse levelResponse;
    ExperienceResponse experienceResponse;

    private void Awake()
    {
        _currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();

        var data = new JObject();
        var obj = new JObject();

        obj["userid"] = _currentUser.loginResponse.result[0].userid;
        data["data"] = obj;

        string content = _currentUser.PostRequest("/player/level", data);
        levelResponse = JsonConvert.DeserializeObject<LevelResponse>(content);

        content = _currentUser.PostRequest("/player/experience", data);
        experienceResponse = JsonConvert.DeserializeObject<ExperienceResponse>(content);
    }

    // Start is called before the first frame update
    void Start()
    {
        experienceSlider.maxValue = 25 * levelResponse.result.level;
        experienceSlider.value = experienceResponse.result.experience;
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
        levelText.text = _currentUser.loginResponse.result[0].level.ToString();

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
