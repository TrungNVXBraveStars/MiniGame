using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] List<PopupItem> m_PopupItems;
    [SerializeField] GameObject m_Panel;
    public void ShowUp()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        m_Panel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        foreach (var popup in m_PopupItems)
        {
            popup.gameObject.SetActive(true);
        }
        for (int i = 0; i < m_PopupItems.Count; i++)
        {
            m_PopupItems[i].gameObject.SetActive(true);
            var icon = GridManager.Instance.PrizeList[i].icon;
            var title = GridManager.Instance.PrizeList[i].title;
            var infor = "Obtain " + GridManager.Instance.PrizeList[i].value + " coin";
            m_PopupItems[i].Setup(icon, title, infor);
        }
    }
}
