using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LotteryItem m_LotteryItem;
    [SerializeField] Transform m_ParentTransform;
    int m_NoCell = 25;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCell();
    }

    void SpawnCell()
    {
        for (int i = 0; i < m_NoCell; i++)
        {
            LotteryItem item = Instantiate(m_LotteryItem, m_ParentTransform);
            item.Setup();
        }
    }
}
