using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class RandomFood : MonoBehaviour
{
    public Button GoBtn;
    public RectTransform BGRect;

    private void Start()
    {
        GoBtn.onClick.AddListener(OnGoBtnClickHandle);
    }

    private void OnGoBtnClickHandle()
    {
        float randomRot = UnityEngine.Random.Range(0, 360);
        BGRect.DORotate(new Vector3(0, 0, 360) * 11 + Vector3.forward * randomRot, 3f, RotateMode.FastBeyond360).SetEase(Ease.InOutExpo);
    }
}
