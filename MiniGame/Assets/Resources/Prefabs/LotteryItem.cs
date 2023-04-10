using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class LotteryItem : MonoBehaviour
{
    public Image highLight;
    [SerializeField] private Image icon;
    [SerializeField] private Image backGround;
    [SerializeField] private List<Sprite> listBg;
    int value;
    string title;
    public void Setup(GoldItem item)
    {
        icon.sprite = item.icon;
        value = item.value;
        title = item.title;
        backGround.sprite = listBg[0];
    }
    public void ChangeBackGround(Action callback)
    {
        backGround.sprite = listBg[1];
        transform.DOScale(Vector3.one * 1.5f, 0.35f).OnComplete(() =>
        {
            transform.DOScale(Vector3.one, 0.25f);
        });
        callback?.Invoke();
    }

    public Tween DisplayHighlight()
    {
        var fadeTween = highLight.DOFade(1f, 0.06f).OnComplete(() =>
        {
            highLight.DOFade(0, 0.8f);
        });
        return fadeTween;
    }
    
}
