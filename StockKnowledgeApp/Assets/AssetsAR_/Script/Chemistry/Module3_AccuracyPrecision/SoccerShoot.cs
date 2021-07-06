using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerShoot : MonoBehaviour
{
    [SerializeField] private DartBoard_GameManager _dartBoard_GameManager;
    public Transform arCamera;
    public Transform SpawnPointRotation;
    public GameObject projectile;
    public bool isAR;
    public bool canShoot = true;
    private bool isHoldingButton;
    private float holdDownStartTime;
    public float shootForce;
    public AudioSource _audioSource;

    private void Start()
    {
        _dartBoard_GameManager = GameObject.FindObjectOfType<DartBoard_GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isAR == true)
        {
            if (isHoldingButton == true)
            {
                float holdDownTime = Time.time - holdDownStartTime;
                _dartBoard_GameManager.powerValue.value = CalculateHoldDownForce(holdDownTime);
            }
        }
        else if (isAR == false) //For PC (Testing) 
        {
            if (Input.GetMouseButtonDown(0) && canShoot == true) //Mouse Down, Start holding
            {
                holdDownStartTime = Time.time;
            }
            if (Input.GetMouseButton(0)) //Mouse still down, show the force of dart
            {
                float holdDownTime = Time.time - holdDownStartTime;
                _dartBoard_GameManager.powerValue.value = CalculateHoldDownForce(holdDownTime);
            }
            if (Input.GetMouseButtonUp(0) && canShoot == true) //Mouse up, Launch Dart!!!
            {
                float holdDownTime = Time.time - holdDownStartTime;
                GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation);
                //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * CalculateHoldDownForce(holdDownTime));
            }
        }
    }

    private float CalculateHoldDownForce(float holdTime) //Dart Power over time computation
    {
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        float force = holdTimeNormalized * _dartBoard_GameManager.maxDartForce;
        return force;
    }

    public void FingerOnEnter() //while the user's finger is still on the button
    {
        if (canShoot == true)
        {
            holdDownStartTime = Time.time;
            isHoldingButton = true;
        }
    }

    public void FingerOnExit() //if the user released the finger from the button
    {
        if (canShoot == true)
        {
            _audioSource.Play();
            float holdDownTime = Time.time - holdDownStartTime;
            GameObject dart = Instantiate(projectile, arCamera.position, SpawnPointRotation.rotation);
            dart.GetComponent<Rigidbody>().AddForce(arCamera.transform.forward * CalculateHoldDownForce(holdDownTime));
            isHoldingButton = false;
        }
    }
}
