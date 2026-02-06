using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpCharAnimation : MonoBehaviour
{
    [Header("jump char 需要文本设置为底部对齐")]
    public TMP_Text JumpTxt;
    public string JumpStr;
    public float JumpTopPos = 50;
    public float JumpingTime = 0.2f;
    public float IntervalTime = 0.25f;
    public bool Loop = true;
    public AnimationCurve Curve;
    Tweener tween;
    private void Awake()
    {
        JumpStr = JumpTxt.text;
        JumpTxt.richText = true;
        JumpTxt.alignment = TextAlignmentOptions.Bottom;
    }

    private void OnEnable()
    {
        StartCoroutine(Anim());
    }

    private void OnDisable()
    {
        tween?.Kill();
        StopCoroutine(Anim());
    }

    private IEnumerator Anim()
    {
        int index = 0;
        while (true)
        {
            if (index >= JumpStr.Length)
            {
                if (Loop)
                {
                    index = 0;
                }
                else
                {
                    break;
                }
            }
            JumpChar(index);
            yield return new WaitForSeconds(IntervalTime * 2);
            index++;
        }
    }

    private void JumpChar(int index)
    {
        tween?.Kill();
        if (index > JumpStr.Length - 1 || index < 0)
        {
            index = 0;
        }


        char[] chars = JumpStr.ToCharArray();
        List<char> left = new List<char>();
        List<char> right = new List<char>();
        for (int i = 0; i < chars.Length; i++)
        {
            if (i < index)
            {
                left.Add(chars[i]);
            }
            else if (i > index)
            {
                right.Add(chars[i]);
            }
        }

        float height = 0;
        tween = DOTween.To(() => height, x =>
        {
            height = x;
            JumpTxt.text = $"{new string(left.ToArray())}<voffset={height}>{chars[index]}</voffset>{new string(right.ToArray())}";
        }, JumpTopPos, JumpingTime).SetEase(Curve).SetLoops(2, LoopType.Yoyo);

    }
}
