using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create Item")]
public class GoldItem : ScriptableObject
{
    public Sprite icon;
    public int value;
    public string title;
}

