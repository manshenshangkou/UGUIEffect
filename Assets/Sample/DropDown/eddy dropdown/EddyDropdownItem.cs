using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EddyDropdownItem : MonoBehaviour
{
    Button btn;
    Text txt;


    int index;
    UnityAction<int> clicked;
    private void Awake()
    {
        btn = transform.Find("EddyDpdItemBtn").GetComponent<Button>();
        txt = btn.transform.Find("Text").GetComponent<Text>();
        btn.onClick.AddListener(OnBtnClickHandle);   
    }
    public void Init(string content,int index, UnityAction<int> clicked)
    {
        this.index = index;
        this.clicked = clicked;
    }


    private void OnBtnClickHandle()
    {
        clicked?.Invoke(index);
    }
}
