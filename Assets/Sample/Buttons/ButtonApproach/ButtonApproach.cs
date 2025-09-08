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

    [Header("¶¯»­²ÎÊý")]
    public Color ApproachTxtCol;
    public Color ApproachMaskCol;
    private Color TxtOriCol;

    private string tweenID;


    private void Awake()
    {
        tweenID = this.gameObject.name + GetInstanceID();

        m_rect = GetComponent<RectTransform>();
        TxtOriCol = Txt.color;
        Mask.color = ApproachMaskCol;
        EBtn.PointerEnter.AddListener(OnBtnPointerEnter);
        EBtn.PointerExit.AddListener(OnBtnPointerExit);
    }

    private void OnBtnPointerEnter()
    {
        CDoTween.Common.KillByTargetOrId(tweenID);

        Mask.rectTransform.DOSizeDelta(new Vector2(m_rect.sizeDelta.x, m_rect.sizeDelta.y), 0.2f).SetId(tweenID);
        Txt.DOColor(ApproachTxtCol, 0.2f).SetId(tweenID);

    }

    private void OnBtnPointerExit()
    {
        CDoTween.Common.KillByTargetOrId(tweenID);
        Mask.rectTransform.DOSizeDelta(new Vector2(0, m_rect.sizeDelta.y), 0.2f).SetId(tweenID);
        Txt.DOColor(TxtOriCol, 0.2f).SetId(tweenID);
    }


}
