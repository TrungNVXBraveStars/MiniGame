using System;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : Singleton<GridManager>
{
    [SerializeField] private List<ListItem> listItems;
    [SerializeField] private List<int> prizePositions;
    [SerializeField] private PrizeItems prizeData;
    [SerializeField] private Button button;
    [SerializeField] private int normalSpin;
    private int _prizeIndex;
    public List<ListItem> prizeList;

    [Serializable]
    public class ListItem
    {
        public LotteryItem lotteryItem;
        public GoldItem goldItem;
    }
    
    public void CellInit()
    {
        InitItemList();
        var sequence = DOTween.Sequence();
        foreach (var item in listItems)
        {
            item.lotteryItem.Setup(item.goldItem);
            item.lotteryItem.transform.localScale = Vector3.zero;
            Tween scaleTween = item.lotteryItem.transform.DOScale(Vector3.one, 0.1f);
            sequence.Append(scaleTween).OnComplete(() => button.gameObject.SetActive(true));
        }
    }
    private void InitItemList()
    {
        for (int i = 0; i < prizeData.Data.Count; i++)
        {
            listItems[i].goldItem = prizeData.Data[i].prizeItem;
        }
    }
    public void OnNextButtonClick()
    {
        button.gameObject.SetActive(false);
        FreeSpin();
    }
    private void FreeSpin()
    {
        var sequence = DOTween.Sequence();
        for (var i = 0; i < normalSpin; i++)
        {
            foreach (var fadeTween in listItems.Select(item => item.lotteryItem.DisplayHighlight()))
            {
                sequence.Append(fadeTween).OnComplete(() =>
                {
                    PrizeSpin(prizePositions[_prizeIndex]);
                    _prizeIndex++;
                    if (_prizeIndex < prizePositions.Count)
                    {
                        FreeSpin();
                    }
                });
            }
        }
    }
    private void PrizeSpin(int index)
    {
        var i = -1;
        var sequence = DOTween.Sequence();
        foreach (var scaleTween in listItems.TakeWhile(_ => i != index).Select(item => item.lotteryItem.DisplayHighlight()))
        {
            sequence.Append(scaleTween).OnComplete(() =>
            {
                listItems[index].lotteryItem.ChangeBackGround(_prizeIndex == prizePositions.Count ? PopupManager.Instance.ShowUp : null);
                prizeList.Add(listItems[index]);
            });
            i++;
        }
    }
}

