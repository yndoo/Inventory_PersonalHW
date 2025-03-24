using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public Sprite Icon;
    public int Quantity;

    public ConsumableType[] Consumables;
}
public enum ConsumableType
{
    Attack,
    Defense,
    Health,
    CriticalRate,
    Cute,
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}