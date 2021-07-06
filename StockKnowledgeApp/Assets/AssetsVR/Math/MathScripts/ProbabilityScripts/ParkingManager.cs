using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingManager : MonoBehaviour
{
    public GameObject parkingLot;
    public GameObject room;
    public GameObject parkingCanvas;
    public GameObject roomCanvas;

    public GameObject ftb;
    public GameObject ffb;

    public GameObject imageBlocker;

    public AudioSource audio;

    public AudioClip whatWasThat;
    public AudioClip anotherNoise;

    public AudioClip sfxtrunk;
    public AudioClip sfxmetal;
    public AudioClip sfxfootstep;
    public AudioClip sfxblunt;

    public GameObject uiCanvas;
    public GameObject uiCanvasReposition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartParkingLot());
    }

    IEnumerator StartParkingLot()
    {
        yield return new WaitForSeconds(7);
        imageBlocker.gameObject.SetActive(false);
    }

    public IEnumerator EndParkingLot()
    {
        yield return new WaitForSeconds(2);
        audio.clip = sfxblunt;
        audio.Play();
        ftb.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
        parkingLot.gameObject.SetActive(false);
        room.gameObject.SetActive(true);
        uiCanvas.transform.position = uiCanvasReposition.transform.position;
        uiCanvas.transform.Rotate(0, -90.0f, 0, Space.Self);

        yield return new WaitForSeconds(1);
        ftb.gameObject.SetActive(false);
        ffb.gameObject.SetActive(true);
        uiCanvasReposition.gameObject.SetActive(false);


        yield return new WaitForSeconds(0.5f);
        ftb.gameObject.SetActive(true);
        ffb.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);
        ftb.gameObject.SetActive(false);
        ffb.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        parkingCanvas.SetActive(false);
        roomCanvas.SetActive(true);
    }
}
