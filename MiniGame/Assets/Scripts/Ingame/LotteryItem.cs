using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class LotteryItem : MonoBehaviour
{
    public Image icon;
    public Image backGround;
    public Image highLight;
    public List<Sprite> list_BG;
    public int value;
    public string infor;
    public string title;
    public void Setup(GoldItem item)
    {
        icon.sprite = item.icon;
        value = item.value;
        title = item.title;
        backGround.sprite = list_BG[0];
    }
    public void ChangeBackGround(Action callback)
    {
        backGround.sprite = list_BG[1];
        transform.DOScale(Vector3.one * 1.5f, 0.35f).OnComplete(() =>
        {
            transform.DOScale(Vector3.one, 0.25f);
        });
        callback?.Invoke();
    }
}
