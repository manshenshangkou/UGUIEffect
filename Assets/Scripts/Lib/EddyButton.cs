using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EddyButton : Button
{
    public ButtonEnterEvent PointerEnter { get; set; } = new ButtonEnterEvent();
    public ButtonExitEvent PointerExit { get; set; } = new ButtonExitEvent();


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

public class ButtonEnterEvent: UnityEvent { }
public class ButtonExitEvent : UnityEvent { }
