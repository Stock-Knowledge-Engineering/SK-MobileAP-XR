using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopicSearch : MonoBehaviour
{
    public TMP_InputField searchText;
    public GameObject[] topicHandler;

    public void Update()
    {
        
    }

    public void Search()
    {
        for (int i = 0; i < topicHandler.Length; i++)
        {
            if (searchText.text == "")
            {
                topicHandler[i].gameObject.SetActive(true);
            }
            else
            {
                if (topicHandler[i].name.ToLower().Contains(searchText.text.ToLower()))
                {
                    topicHandler[i].gameObject.SetActive(true);
                }
                else
                {
                    topicHandler[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
