using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module3RelationCarScene : MonoBehaviour
{
    public GameObject player;
    public GameObject playerParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnEnable(){
        player.transform.parent = playerParent.transform;
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.identity;
        player.transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
