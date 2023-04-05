using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class LotteryGrid : MonoBehaviour
{
    [SerializeField] List<LotteryItem> m_LotteryListItems = new List<LotteryItem>();
    //public List<LotteryItem> m_PrizeItems = new List<LotteryItem>();
    [SerializeField] int initSpinNumber;
    [SerializeField] int[] prizeList;
    int index_ = 0;
    private void Start()
    {
        prizeList = GenerateRandomNumbers(3, 0, 15);
        CellInit();
    }
    public void CellInit()
    {
        var sequence = DOTween.Sequence();
        foreach (LotteryItem item in m_LotteryListItems)
        {
            item.Setup();

            item.transform.localScale = Vector3.zero;
            Tween scaleTween = item.transform.DOScale(Vector3.one, 0.2f);
            sequence.Append(scaleTween);
        }
    }
    public void OnNextButtonClick()
    {
        Spin();
    }
    private int[] GenerateRandomNumbers(int count, int minValue, int maxValue)
    {
        int[] numbers = new int[count];

        for (int i = 0; i < count; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(minValue, maxValue + 1);
            }
            while (System.Array.IndexOf(numbers, randomNumber) != -1);

            numbers[i] = randomNumber;
        }

        return numbers;
    }
    private void Spin()
    {
        Debug.Log("AAA");
        var sequence = DOTween.Sequence();
        for (int i = 0; i < initSpinNumber; i++)
        {
            Debug.Log(i);
            foreach (LotteryItem item in m_LotteryListItems)
            {

                Tween scaleTween = item.highLight.DOFade(1f, 0.06f).OnComplete(() => item.highLight.DOFade(0, 0.8f));
                sequence.Append(scaleTween).OnComplete(() =>
                {
                    PrizeSpin(prizeList[index_]);
                    index_++;
                    if (index_ < prizeList.Length)
                    {
                        Spin();
                    }
                });

            }
            break;
        }

    }
    private void PrizeSpin(int index)
    {
        int i = 0;
        var sequence = DOTween.Sequence();
        foreach (var item in m_LotteryListItems)
        {
            if (i == index) break;

            Tween scaleTween = item.highLight.DOFade(1f, 0.06f).OnComplete(
                () =>
                {
                    item.highLight.DOFade(0, 0.8f);
                });
            sequence.Append(scaleTween).OnComplete(() =>
            {
                m_LotteryListItems[index].ChangeBackGround();
                m_LotteryListItems[index].transform.DOScale(Vector3.one * 1.3f, 0.35f).OnComplete(() =>
                m_LotteryListItems[index].transform.DOScale(Vector3.one, 0.25f));
            });
            i++;
        }

    }
}
