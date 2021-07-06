/***********************************************************
 * 
 * Player Position
 * fp0: x = 0; y = 1.77; z = 0;
 * fp1: x = 1.65; y = 1.77; z = -0.25;
 * fp2: x = 1.92; y = 1.77; z = 2.3;
 * fp3: x = -0.5; y = 1.77; z = 1.5;
 * 
 * vaultPos: x = -0.65; y = 1; z = 0.75;
 * 
 * *********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public RoomIntro room;

    public GameObject player;
    public int whichPosition;

    public GameObject ftb;
    public GameObject ffb;

    public GameObject vaultTeleport;
    public GameObject vaultCanvas;

    public GameObject laptopCanvas;

    public GameObject imageClueCanvas;

    public GameObject interactDoor;

    public GameObject doorPuzzle;



    public void MEnter()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 0);
    }

    public void MExit()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1);
    }

    public void MoveToPosition()
    {
        StartCoroutine(Blink());        
    }

    IEnumerator Blink()
    {
        ftb.SetActive(true);

        yield return new WaitForSeconds(1);
        ftb.SetActive(false);
        switch (whichPosition)
        {
            case 1:
                player.transform.position = new Vector3(1.65f, 1.77f, -0.25f);
                vaultTeleport.SetActive(true);
                vaultCanvas.SetActive(false);
                if (!room.isLaptopUnlocked)
                {
                    room.audio.clip = room.laptop;
                    room.audio.Play();
                }
                interactDoor.SetActive(false);
                imageClueCanvas.SetActive(false);
                doorPuzzle.SetActive(false);
                room.isClueInteractive = false;
                break;
            case 2:
                player.transform.position = new Vector3(1.92f, 1.77f, 2.3f);
                vaultTeleport.SetActive(true);
                vaultCanvas.SetActive(false);
                laptopCanvas.SetActive(false);
                interactDoor.SetActive(true);
                imageClueCanvas.SetActive(false);
                doorPuzzle.SetActive(false);
                room.isClueInteractive = false;
                break;
            case 3:
                player.transform.position = new Vector3(-0.5f, 1.77f, 1.5f);
                vaultTeleport.SetActive(true);
                vaultCanvas.SetActive(false);
                laptopCanvas.SetActive(false);
                interactDoor.SetActive(false);
                imageClueCanvas.SetActive(false);
                doorPuzzle.SetActive(false);
                room.isClueInteractive=true;
                break;
            case 4:
                player.transform.position = new Vector3(-0.65f, 1f, 0.75f);
                vaultTeleport.SetActive(false);
                laptopCanvas.SetActive(false);
                if (!room.isVaultDoorOpen)
                {
                    vaultCanvas.SetActive(true);
                    room.audio.clip = room.toOpenVault;
                    room.audio.Play();
                }
                interactDoor.SetActive(false);
                imageClueCanvas.SetActive(false);
                doorPuzzle.SetActive(false);
                room.isClueInteractive = false;
                break;
            default:
                player.transform.position = new Vector3(0, 1.77f, 0);
                vaultTeleport.SetActive(true);
                vaultCanvas.SetActive(false);
                laptopCanvas.SetActive(false);
                interactDoor.SetActive(false);
                imageClueCanvas.SetActive(false);
                doorPuzzle.SetActive(false);
                room.isClueInteractive = false;
                break;
        }
        ffb.SetActive(true);

        yield return new WaitForSeconds(1);
        ffb.SetActive(false);
    }

    [Header("Gaze")]
    public ToggleTouchGaze ttg;

    public float gazeTimer;
    public Image radialImage;
    public bool isRadialFilled;
    public bool isObjectGazed;

    public void GazeAtObject()
    {
        if (ttg.isGaze)
        {
            isRadialFilled = false;
            isObjectGazed = true;
            Debug.Log("start gaze");
        }

    }

    void LateUpdate()
    {
        if (isObjectGazed)
        {
            if (!isRadialFilled)
            {
                Debug.Log("Loading gaze");
                gazeTimer += Time.deltaTime;
                radialImage.fillAmount = gazeTimer / 2;

                if (gazeTimer >= 2)
                {
                    isRadialFilled = true;
                    ResetProgress();
                    Debug.Log("end gaze");
                    MoveToPosition();
                }
            }
        }

    }

    public void ResetProgress()
    {
        isObjectGazed = false;
        gazeTimer = 0f;
        radialImage.fillAmount = 0f;
        Debug.Log("reset gaze");
    }
}
