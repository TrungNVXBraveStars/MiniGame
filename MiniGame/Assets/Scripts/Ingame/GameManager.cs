using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] List<LotteryItem> m_LotteryListItems = new List<LotteryItem>();
    [SerializeField] Button m_Button;
    [SerializeField] GameObject m_Panel;
    [SerializeField] List<PopupItem> m_PopupItems = new List<PopupItem>();
    List<LotteryItem> m_PrizeItems = new List<LotteryItem>();

    void Start()
    {
        InitGrid();
    }

    public void InitGrid()
    {
        foreach (LotteryItem item in m_LotteryListItems)
        {
            item.Setup();
        }
    }
    public void OnNextClick()
    {

        int[] randomNumbers = GenerateRandomNumbers(3, 0, 15);

        foreach (int number in randomNumbers)
        {
            m_LotteryListItems[number].ChangeBackGround();
            m_PrizeItems.Add(m_LotteryListItems[number]);
        }
        m_Button.interactable = false;
        StartCoroutine(ShowPopup());
    }
    IEnumerator ShowPopup()
    {
        yield return new WaitForSeconds(1);
        m_Panel.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            m_PopupItems[i].gameObject.SetActive(true);
            m_PopupItems[i].Setup(m_PrizeItems[i].Icon.sprite, m_PrizeItems[i].title, "Obtain " + m_PrizeItems[i].value + " gold");
        }
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
}
