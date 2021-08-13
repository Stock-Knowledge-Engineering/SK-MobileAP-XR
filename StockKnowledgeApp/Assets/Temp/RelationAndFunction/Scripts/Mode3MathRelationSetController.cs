using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mode3MathRelationSetController : MonoBehaviour
{
    public string setName;
    public int setNumber;

    [Header("Restrictions")]
    public Restrictions[] restrictions;

    [Header("Events after any click on shelf objects")]

    public ClickEvent[] clickEvents;
    [Header("Successful Pair Events")]

    public PairEvent[] pairEvents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class Restrictions{
    public int index = 0;
    public Mode3RelationObjectSelector matchingObject;
    public UnityEvent action;
}

[System.Serializable]
public class PairEvent{
    public int pairCount = 0;
    public UnityEvent action;
}

[System.Serializable]
public class ClickEvent{
    public int pairIndex = 0;
    public ObjectType objectType = ObjectType.button;
    public UnityEvent action;
}