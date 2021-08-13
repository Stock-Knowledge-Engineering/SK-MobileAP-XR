using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Mode3MathRelationGameManager : MonoBehaviour
{
    
    private static Mode3MathRelationGameManager _instance;
    public static Mode3MathRelationGameManager Instance { get { return _instance; } }
    
    public LineRenderer lineRenderer;
    public TMP_Text setA;
    public TMP_Text setB;

    internal Mode3RelationObjectSelector lastObjectSelected;
    internal ObjectType requiredObjectType = ObjectType.button;
    internal int setNumber = 1; // 1 for Set A, 2 for Set B
    
    List<LineRenderer> lineRenderers;
    int currentTextIndex = 5; // index where the relation words should start appearing
    int index;
    string lastText = "";

    internal bool isGameStarted = false;

    public Mode3MathRelationSetController setController;


    [Header("Events")]
    public UnityEvent onCorrect;
    public UnityEvent onIncorrect;
    public UnityEvent onButtonSelect;
    public UnityEvent onObjectSelect;
    

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    
    void Start(){
        lineRenderers =  new List<LineRenderer>();
    }

    internal bool IsRestricted(Mode3RelationObjectSelector restrictedObject, bool invoke)
    {
        bool isRestricted = false;
        // invoke click events
        Array.ForEach(setController.restrictions, restriction => {
            if (index == restriction.index){
                isRestricted = true;
                if (restrictedObject == restriction.matchingObject) {
                    isRestricted = false;
                    if (invoke) restriction.action.Invoke();
                }
                return;
            }
        });

        return isRestricted;
    }

    internal void AddPoint(Mode3RelationObjectSelector objectSelected)
    {
        LineRenderer renderer = null;
        // if there is no line renderer
        // or if the player already reached second selectionon
        // then it must create a new line renderer
        if (lineRenderers.Count == 0 || lineRenderers[lineRenderers.Count - 1].positionCount == 2) {
            // Insantiate a new line
            renderer = Instantiate(lineRenderer, Vector3.zero, Quaternion.identity);
            renderer.startColor = objectSelected.color;
            renderer.positionCount++;
            renderer.SetPosition(renderer.positionCount - 1, objectSelected.transform.position);
            lineRenderers.Add(renderer);

            // require a shelf object after first selection
            requiredObjectType = ObjectType.shelfObject;
            objectSelected.SetSelected(true);
            RegisterObject(renderer.positionCount, objectSelected.name);
            FXSoundSystem.Instance.PlayAudioInList(0);
            onButtonSelect.Invoke();
            InvokeClickEvents(objectSelected);
            index++;
        } else {
            // second selection
            renderer = lineRenderers[lineRenderers.Count - 1];
            InvokeClickEvents(objectSelected);
            
            if (objectSelected.objectColor == lastObjectSelected.objectColor) { // if correct color
                renderer.positionCount++;
                renderer.SetPosition(renderer.positionCount - 1, objectSelected.transform.position);
                RegisterObject(renderer.positionCount, objectSelected.name);
                objectSelected.hasMatch = true;
                lastObjectSelected.hasMatch = true;
                Correct();
                index++;
            } else {
                Incorrect();
                index--;
            }
            FXSoundSystem.Instance.PlayAudioInList(1);
            // require a button after second selection 
            requiredObjectType = ObjectType.button;
            lastObjectSelected.SetSelected(false);
            onObjectSelect.Invoke();
        }
        lastObjectSelected = objectSelected;
    }

    private void InvokeClickEvents(Mode3RelationObjectSelector objectSelected)
    {
        // invoke click events
        Array.ForEach(setController.clickEvents, clickEvent => {
            if (lineRenderers.Count == clickEvent.pairIndex && clickEvent.objectType == objectSelected.objectType){
                clickEvent.action.Invoke();
            } 
        });
    }

    private void RegisterObject(int objectIndex, string name)
    {
        /** 
            So basically, if the object is the first index of the pair, then it must start with "("
            and ends with a ",".

            If it is second index, then it must start with a space, and end with a ")".

            The pairs after the first pair should also start with a ",".
        */
        int pairIndex = lineRenderers.Count;
        TMP_Text currentSetTxt = setNumber == 1 ? setA : setB;
        string prefix = pairIndex != 1 && objectIndex == 1 ? ", " : "";
        prefix += objectIndex == 1 ? "(" : " ";
        string suffix = objectIndex == 1 ? "," : ")";

        string textWithPunctuations = prefix + name + suffix;

        string finalText = currentSetTxt.text.Insert(currentTextIndex, textWithPunctuations);
        currentSetTxt.text = finalText;
        currentTextIndex += textWithPunctuations.Length; // increment insertion index position
        lastText = textWithPunctuations;
    }

    private void Correct()
    {
        onCorrect.Invoke();
        // invoke successful pair events
        Array.ForEach(setController.pairEvents, pairEvent =>{
            if (lineRenderers.Count == pairEvent.pairCount){
                pairEvent.action.Invoke();
            } 
        });
    }

    private void Incorrect()
    {
        onIncorrect.Invoke();
        // remove last line renderer
        lineRenderers.RemoveAt(lineRenderers.Count - 1);
        
        // remove last text
        TMP_Text currentSetTxt = setNumber == 1 ? setA : setB;
        string text = currentSetTxt.text;
        text = text.Substring(0, currentTextIndex - lastText.Length);
        currentSetTxt.text = text + "}";
        currentTextIndex -= lastText.Length;
    }

    public void EnableGameInteractions(bool enable){
        isGameStarted = enable;
    }

    public void SetController(Mode3MathRelationSetController controller) {
        Reset();
        this.setNumber = controller.setNumber;
        this.setController = controller;
    }

    public void Reset()
    {
        isGameStarted = false;
        index = 0;
        lineRenderers.ForEach(lineRenderer => {
            lineRenderer.gameObject.SetActive(false);
            currentTextIndex = 5;
        });
        lastObjectSelected = null;
        lineRenderers = new List<LineRenderer>();
    }
}

