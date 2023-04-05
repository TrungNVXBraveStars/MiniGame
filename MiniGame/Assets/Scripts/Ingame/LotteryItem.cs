using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotteryItem : MonoBehaviour
{
    [SerializeField] List<GoldItem> items = new List<GoldItem>();
    public Image Icon;
    public Image backGround;
    public List<Sprite> list_BG = new List<Sprite>();
    public int value;
    public string infor;
    public string title;
    public void Setup()
    {
        int randomIndex = Random.Range(0, items.Count);
        Icon.sprite = items[randomIndex].icon;
        value = items[randomIndex].value;
        title = items[randomIndex].title;
        backGround.sprite = list_BG[0];
    }
    public void ChangeBackGround()
    {
        backGround.sprite = list_BG[1];
    }
}
