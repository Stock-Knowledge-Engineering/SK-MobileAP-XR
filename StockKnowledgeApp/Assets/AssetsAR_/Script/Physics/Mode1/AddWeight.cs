using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWeight : MonoBehaviour
{
    private GameObject objectWeight;
    private Rigidbody rb;
    public int weight;
    public bool isHeavy;

    private void Awake()
    {
        objectWeight = this.gameObject;
        rb = objectWeight.GetComponent<Rigidbody>();
    }
    void Start()
    {
        if (isHeavy)
        {
            rb.AddForce(0, (rb.mass * weight) * -1, 0, ForceMode.Impulse);
        }

        if (!isHeavy)
        {
            rb.velocity = (Vector3.down*weight);
        }
    }


}
