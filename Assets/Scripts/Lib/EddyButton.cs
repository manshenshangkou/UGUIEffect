using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EddyButton : Button
{
    public UGUIEnterEvent PointerEnter { get; set; } = new UGUIEnterEvent();
    public UGUIExitEvent PointerExit { get; set; } = new UGUIExitEvent();


    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        PointerEnter?.Invoke();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        PointerExit?.Invoke();
    }
}

public class UGUIEnterEvent: UnityEvent { }
public class UGUIExitEvent : UnityEvent { }
