using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<LotteryItem> m_LotteryListItems = new List<LotteryItem>();

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
}
