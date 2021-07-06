using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_SeriesPlayer : MonoBehaviour
{
    public LayerMask layerMask;
    internal Mode2_SeriesPrism prismHolding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Fire ray from camera
        float rayLength = 10f;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If ray hits object within length
        if (Physics.Raycast(ray, out hit, rayLength, layerMask))
        {
            if (prismHolding) {
                prismHolding.transform.position = hit.point + (Vector3.up * 0.05f);
            }
        }


    }

    public void HoldPrism(Mode2_SeriesPrism prism){
        prismHolding = prism;
        FXSoundSystem.Instance.PlayAudioInList(0);
    }

    public void DropPrism() {
        prismHolding = null;
    }
    public void DropPrism(Mode2_SeriesPrismTarget target) {
        prismHolding.gameObject.transform.position = target.transform.position;
        prismHolding.gameObject.transform.rotation = target.transform.rotation;
        prismHolding.GetComponent<Rigidbody>().isKinematic = true;
        prismHolding.gameObject.layer = 0;
        prismHolding.isStacked = true;
        prismHolding = null;
        FXSoundSystem.Instance.PlayAudioInList(1);

        Mode2_SeriesGameManager.Instance.currentPrismsCount++;

        if (Mode2_SeriesGameManager.Instance.maxPrisms == Mode2_SeriesGameManager.Instance.currentPrismsCount) {
            Mode2_SeriesGameManager.Instance.Win();
        }
    }
}
