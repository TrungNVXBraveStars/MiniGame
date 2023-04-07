using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public List<GoldItem> PrizeList;
    [SerializeField] List<LotteryItem> m_ListItems;
    [SerializeField] List<GoldItem> m_ItemData;
    [SerializeField] List<GoldItem> m_BaseData;
    [SerializeField] int[] m_PrizeIndices;
    int freeSpinRound = 2;
    int prizeIndex = 0;
    int prizeIndex2 = 0;
    private void Start()
    {
        InitItemList();
        CellInit();
    }
    private void InitItemList()
    {
        for (int i = 0; i < m_ItemData.Count; i++)
        {
            if (m_PrizeIndices.Contains(i))
            {
                m_ItemData[i] = PrizeList[prizeIndex2];
                prizeIndex2++;
            }

            else
                m_ItemData[i] = m_BaseData[Random.Range(0, m_BaseData.Count)];
        }
    }
    public void CellInit()
    {
        var sequence = DOTween.Sequence();
        for (int i = 0; i < m_ListItems.Count; i++)
        {
            m_ListItems[i].Setup(m_ItemData[i]);
            m_ListItems[i].transform.localScale = Vector3.zero;
            Tween scaleTween = m_ListItems[i].transform.DOScale(Vector3.one, 0.1f);
            sequence.Append(scaleTween).OnComplete(() => GameManager.Instance.m_Button.gameObject.SetActive(true));
        }

    }
    public void OnNextButtonClick()
    {
        FreeSpin();
    }
    private void FreeSpin()
    {
        //List<LotteryItem> listItems = m_ListItems;
        var sequence = DOTween.Sequence();
        for (int i = 0; i < freeSpinRound; i++)
        {
            foreach (LotteryItem item in m_ListItems)
            {
                Tween scaleTween = item.highLight.DOFade(1f, 0.06f).OnComplete(() => item.highLight.DOFade(0, 0.8f));
                sequence.Append(scaleTween).OnComplete(() =>
                {
                    PrizeSpin(m_PrizeIndices[prizeIndex]);
                    prizeIndex++;
                    if (prizeIndex < m_PrizeIndices.Length)
                    {
                        FreeSpin();
                    }
                });
            }
        }
    }
    private void PrizeSpin(int index)
    {
        int i = -1;
        var sequence = DOTween.Sequence();
        foreach (var item in m_ListItems)
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
                    m_ListItems[index].ChangeBackGround(prizeIndex == 3 ? PopupManager.Instance.ShowUp : null);
                });
            i++;
        }
    }
}

