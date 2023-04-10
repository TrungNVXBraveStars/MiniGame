using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupItem : MonoBehaviour
{

    [SerializeField] Image m_IconItem;
    [SerializeField] TextMeshProUGUI m_Title;
    [SerializeField] TextMeshProUGUI m_Infor;

    public void Setup(Sprite Icon, string Title, string Infor)
    {
        m_IconItem.sprite = Icon;
        m_Title.text = Title;
        m_Infor.text = Infor;
    }
}
