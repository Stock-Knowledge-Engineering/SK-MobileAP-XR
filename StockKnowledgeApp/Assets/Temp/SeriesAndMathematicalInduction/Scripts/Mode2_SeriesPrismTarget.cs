using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_SeriesPrismTarget : MonoBehaviour
{
    private Mode2_SeriesPlayer player;
    bool isContainingPrism;

    void Awake(){
        //disable at first, so that we can enable later if we identified we are on the bottom stack
        EnableTargetStack(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        player = Mode2_SeriesGameManager.Instance.player;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter(){
        if (isContainingPrism) return;
        if (player.prismHolding) {
            isContainingPrism = true;
            player.DropPrism(this);
            GetComponentInParent<Mode2_SeriesStackTarget>().IncrementStackSuccessCount();
        }
    }

    public void EnableTargetStack(bool isEnable){
        this.GetComponent<Collider>().enabled = isEnable;
    }
}
