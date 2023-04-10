using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GridManager gridManager;

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        gridManager.CellInit();
    }
}
