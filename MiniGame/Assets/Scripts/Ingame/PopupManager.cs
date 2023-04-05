using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupManager : MonoBehaviour
{
    [SerializeField] List<PopupItem> m_PopupItems = new List<PopupItem>();
    [SerializeField] LotteryGrid m_LotteryGrid;
    [SerializeField] GameObject m_Panel;
    public void ShowUp()
    {
        //StartCoroutine(ShowPopup());
    }
    //IEnumerator ShowPopup()
    //{
    //    yield return new WaitForSeconds(1);
    //    m_Panel.SetActive(true);
    //    for (int i = 0; i < 3; i++)
    //    {
    //        m_PopupItems[i].gameObject.SetActive(true);
    //        m_PopupItems[i].Setup(m_LotteryGrid.m_PrizeItems[i].Icon.sprite, m_LotteryGrid.m_PrizeItems[i].title, "Obtain " + m_LotteryGrid.m_PrizeItems[i].value + " gold");
    //    }
    //}
}
