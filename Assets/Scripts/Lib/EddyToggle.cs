using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EddyToggle : Toggle
{
    public UGUIEnterEvent PointerEnterPre { get; set; } = new UGUIEnterEvent();
    public UGUIEnterEvent PointerEntered { get; set; } = new UGUIEnterEvent();
    public UGUIExitEvent PointerExitPre { get; set; } = new UGUIExitEvent();
    public UGUIExitEvent PointerExited { get; set; } = new UGUIExitEvent();

    public override void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterPre?.Invoke();
        base.OnPointerEnter(eventData);
        PointerEntered?.Invoke();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        PointerExitPre?.Invoke();
        base.OnPointerExit(eventData);
        PointerExited?.Invoke();
    }
}
