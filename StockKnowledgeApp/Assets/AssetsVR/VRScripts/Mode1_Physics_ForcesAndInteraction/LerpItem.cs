using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpItem : MonoBehaviour
{

    public Mode1_Physics_ForceAndInteractionGameManager gameManager;
    public Transform transformPos;
    public Vector3 initialPos;
    public Transform targetPos;
    public LayerMask diorama;
    private bool isClicked;
    private bool isBack;
    void Awake()
    {
        transformPos = GetComponent<Transform>();

        initialPos = transformPos.position;

    }
    private void Start()
    {
        gameManager = FindObjectOfType<Mode1_Physics_ForceAndInteractionGameManager>();
    }
    // Update is called once per frame
    private void Update()
    {

        if (!isClicked)
        {
            this.transform.position = Vector3.Lerp(transform.position, initialPos, Time.deltaTime);
            gameManager.selectedItem = false;
        }

        else
        {
            this.transform.position = Vector3.Lerp(transform.position, targetPos.position, Time.deltaTime);
            gameManager.selectedItem = true;
        }
   

      

    }
    public void TestClick()
    {
        isClicked= true;

    }

    public void Back()
    { 

        isClicked= false;
    }


}
