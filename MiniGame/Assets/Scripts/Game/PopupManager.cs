using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] private PrizeItems prizeList;
    [SerializeField] private List<PopupItem> popupItems;
    [SerializeField] private GameObject panel;
    public void ShowUp()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        panel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        foreach (var popup in popupItems)
        {
            popup.gameObject.SetActive(true);
        }

        var data = GridManager.Instance.prizeList;
        for (var i = 0; i < popupItems.Count; i++)
        {
            popupItems[i].gameObject.SetActive(true);
            var icon = data[i].goldItem.icon;
            var title = data[i].goldItem.title;
            var info = "Obtain " + data[i].goldItem.value + " coin";
            popupItems[i].Setup(icon, title, info);
        }
    }
}
