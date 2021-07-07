using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_SeriesGaze : GazeObjectV2
{
    private Mode2_SeriesPlayer player;
    private bool hasGazedAlready;
    // Start is called before the first frame update
    void Start()
    {
        player = Mode2_SeriesGameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GazeAtObject()
    {
        if (player.prismHolding) return;
        hasGazedAlready = true;
        base.GazeAtObject();
    }
    public override void ResetProgress()
    {
        if (!hasGazedAlready) return;
        base.ResetProgress();
    }
}
