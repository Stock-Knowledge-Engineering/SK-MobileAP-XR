using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mode3RelationObjectSelector : GazeObjectV2, IPointerClickHandler
{

    [Header("OBJECT VARS")]
    public GameObject descriptionText;
    public ObjectColor objectColor = ObjectColor.green;
    public ObjectType objectType = ObjectType.shelfObject;
    internal Color color;
    Vector3 initScale; // for select animation purposes
    bool isSelected;
    internal bool hasMatch;

    Mode3RelationObjectSelector lastObjectSelected;
    Mode3MathRelationGameManager gameManager;
    TMP_Text descTMP;
    void Start() {
        descTMP = descriptionText.GetComponentInChildren<TMP_Text>();
        initScale = transform.localScale;
        gameManager = Mode3MathRelationGameManager.Instance;
        switch(objectColor) {
            case ObjectColor.red: color = Color.red;
            break;
            case ObjectColor.green: color = Color.green;
            break;
            case ObjectColor.yellow: color = Color.yellow;
            break;
            default: color = Color.white;
            break;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!gameManager.isGameStarted) return;
        if (gameManager.lastObjectSelected == this) return;
        if (gameManager.requiredObjectType != this.objectType) return;
        if (gameManager.setNumber == 1 && this.hasMatch) return;
        if (gameManager.IsRestricted(this, true)) return;
        gameManager.AddPoint(this);
    }

    public override void GazeAtObject()
    {
        descTMP.text = gameObject.name;
        descriptionText.gameObject.SetActive(true);

        // enable gaze only if the object is not the same as the last selection
        // and the correct object is selected
        if (!gameManager.isGameStarted) return;
        if (gameManager.lastObjectSelected == this) return;
        if (gameManager.requiredObjectType != this.objectType) return;
        if (gameManager.setNumber == 1 && this.hasMatch) return;
        if (gameManager.IsRestricted(this, false)) return;
        base.GazeAtObject();        
    }

    public override void ResetProgress()
    {
        base.ResetProgress();
        descriptionText.gameObject.SetActive(false);
    }

    public void SetSelected(bool isSelected) {
        this.isSelected = isSelected;

        if (isSelected) {
            StartCoroutine(SelectedAnimation());
        } else {
            transform.localScale = initScale;
            isSelected = false;
        }
    }

    private IEnumerator SelectedAnimation()
    {
        Vector3 targetScale = transform.localScale;
        targetScale.z = 4f;
        float time = 0;
        while (isSelected) {
            if (time < 1f) {
                transform.localScale = Vector3.Lerp(initScale, targetScale, time);
                time += Time.deltaTime * 8f;
            } else break;
            yield return null;
        }
    }
}

public enum ObjectColor {
        red, green, yellow, others
    }
public enum ObjectType {
    shelfObject, button
}