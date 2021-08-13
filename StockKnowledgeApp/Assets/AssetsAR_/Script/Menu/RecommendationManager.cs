using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecommendationManager : MonoBehaviour
{
    public CurrentUser currentUser;
    public FavoriteSubjectCountResponse favoriteSubjectCountResponse;
    public PlayerFavoriteSubjectResponse playerFavoriteSubjectResponse;

    private void Awake()
    {
        currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();

        string content = currentUser.GetRequest("/analytics/count/student/favoritesubject");
        favoriteSubjectCountResponse = JsonConvert.DeserializeObject<FavoriteSubjectCountResponse>(content);

        var data = new JObject();
        var obj = new JObject();

        obj["userid"] = currentUser.loginResponse.result[0].userid;
        data["data"] = obj;

        content = currentUser.PostRequest("/player/favoritesubject", data);

        playerFavoriteSubjectResponse = JsonConvert.DeserializeObject<PlayerFavoriteSubjectResponse>(content);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Example on how to get the data
        if (favoriteSubjectCountResponse.success && favoriteSubjectCountResponse.result.Length > 0)
            foreach (CountData data in favoriteSubjectCountResponse.result)
                Debug.Log("Subject: " + data.name + "Count: " + data.count);

        if (playerFavoriteSubjectResponse.success)
            Debug.Log(playerFavoriteSubjectResponse.result); //Player favorite subject
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
