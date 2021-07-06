/***********************************************************
 * 
 * Player Position
 * fp0: x = -3; y = 1.75; z = 1.3;
 * fp1: x = 0.5; y = 1.75; z = -0.2;
 * fp2: x = -4.74; y = 1.75; z = 0;
 * fp3: x = 2; y = 1.75; z = 0.75;
 * fp4: x = 3; y = 1.75; z = 0;
 * 
 * cr: x = -6; y = 1.75; z = 0;
 * rm2: x = -0.5; y = 1.75; z = -3.5;
 * 
 * *********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportProbability2 : MonoBehaviour
{
    public Probability2GameManager room;

    public GameObject player;
    public int whichPosition;

    public GameObject crDoorLock;
    public GameObject roomDoorLock;
    public GameObject storageDoorLock;
    public GameObject mainDoorLock;

    public GameObject ftb;
    public GameObject ffb;


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

    void DeactiveOnChangePos()
    {
        crDoorLock.gameObject.SetActive(false);
        roomDoorLock.gameObject.SetActive(false);
        storageDoorLock.gameObject.SetActive(false);
        mainDoorLock.gameObject.SetActive(false);
    }

    IEnumerator Blink()
    {
        ftb.SetActive(true);

        yield return new WaitForSeconds(1);
        ftb.SetActive(false);
        switch (whichPosition)
        {
            case 1: //room door
                player.transform.position = new Vector3(0.5f, 1.75f, -0.2f);
                room.location = 1;
                DeactiveOnChangePos();
                break;
            case 2: //cr door
                player.transform.position = new Vector3(-4.75f, 1.75f, 0f);
                room.location = 2;
                DeactiveOnChangePos();
                if (!room.isCROpen)
                {
                    room.audio.clip = room.picsOnWall;
                    room.audio.Play();
                }
                break;
            case 3: //storage
                player.transform.position = new Vector3(2f, 1.75f, 0.75f);
                room.location = 3;
                DeactiveOnChangePos();
                break;
            case 4: //exit
                player.transform.position = new Vector3(3f, 1.75f, 0f);
                room.location = 4;
                DeactiveOnChangePos();
                break;
            case 5: //cr
                player.transform.position = new Vector3(-6f, 1.75f, 0f);
                room.location = 5;
                DeactiveOnChangePos();
                break;
            case 6: //room2
                player.transform.position = new Vector3(-0.5f, 1.75f, -3.5f);
                room.location = 6;
                DeactiveOnChangePos();
                break;
            default: //start pos
                player.transform.position = new Vector3(-3, 1.75f, 1.3f);
                room.location = 0;
                DeactiveOnChangePos();
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
