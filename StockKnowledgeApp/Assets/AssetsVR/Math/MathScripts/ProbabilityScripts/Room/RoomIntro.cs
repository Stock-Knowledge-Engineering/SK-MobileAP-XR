using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomIntro : MonoBehaviour
{

    public GameObject imageBlocker;

    public AudioSource audio;

    public AudioClip instructions;
    public AudioClip aVault;
    public AudioClip toOpenVault;
    public AudioClip vaultHint;
    public AudioClip laptop;
    public AudioClip laptopHint;
    public AudioClip needAKey;
    public AudioClip aClue;
    public AudioClip aClueAnswer;

    public bool isLaptopUnlocked;
    public bool isVaultDoorOpen;
    public bool isKeyCollected;
    public bool isClueInteractive;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRoom());
    }

    IEnumerator StartRoom()
    {
        yield return new WaitForSeconds(5);
        audio.clip = instructions;
        audio.Play();

        yield return new WaitForSeconds(10);
        imageBlocker.gameObject.SetActive(false);
    }

    public IEnumerator ShowVault()
    {
        yield return new WaitForSeconds(1);
        audio.clip = aVault;
        audio.Play();
    }
}
