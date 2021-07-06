using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class EditProfile : MonoBehaviour
{
    public CurrentUser currentUser;

    [Header("Page1")]
    public TMP_InputField firstName;
    public TMP_InputField middleName;
    public TMP_InputField lastName;
    public Button NextButton;


    public void Awake()
    {
        currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();
    }

    public void Update()
    {
        if (firstName.text != "" && middleName.text != "" && lastName.text != "")
        {
            NextButton.interactable = true;
        }
        else
        {
            NextButton.interactable = false;
        }
    }

    public void Submit()
    {

        var obj = new JObject();
        obj["userid"] = currentUser.loginResponse.result[0].userid;
        obj["firstname"] = firstName.text;
        obj["middlename"] = middleName.text;
        obj["lastname"] = lastName.text;

        var data = new JObject();
        data["data"] = obj;

        string content = currentUser.PostRequest("/account/update/name", data);

        UpdateNameResponse result = JsonConvert.DeserializeObject<UpdateNameResponse>(content);

        Debug.Log(result.success);
    }
}
