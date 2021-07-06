using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability2GameManager : MonoBehaviour
{
    public GameObject imageBlocker;

    public AudioSource audio;

    public AudioClip start;
    public AudioClip picsOnWall;
    public AudioClip faceCards;
    public AudioClip noClue;
    public AudioClip coins;
    public AudioClip diceRoll;
    public AudioClip dieRolledOnce;
    public AudioClip boxedNumbers;
    public AudioClip numberClue;
    public AudioClip lastClue;

    public bool isCROpen;
    public bool isStorageOpen;
    public bool isRoomOpen;
    public int numberCluesCollected = 0;

    public int location;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRoom());
    }

    IEnumerator StartRoom()
    {
        yield return new WaitForSeconds(4);
        audio.clip = start;
        audio.Play();

        yield return new WaitForSeconds(4);
        imageBlocker.gameObject.SetActive(false);
    }
}
