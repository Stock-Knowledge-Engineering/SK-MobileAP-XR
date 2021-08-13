using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public CurrentUser currentUser;
    public ScoresResponse scoresResponse;

    public GameObject rankOneObject;
    public GameObject rankTwoObject;
    public GameObject rankThreeObject;

    public GameObject scoresHolderObject;
    public GameObject scoreItemObject;

    private void Awake()
    {
        currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();

        string content = currentUser.GetRequest("/scores");
        scoresResponse = JsonConvert.DeserializeObject<ScoresResponse>(content);
    }

    void Start()
    {
        StartCoroutine(Initiate());
    }

    IEnumerator Initiate()
    {
        yield return null;

        GameObject rankOneNameObject = rankOneObject.transform.GetChild(2).gameObject;
        GameObject rankOnePointObject = rankOneObject.transform.GetChild(3).gameObject;

        TextMeshProUGUI rankOneNameText = rankOneNameObject.GetComponent<TextMeshProUGUI>();
        rankOneNameText.text = scoresResponse.result[0].firstname;

        TextMeshProUGUI rankOnePointText = rankOnePointObject.GetComponent<TextMeshProUGUI>();
        rankOnePointText.text = scoresResponse.result[0].points.ToString();

        GameObject rankTwoNameObject = rankTwoObject.transform.GetChild(2).gameObject;
        GameObject rankTwoPointObject = rankTwoObject.transform.GetChild(3).gameObject;

        TextMeshProUGUI rankTwoNameText = rankTwoNameObject.GetComponent<TextMeshProUGUI>();
        rankTwoNameText.text = scoresResponse.result[1].firstname;

        TextMeshProUGUI rankTwoPointText = rankTwoPointObject.GetComponent<TextMeshProUGUI>();
        rankTwoPointText.text = scoresResponse.result[1].points.ToString();

        GameObject rankThreeNameObject = rankThreeObject.transform.GetChild(2).gameObject;
        GameObject rankThreePointObject = rankThreeObject.transform.GetChild(3).gameObject;

        TextMeshProUGUI rankThreeNameText = rankThreeNameObject.GetComponent<TextMeshProUGUI>();
        rankTwoNameText.text = scoresResponse.result[2].firstname;

        TextMeshProUGUI rankThreePointText = rankThreePointObject.GetComponent<TextMeshProUGUI>();
        rankThreePointText.text = scoresResponse.result[2].points.ToString();

        for (int i = 3; i < 10; i++)
        {
            Score score = scoresResponse.result[i];

            GameObject scoreItem = Instantiate(scoreItemObject) as GameObject;
            scoreItem.name = score.firstname;
            scoreItem.transform.SetParent(scoresHolderObject.transform);
            scoreItem.transform.localPosition = new Vector3(scoreItem.transform.position.x, scoreItem.transform.position.y, 0);
            scoreItem.transform.localScale = new Vector3(1, 1, 1);

            GameObject rankNumberObject = scoreItem.transform.GetChild(0).gameObject;
            GameObject nameObject = scoreItem.transform.GetChild(2).gameObject;
            GameObject pointObject = scoreItem.transform.GetChild(3).gameObject;

            TextMeshProUGUI rankNumberText = rankNumberObject.GetComponent<TextMeshProUGUI>();
            rankNumberText.text = (i + 1).ToString();

            TextMeshProUGUI nameText = nameObject.GetComponent<TextMeshProUGUI>();
            nameText.text = score.firstname;

            TextMeshProUGUI pointText = pointObject.GetComponent<TextMeshProUGUI>();
            pointText.text = score.points.ToString() + " PTS";


            //StartCoroutine(SetButtonSprite(buttonObject, topic.content));
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
