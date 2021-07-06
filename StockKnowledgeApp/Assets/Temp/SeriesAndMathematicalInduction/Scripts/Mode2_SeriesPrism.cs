using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_SeriesPrism : MonoBehaviour
{
    private Mode2_SeriesPlayer player;
    private Vector3 posBeforeGrabbed;

    internal bool isStacked;
    // Start is called before the first frame update
    void Start()
    {
        player = Mode2_SeriesGameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        if (player.prismHolding) return;

        player.HoldPrism(this);
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
