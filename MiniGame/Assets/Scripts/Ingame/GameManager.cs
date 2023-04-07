using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Button m_Button;
    public void OnNextClick()
    {
        m_Button.gameObject.SetActive(false);
    }
}
