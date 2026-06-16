using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingRotate : MonoBehaviour
{
    public Image img;
    void Start()
    {
        img.transform.DORotate(Vector3.forward * 360, 1, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);

        DOTween.To(()=>0, x => img.fillAmount = x, 0.8f, 2f).SetLoops(-1, LoopType.Yoyo);
    }

   
}
