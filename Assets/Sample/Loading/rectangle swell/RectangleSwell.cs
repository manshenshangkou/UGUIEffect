using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RectangleSwell : MonoBehaviour
{
    public List<Transform> Rectangles;
    public Vector3 SwellCoe = Vector3.one;
    public float DurationTime = 0.2f;
    public float StayTime = 0.2f;
    public float IntervalTime = 0.1f;
    public Ease ease;
    void Start()
    {
        
        for (int i = 0; i < Rectangles.Count; i++)
        {
            Transform tran = Rectangles[i];
            Sequence sq = DOTween.Sequence();
            sq.Append(tran.DOScale(SwellCoe, DurationTime).SetEase(ease).SetLoops(2, LoopType.Yoyo));
            sq.Append(CDoTween.Common.delayCall(StayTime, null));
            sq.SetLoops(-1);
            sq.Pause();

            CDoTween.Common.delayCall(IntervalTime * i, () => sq.Play());


        }

    }
}
