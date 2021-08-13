using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Topic", menuName = "TopicSuggestionContainer")]
public class TopicSuggestion : ScriptableObject
{
    public new string name;
    public string description;
    public string sceneToLoad;
    public Sprite partImage;
}
