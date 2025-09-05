using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace CDoTween
{
    public static class Common
    {
        public static Tweener delayCallLinkObj(GameObject obj, float delayTime, System.Action callback)
        {
            int emptyValue = 0;
            return DOTween.To(() => emptyValue, x => x = emptyValue, 0, delayTime).OnComplete(() => {
                if (obj == null)
                    return;
                if (callback != null)
                    callback();
            });
        }

        public static Tweener delayCallLinkObj(GameObject obj, float delayTime,int LoopTime,LoopType type, System.Action callback)
        {
            int emptyValue = 0;
            return DOTween.To(() => emptyValue, x => x = emptyValue, 0, delayTime).OnComplete(() => {
                if (obj == null)
                    return;
                if (callback != null)
                    callback();
            }).SetLoops(LoopTime,type);
        }

        public static Tweener delayCall(float delayTime,System.Action callback, string ID = "")
        {
            if (delayTime <= 0)
            {
                callback?.Invoke();
                return null;
            }
            else
            {
                int emptyValue = 0;
                return DOTween.To(() => emptyValue, x => x = emptyValue, 0, delayTime).OnComplete(() => {
                    if (callback != null)
                        callback();
                }).SetId(ID);
            }
          
        }

        public static void CancelAllTween()
        {
            DOTween.Clear();
        }

        public static void PauseAll()
        {
            DOTween.PauseAll();
        }

        public static void PlayByTargetOrId(object targetOrId)
        {
            DOTween.Play(targetOrId);
        }

        public static void PauseByTargetOrId(object targetOrId)
        {
            DOTween.Pause(targetOrId);
        }

        public static void KillByTargetOrId(object targetOrId, bool complete = false)
        {
            DOTween.Kill(targetOrId, complete);
        }


        public static void DynamicChangeValue(Text textComp,int startValue, int endValue, float duration)
        {
            int tempValue = startValue;
            Tweener loopTweener = DOTween.To(() => tempValue, x => tempValue = x, endValue, 2f).SetEase(Ease.OutQuart).SetTarget(textComp);
            loopTweener.OnUpdate(() =>
             {
                 if (textComp == null)
                 {
                     loopTweener.Kill();
                     return;
                 }
                 textComp.text = tempValue.ToString();
             });
        }

        public static Tweener OneSecondUpdate(double startValue, float endValue, Transform trans, Action<double> onUpdateCallBack = null)
        {
            if (trans == null)
                return null;
            int tempValue = (int)startValue;
            Tweener loopTweener = DOTween.To( ()=> tempValue, x => tempValue = x, (int)endValue,1f).SetLoops(-1).SetTarget(trans);
            loopTweener.OnStepComplete(() =>
            {
                if (trans == null)
                {
                    loopTweener.Kill();
                    return;
                }
                startValue--;
                onUpdateCallBack(startValue);
            });
            return loopTweener;
        }


        public static Sequence ShakeRotation(Transform target,float strength)
        {
            target.localEulerAngles = Vector3.zero;
            Sequence sq = DOTween.Sequence();
            sq.Append(target.DORotate(Vector3.forward * strength, 0.1f));
            sq.Append(target.DORotate(Vector3.forward * -strength, 0.1f));
            sq.Append(target.DORotate(Vector3.forward * strength * 0.5f, 0.05f));
            sq.Append(target.DORotate(Vector3.forward * -strength * 0.5f, 0.05f));
            sq.Append(target.DORotate(Vector3.zero, 0.05f));
            return sq;
        }
    }
}
