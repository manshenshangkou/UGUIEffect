using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonFirecracker : MonoBehaviour
{
    public EddyButton EBtn;

    public Graphic HidingGra;
    private RectTransform rectTransform;


    [Header("¶¯»­²ÎÊý")]
    public float BegWid;
    public float EndWid;

    private string tweenID;


    private void Awake()
    {
        tweenID = this.gameObject.name + GetInstanceID();
        rectTransform = GetComponent<RectTransform>();


        EBtn.PointerEnter.AddListener(OnBtnPointerEnter);
        EBtn.PointerExit.AddListener(OnBtnPointerExit);
    }

    private void OnBtnPointerEnter()
    {
        CDoTween.Common.KillByTargetOrId(tweenID);

        HidingGra.DOFade(0, 0).SetId(tweenID);
        HidingGra.DOFade(1, 0.4f).SetId(tweenID);
        rectTransform.DOSizeDelta(new Vector2(EndWid, rectTransform.sizeDelta.y), 0.3f).SetEase(Ease.InQuad).SetId(tweenID);
    }

    private void OnBtnPointerExit()
    {
        CDoTween.Common.KillByTargetOrId(tweenID);

        HidingGra.DOFade(0, 0.3f).SetId(tweenID);
        rectTransform.DOSizeDelta(new Vector2(BegWid, rectTransform.sizeDelta.y), 0.3f).SetEase(Ease.OutQuad).SetId(tweenID);
    }



}
