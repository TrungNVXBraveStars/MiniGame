using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create Item")]
public class GoldItem : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite icon;
    public int value;
}
