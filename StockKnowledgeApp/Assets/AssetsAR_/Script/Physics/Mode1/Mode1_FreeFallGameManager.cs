using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode1_FreeFallGameManager : MonoBehaviour
{
    [Header("OBJECT PROPERTIES")]
    public GameObject bowlingBall;
    public GameObject feather;
    public Transform spawnPoint;
    public Transform spawnPoint2;

    public GameObject both;

    public void SpawnBowlingBall()
    {
        GameObject ballObject = Instantiate(bowlingBall, spawnPoint.position, Quaternion.identity, bowlingBall.transform.parent) as GameObject;
        ballObject.SetActive(true);
        Destroy(ballObject, 5);


    }

    public void SpawnFeather()
    {

        GameObject featherObject = Instantiate(feather, spawnPoint2.position, Quaternion.identity, feather.transform.parent) as GameObject; 
        featherObject.SetActive(true);
        featherObject.transform.Rotate(0, 180, 0);
        Destroy(featherObject, 5);
    }

    public void SpawnBoth()
    {
        GameObject bothObject = Instantiate(both, spawnPoint2.position, Quaternion.identity, both.transform.parent) as GameObject;
        bothObject.SetActive(true);
        //bothObject.transform.Rotate(0, 180, 0);
        Destroy(bothObject, 5);
    }





}


