using System;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GridManager : Singleton<GridManager>
{
    public List<GoldItem> prizeList;
    [SerializeField] List<LotteryItem> listItems;
    [SerializeField] List<GoldItem> itemData;
    [SerializeField] List<GoldItem> baseData;
    [SerializeField] int[] prizeIndices;
    [SerializeField] private Button button;
    int _normalSpin = 2;
    int _prizeIndex;
    int _prizeIndex2;
    
    public void CellInit()
    {
        InitItemList();
        var sequence = DOTween.Sequence();
        for (var i = 0; i < listItems.Count; i++)
        {
            listItems[i].Setup(itemData[i]);
            listItems[i].transform.localScale = Vector3.zero;
            Tween scaleTween = listItems[i].transform.DOScale(Vector3.one, 0.1f);
            sequence.Append(scaleTween).OnComplete(() => button.gameObject.SetActive(true));
        }
    }
    private void InitItemList()
    {
        for (var i = 0; i < itemData.Count; i++)
        {
            if (prizeIndices.Contains(i))
            {
                itemData[i] = prizeList[_prizeIndex2];
                _prizeIndex2++;
            }
            else
            {
                itemData[i] = baseData[Random.Range(0, baseData.Count)];
            }
        }
    }
    public void OnNextButtonClick()
    {
        button.gameObject.SetActive(false);
        FreeSpin();
    }
    private void FreeSpin()
    {
        //List<LotteryItem> listItems = m_ListItems;
        var sequence = DOTween.Sequence();
        for (var i = 0; i < _normalSpin; i++)
        {
            foreach (var item in listItems)
            {
                Tween scaleTween = item.highLight.DOFade(1f, 0.06f).OnComplete(() => 
                    item.highLight.DOFade(0, 0.8f));
                sequence.Append(scaleTween).OnComplete(() =>
                {
                    PrizeSpin(prizeIndices[_prizeIndex]);
                    _prizeIndex++;
                    if (_prizeIndex < prizeIndices.Length)
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
        foreach (var item in listItems)
        {
            if (i == index) break;

            Tween scaleTween = item.highLight.DOFade(1f, 0.06f).OnComplete(
                () =>
                {
                    item.highLight.DOFade(0, 0.8f);
                });
            sequence.Append(scaleTween)
                .OnComplete(() =>
                {
                    listItems[index].ChangeBackGround(_prizeIndex == 3 ? PopupManager.Instance.ShowUp : null);
                });
            i++;
        }
    }
}

