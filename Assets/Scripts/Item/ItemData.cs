using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public string ItemDescription;
    public Sprite Icon;

    public Material Material;

    public EquipableStat[] Equipables;
}
public enum StatusType
{
    Attack,
    Defense,
    Health,
    CriticalRate,
    Cute,
}

[Serializable]
public class EquipableStat
{
    public StatusType type;
    public float value;
}