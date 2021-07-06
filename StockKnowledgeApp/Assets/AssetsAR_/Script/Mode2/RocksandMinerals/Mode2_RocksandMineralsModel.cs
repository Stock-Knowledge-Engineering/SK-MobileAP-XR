using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_RocksandMineralsModel : MonoBehaviour
{
    [Header("Reference")]
    public Mode2_RocksandMineralsGameManager _RocksandMineralsGameManager;
    public bool hasAnswered = false;
    public int modelNum;
    public GameObject choices;
    public MeshRenderer meshRenderer;

    [Header("Model Properties")]
    public bool isIgneous;
    public bool isMetamorphic;
    public bool isSedimentary;

    public void Start()
    {
        _RocksandMineralsGameManager = GameObject.FindObjectOfType<Mode2_RocksandMineralsGameManager>();
    }

    public void Update()
    {
        if (meshRenderer.enabled == true)
        {
            _RocksandMineralsGameManager.current3DModelInt = modelNum;
            if (hasAnswered == false)
            {
                choices.SetActive(true);
            }
        }else if (meshRenderer.enabled == false)
        {
            //choices.SetActive(false);
        }
    }

    
}
