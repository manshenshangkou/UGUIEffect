using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestToggleAPI : MonoBehaviour
{
    public Toggle Tgl;
    // Start is called before the first frame update
    void Start()
    {
        Tgl.onValueChanged.AddListener(OnTglValueChangedHandle);
    }

    private void OnTglValueChangedHandle(bool ison)
    {
        Debug.Log($"toggle value changed : {ison}");
    }


    [ContextMenu("DontNotify")]
    private void DontNotify()
    {
        Tgl.SetIsOnWithoutNotify(!Tgl.isOn);
    }

    [ContextMenu("Notify")]
    private void Notify()
    { 
        Tgl.isOn = !Tgl.isOn;
    }
}
