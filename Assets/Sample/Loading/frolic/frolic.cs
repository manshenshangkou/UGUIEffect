using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frolic : MonoBehaviour
{
    public Transform[] frolicChilds;
    public float interval = 0.1f;
    public float endPos = 0;
    public float duration = 1f;
    public Ease goease = Ease.InCubic;
    public Ease backease = Ease.InCubic;
    public float resttime = 1;


    private void Start()
    {
        //编辑器时间运行有问题（所以延迟1秒），在start执行的时候，editor做了一些其他操作，比如inspector刷新，editor GUI repaint ，editor layout rebuild 等等
        CDoTween.Common.delayCall(1, () =>
        {
            for (int i = 0; i < frolicChilds.Length; i++)
            {
                Transform targetTrans = frolicChilds[i];
                float oriY = targetTrans.localPosition.y;
                Sequence sq = DOTween.Sequence();
                sq.Append(targetTrans.DOLocalMoveY(endPos, duration).SetEase(goease));
                sq.Append(targetTrans.DOLocalMoveY(oriY, duration).SetEase(backease));
                sq.Append(CDoTween.Common.delayCall(resttime, null));
                sq.SetLoops(-1);
                sq.Pause();

                CDoTween.Common.delayCall(interval * i, () =>
                {
                    Debug.Log($"{targetTrans.name} {Time.realtimeSinceStartup}");
                    sq.Play();
                });
            }
        });




        //Debug.Log(DOTween.defaultUpdateType);

        //for (int i = 0; i < 5; i++)
        //{
        //    int index = i;
        //    DOVirtual.DelayedCall(interval * index, () =>
        //    {
        //        Debug.Log($"Test {Time.realtimeSinceStartup}");

        //    }).SetUpdate(true);
        //}


    }
}
