using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDart : MonoBehaviour
{
    [SerializeField] private DartBoard_GameManager _dartBoard_GameManager;
    //public GameObject explosion;
    private int collisionCount = 0;
    private float dartLifeTime = 2f; //the time it takes for the dart to disappear if it does not hit the board
    public GameObject boardCenter; //The board's Center GameObject
    public float distanceToCenter; //The value of the distance to the center of the board
    public GameObject dartPin; //The Pin of the dart
    public float distanceToOtherDart; //Distance to OtherDart
    Rigidbody rb;
    public bool isHitDartboard;
    public AudioSource _audioSource;

    public void Start()
    {
        boardCenter = GameObject.Find("Dartboard Center");
        rb = GetComponent<Rigidbody>();
        _dartBoard_GameManager = GameObject.FindObjectOfType<DartBoard_GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        DartDestroy();
        Debug.Log("collisionCount = " + collisionCount);
    }

    public bool IsNotColliding
    {
        get { return collisionCount == 0; } //if the dart did not collide with anything
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Board")
        {
            _audioSource.Play();
            isHitDartboard = true;
            CenterChecker();

            //Attach gameObject to another gameObject
            GameObject sharedParent = new GameObject("Dart");
            collisionCount++;
            sharedParent.transform.position = collision.transform.position;
            sharedParent.transform.rotation = collision.transform.rotation;

            
            collision.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            sharedParent.transform.parent = collision.gameObject.transform;
            transform.parent = sharedParent.transform;
        }
    }
    public void CenterChecker()
    {
        if (isHitDartboard == true)
        {
            distanceToCenter = Vector3.Distance(boardCenter.transform.position, dartPin.transform.position);
        }
        Debug.Log("Distance to board's center " + distanceToCenter);
        if (_dartBoard_GameManager.numberOFDartsInScene == 5)
        {
            _dartBoard_GameManager.isGameDone = true;
        }
    }

    public void DartDestroy() //Do something if the dart missed the gameoject
    {
        dartLifeTime -= Time.deltaTime;
        if (dartLifeTime <= 0 && collisionCount <= 0)
        {
            distanceToCenter = 1.5f;
            distanceToOtherDart = 3f;
            isHitDartboard = false;
            CenterChecker();
            //Destroy(this.gameObject);
        }
    }
}
