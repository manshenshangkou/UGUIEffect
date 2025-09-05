using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CaperingButton : Button
{
    public UnityAction NomalStateCb;
    public UnityAction HighlightedStateCb;
    public UnityAction PressedStateCb;
    public UnityAction SelectedStateCb;
    public UnityAction DisabledStateCb;
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        if (!gameObject.activeInHierarchy)
            return;

        switch (state)
        {
            case SelectionState.Normal:
                NomalStateCb?.Invoke();
                break;
            case SelectionState.Highlighted:
                HighlightedStateCb?.Invoke();
                break;
            case SelectionState.Pressed:
                PressedStateCb?.Invoke();
                break;
            case SelectionState.Selected:
                SelectedStateCb?.Invoke();
                break;
            case SelectionState.Disabled:
                DisabledStateCb?.Invoke();
                break;
            default:
                break;
        }
    }
}
