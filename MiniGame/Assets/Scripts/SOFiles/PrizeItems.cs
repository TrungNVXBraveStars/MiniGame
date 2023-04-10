using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prize List", menuName = "Prize List")]
public class PrizeItems : ScriptableObject
{
    [Serializable]
    public class PrizeData
    {
        public int prizeIndex;
        public GoldItem prizeItem;
        public bool isPrized;
    }

    public List<PrizeData> Data;
}
