using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Scale : EventTrigger
{

    public override void OnPointerEnter(PointerEventData data)
    {
        transform.localScale = transform.localScale*1.2f;
    }

    public override void OnPointerExit(PointerEventData data)
    {
        transform.localScale = transform.localScale / 1.2f;
    }

    // Update is called once per frame


}
