using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class ToggleVR2D : MonoBehaviour
{
    public ToggleTouchGaze ttg;

    public Button btnToggle;
    public Sprite panoramaIcon;
    public Sprite vrIcon;

    public int toggleView; // 0 = VR mode; 1 = Panorama mode

    private void Awake()
    {
        //PlayerPrefs.SetInt("p_toggleView", 0);
        btnToggle = GetComponent<Button>();
        //Debug.Log(PlayerPrefs.GetInt("p_toggleView"));
        //switch (PlayerPrefs.GetInt("p_toggleView"))
        switch (toggleView)
        {
            case 1:
                btnToggle.image.sprite = panoramaIcon;
                break;
            default:
                btnToggle.image.sprite = vrIcon;
                break;
        }
    }

    public void Toggle()
    {
        //switch (PlayerPrefs.GetInt("p_toggleView"))
        switch (toggleView)
        {
            case 1:
                StartCoroutine(SwitchTo2D());
                //PlayerPrefs.SetInt("p_toggleView", 0);
                toggleView = 0;
                break;
            default:
                StartCoroutine(SwitchToVR());
                //PlayerPrefs.SetInt("p_toggleView", 1);
                toggleView = 1;
                break;
        }
        //PlayerPrefs.Save();

    }

    // Call via `StartCoroutine(SwitchToVR())` from your code. Or, use
    // `yield SwitchToVR()` if calling from inside another coroutine.
    IEnumerator SwitchToVR()
    {
        btnToggle.image.sprite = panoramaIcon;
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard"; // Or "daydream".

        // Some VR Devices do not support reloading when already active, see
        // https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
        if (String.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(desiredDevice);

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;
        }

        // Now it's ok to enable VR mode.
        XRSettings.enabled = true;
        ResetCameras();
    }

    // Call via `StartCoroutine(SwitchTo2D())` from your code. Or, use
    // `yield SwitchTo2D()` if calling from inside another coroutine.
    IEnumerator SwitchTo2D()
    {
        btnToggle.image.sprite = vrIcon;
        // Empty string loads the "None" device.
        XRSettings.LoadDeviceByName("");

        // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
        yield return null;

        // Not needed, since loading the None (`""`) device takes care of this.
        // XRSettings.enabled = false;

        // Restore 2D camera settings.
        ResetCameras();
    }

    // Resets camera transform and settings on all enabled eye cameras.
    void ResetCameras()
    {
        // Camera looping logic copied from GvrEditorEmulator.cs
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None)
            {

                // Reset local position.
                // Only required if you change the camera's local position while in 2D mode.
                cam.transform.localPosition = Vector3.zero;

                // Reset local rotation.
                // Only required if you change the camera's local rotation while in 2D mode.
                cam.transform.localRotation = Quaternion.identity;

                // No longer needed, see issue github.com/googlevr/gvr-unity-sdk/issues/628.
                // cam.ResetAspect();

                // No need to reset `fieldOfView`, since it's reset automatically.
            }
        }
    }

    //for gaze controller
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
                    Toggle();
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
