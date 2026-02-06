using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonApproach : MonoBehaviour
{
    public EddyButton EBtn;

    public Image Mask;
    public Text Txt;

    private RectTransform m_rect;
    private Vector3 oriPos;
    private Shadow btnShadow;
    private Vector2 oriShadowPos;

    [Header("¶¯»­²ÎÊý")]
    public Color ApproachTxtCol;
    public Color ApproachMaskCol;
    private Color TxtOriCol;

    private string enterTweenID;
    private string clickTweenID;


    private void Awake()
    {
        enterTweenID = this.gameObject.name + GetInstanceID() + "enter";
        clickTweenID = this.gameObject.name + GetInstanceID() + "click";

        m_rect = GetComponent<RectTransform>();
        btnShadow = GetComponent<Shadow>();
        oriPos = m_rect.localPosition;
        oriShadowPos = btnShadow.effectDistance;

        TxtOriCol = Txt.color;
        Mask.color = ApproachMaskCol;
        EBtn.PointerEnter.AddListener(OnBtnPointerEnter);
        EBtn.PointerExit.AddListener(OnBtnPointerExit);
        EBtn.PointerDown.AddListener(OnBtnPointerDown);
        EBtn.PointerUp.AddListener(OnBtnPointerUp);
    }

    private void OnBtnPointerEnter()
    {
        CDoTween.Common.KillByTargetOrId(enterTweenID);

        Mask.rectTransform.DOSizeDelta(new Vector2(m_rect.sizeDelta.x, m_rect.sizeDelta.y), 0.2f).SetId(enterTweenID);
        Txt.DOColor(ApproachTxtCol, 0.2f).SetId(enterTweenID);
    }

    private void OnBtnPointerExit()
    {
        CDoTween.Common.KillByTargetOrId(enterTweenID);
        Mask.rectTransform.DOSizeDelta(new Vector2(0, m_rect.sizeDelta.y), 0.2f).SetId(enterTweenID);
        Txt.DOColor(TxtOriCol, 0.2f).SetId(enterTweenID);
    }

    private void OnBtnPointerDown()
    {
        CDoTween.Common.KillByTargetOrId(clickTweenID);


        Vector3 shadowPos = btnShadow.effectDistance;
        m_rect.DOLocalMove(oriPos + shadowPos, 0.2f).SetId(clickTweenID);

        DOTween.To(() => btnShadow.effectDistance,
            x => btnShadow.effectDistance = x,
            Vector2.zero,
            0.2f).SetId(clickTweenID);
    }

    private void OnBtnPointerUp()
    {
        CDoTween.Common.KillByTargetOrId(clickTweenID);


        m_rect.DOLocalMove(oriPos, 0.2f).SetId(clickTweenID);
        DOTween.To(() => btnShadow.effectDistance,
            x => btnShadow.effectDistance = x,
            oriShadowPos,
            0.2f).SetId(clickTweenID);

    }


}
