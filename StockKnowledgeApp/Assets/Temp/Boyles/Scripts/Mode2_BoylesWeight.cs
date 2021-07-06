using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode2_BoylesWeight : MonoBehaviour
{

    public float weight = 1f;
    public Mode2_BoylesPressure pressureFill;
    private bool isInTrigger;

    void OnCollisionEnter(Collision collision) {
        
        // add weight if collided with the fill or weights
        if(collision.gameObject.GetComponent<Mode2_BoylesPressure>() || collision.gameObject.GetComponent<Mode2_BoylesWeight>()) {
            if (isInTrigger) pressureFill.IncreaseWeight(this);
        }
    }

    void OnCollisionExit(Collision collision) {
        
        
    }

    void OnTriggerEnter(Collider other) {
        isInTrigger = true;
    }

    void OnTriggerExit(Collider other) {
        pressureFill.DecreaseWeight(this);
        isInTrigger = false;
        // add weight if collided with the fill or weights
    }
}
