using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotteryItem : MonoBehaviour
{
    [SerializeField] List<Sprite> m_IconImages = new List<Sprite>();
    [SerializeField] Image m_Image;
    int m_RandomIndex;
    public void Setup()
    {
        m_RandomIndex = Random.Range(0, 3);
        m_Image.sprite = m_IconImages[m_RandomIndex];
        m_Image.SetNativeSize();
    }
}
