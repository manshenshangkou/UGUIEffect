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

    private string enter_exit_tweenID;
    private string down_up_tweenID;


    private void Awake()
    {
        enter_exit_tweenID = this.gameObject.name + GetInstanceID() + Random.Range(100,200);
        down_up_tweenID = this.gameObject.name + GetInstanceID() + Random.Range(200,300);
        rectTransform = GetComponent<RectTransform>();


        EBtn.PointerEnter.AddListener(OnBtnPointerEnter);
        EBtn.PointerExit.AddListener(OnBtnPointerExit);
        EBtn.PointerDown.AddListener(OnBtnPointerDown);
        EBtn.PointerUp.AddListener(OnBtnPointerUp);
    }

    private void OnBtnPointerEnter()
    {
        CDoTween.Common.KillByTargetOrId(enter_exit_tweenID);

        HidingGra.DOFade(0, 0).SetId(enter_exit_tweenID);
        HidingGra.DOFade(1, 0.4f).SetId(enter_exit_tweenID);
        rectTransform.DOSizeDelta(new Vector2(EndWid, rectTransform.sizeDelta.y), 0.3f).SetEase(Ease.InQuad).SetId(enter_exit_tweenID);
    }

    private void OnBtnPointerExit()
    {
        CDoTween.Common.KillByTargetOrId(enter_exit_tweenID);

        HidingGra.DOFade(0, 0.3f).SetId(enter_exit_tweenID);
        rectTransform.DOSizeDelta(new Vector2(BegWid, rectTransform.sizeDelta.y), 0.3f).SetEase(Ease.OutQuad).SetId(enter_exit_tweenID);
    }

    private void OnBtnPointerDown()
    {
        CDoTween.Common.KillByTargetOrId(down_up_tweenID);
        rectTransform.DOScale(0.95f, 0.2f);
    }

    private void OnBtnPointerUp()
    {
        CDoTween.Common.KillByTargetOrId(down_up_tweenID);
        rectTransform.DOScale(1f, 0.2f);

    }



}
