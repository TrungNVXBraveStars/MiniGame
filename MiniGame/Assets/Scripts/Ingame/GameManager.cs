using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Button m_Button;
    public void OnNextClick()
    {
        m_Button.gameObject.SetActive(false);
    }
}
