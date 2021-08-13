using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecomendedTopicBasedOnFavoriteSubject : MonoBehaviour
{
    public string testFavSub;

    [Header("UI Canvas")]
    public TextMeshProUGUI txtName;
    //public Text txtDescription;
    public Image imgPart;
    public string topicToLoad;

    [Header("ScriptableObjects")]
    public TopicSuggestion[] listOfTopicsEarthScience = new TopicSuggestion[6];
    public TopicSuggestion[] listOfTopicsChemistry = new TopicSuggestion[6];
    public TopicSuggestion[] listOfTopicsBiology = new TopicSuggestion[1];
    public TopicSuggestion[] listOfTopicsPhysics = new TopicSuggestion[8];
    public TopicSuggestion[] listOfTopicsMath = new TopicSuggestion[2];

    // Start is called before the first frame update
    void Start()
    {
        if(testFavSub == "EarthScience")
        {
            int rnd = Random.Range(1, listOfTopicsEarthScience.Length);
            txtName.text = listOfTopicsEarthScience[rnd].name;
            imgPart.sprite = listOfTopicsEarthScience[rnd].partImage;
            topicToLoad = listOfTopicsEarthScience[rnd].sceneToLoad;
        }
        else if(testFavSub == "Chemistry")
        {
            int rnd = Random.Range(1, listOfTopicsChemistry.Length);
            txtName.text = listOfTopicsChemistry[rnd].name;
            imgPart.sprite = listOfTopicsChemistry[rnd].partImage;
            topicToLoad = listOfTopicsChemistry[rnd].sceneToLoad;
        }
        else if (testFavSub == "Biology")
        {
            int rnd = Random.Range(1, listOfTopicsBiology.Length);
            txtName.text = listOfTopicsBiology[rnd].name;
            imgPart.sprite = listOfTopicsBiology[rnd].partImage;
            topicToLoad = listOfTopicsBiology[rnd].sceneToLoad;
        }
        else if (testFavSub == "Physics")
        {
            int rnd = Random.Range(1, listOfTopicsPhysics.Length);
            txtName.text = listOfTopicsPhysics[rnd].name;
            imgPart.sprite = listOfTopicsPhysics[rnd].partImage;
            topicToLoad = listOfTopicsPhysics[rnd].sceneToLoad;
        }
        else if (testFavSub == "Math")
        {
            int rnd = Random.Range(1, listOfTopicsMath.Length);
            txtName.text = listOfTopicsMath[rnd].name;
            imgPart.sprite = listOfTopicsMath[rnd].partImage;
            topicToLoad = listOfTopicsMath[rnd].sceneToLoad;
        }
        else
        {
            int rnd = Random.Range(1, 6);
            switch (rnd)
            {
                case 1:
                    int rndES = Random.Range(1, listOfTopicsEarthScience.Length);
                    txtName.text = listOfTopicsEarthScience[rndES].name;
                    imgPart.sprite = listOfTopicsEarthScience[rndES].partImage;
                    topicToLoad = listOfTopicsEarthScience[rndES].sceneToLoad;
                    break;
                case 2:
                    int rndChem = Random.Range(1, listOfTopicsChemistry.Length);
                    txtName.text = listOfTopicsChemistry[rndChem].name;
                    imgPart.sprite = listOfTopicsChemistry[rndChem].partImage;
                    topicToLoad = listOfTopicsChemistry[rndChem].sceneToLoad;
                    break;
                case 3:
                    int rndBio = Random.Range(1, listOfTopicsBiology.Length);
                    txtName.text = listOfTopicsBiology[rndBio].name;
                    imgPart.sprite = listOfTopicsBiology[rndBio].partImage;
                    topicToLoad = listOfTopicsBiology[rndBio].sceneToLoad;
                    break;
                case 4:
                    int rndPhys = Random.Range(1, listOfTopicsPhysics.Length);
                    txtName.text = listOfTopicsPhysics[rndPhys].name;
                    imgPart.sprite = listOfTopicsPhysics[rndPhys].partImage;
                    topicToLoad = listOfTopicsPhysics[rndPhys].sceneToLoad;
                    break;
                case 5:
                    int rndMath = Random.Range(1, listOfTopicsMath.Length);
                    txtName.text = listOfTopicsMath[rndMath].name;
                    imgPart.sprite = listOfTopicsMath[rndMath].partImage;
                    topicToLoad = listOfTopicsMath[rndMath].sceneToLoad;
                    break;
            }
            

        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(topicToLoad);
    }
}
