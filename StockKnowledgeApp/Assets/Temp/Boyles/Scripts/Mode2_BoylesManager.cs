using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Mode2_BoylesManager : MonoBehaviour
{


    public ChangeOrientationTarget changeOrientationTarget;

    [Header("Weight Spawn Point")]
    public GameObject weightObject;
    public Transform spawnPoint;

    [Header("Pressure Fill")]
    public Mode2_BoylesPressure pressureFill;

    [Header("Pressure Gauge")]
    public Text pressureValueText;
    public RectTransform pressureGauge;
    public float maxGaugeValue = 10;
    public float minGaugePointerRotation = 0;
    public float maxGaugePointerRotation = 0;


    [Header("Events")]
    public UnityEvent onSpawnWeight;
    public EventOnWeightChange[] eventsOnVolumeChange;
    public UnityEvent onLevelCompleted;


    private float lastGaugeRotation;
    private float currentGaugeRotation;
    private float lastPressureValue = 0;
    private float currentPressureValue = 0;
    private bool isCompleted;

    [Header("Score")]
    public int currentScore;
    public TextMeshProUGUI totalWeights;
    public TextMeshProUGUI score;

    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        currentPressureValue = 1;
        lastPressureValue = currentPressureValue;
        currentGaugeRotation = minGaugePointerRotation;
        lastGaugeRotation = currentGaugeRotation;
    }

    public void SetPressure(float pressureValue, int weightCount){
        StartCoroutine(AnimatePressure(pressureValue, weightCount));
    }

    public void SpawnWeight(float swipeForce){
        if (isCompleted) return;
        GameObject weight = Instantiate(weightObject, spawnPoint.position, weightObject.transform.rotation, weightObject.transform.parent);
        weight.SetActive(true);
        Vector3 direction = Vector3.up;
        weight.GetComponentInChildren<Rigidbody>().AddForce((direction + Camera.main.transform.forward) * swipeForce);
        // weight.transform.localRotation = changeOrientationTarget.orientationState == ChangeOrientationTarget.OrientationState.Flat ? Quaternion.identity : Quaternion.Euler(Vector3.up * 90f);
        onSpawnWeight.Invoke();
    }

    public void Reset(){
        pressureFill.Reset();
        Initialize();
        UpdatePressureValues();
        isCompleted = false;
    }

    private IEnumerator AnimatePressure(float pressureValue, int weightCount)
    {
        
        foreach(EventOnWeightChange e in eventsOnVolumeChange) {
            if (e.weight == weightCount)
                e.eventOnVolumeChange.Invoke();
        }
        UpdateScore(weightCount);
        
        float timer = 0f;
        float calculatedGaugeRotation = minGaugePointerRotation - (pressureValue/maxGaugeValue * (minGaugePointerRotation - maxGaugePointerRotation));
        while (timer <= 1f) {
            timer += Time.deltaTime * 1f;
            // Animate Pressure Value Text
            currentPressureValue = Mathf.Lerp(lastPressureValue, pressureValue, timer);
            currentGaugeRotation = Mathf.Lerp(lastGaugeRotation, calculatedGaugeRotation, timer);
            UpdatePressureValues();
            yield return null;
        }
        
        currentPressureValue = pressureValue;
        lastPressureValue = currentPressureValue;
        lastGaugeRotation = currentGaugeRotation;
        if (weightCount == 9) {
            isCompleted = true;
            onLevelCompleted.Invoke();
        }
    }

    private void UpdatePressureValues(){
        pressureValueText.text = currentPressureValue.ToString("0.00");
        pressureGauge.localRotation = Quaternion.Euler(new Vector3(0, 0, currentGaugeRotation));
    }

    public void UpdateScore(int weightCount)
    {
        currentScore += 50;
        totalWeights.text = weightCount.ToString();
        score.text = currentScore.ToString();
        PointsManager.Instance.AddPoints();
    }
}

[Serializable]
public class EventOnWeightChange {
    public int weight;
    public UnityEvent eventOnVolumeChange;

}