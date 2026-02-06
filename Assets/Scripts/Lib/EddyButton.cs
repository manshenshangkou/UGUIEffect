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
    public UGUIDownEvent PointerDown { get; set; } = new UGUIDownEvent();
    public UGUIUpEvent PointerUp { get; set; } = new UGUIUpEvent();


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
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        PointerDown?.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        PointerUp?.Invoke();
    }
}

public class UGUIEnterEvent: UnityEvent { }
public class UGUIExitEvent : UnityEvent { }
public class UGUIDownEvent : UnityEvent { }
public class UGUIUpEvent : UnityEvent { }
