using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat 
{
    public float Attack {  get; set; }
    public float Defense {  get; set; }
    public float Health { get; set; }
    public float CriticalRate { get; set; }
    public float Cute { get; set; }

    public PlayerStat(float attack, float defense, float health, float criticalRate, float cute)
    {
        Attack = attack;
        Defense = defense;
        Health = health;
        CriticalRate = criticalRate;
        Cute = cute;
    }

    public void ApplyStat(EquipableStat newStat)
    {
        switch(newStat.type)
        {
            case StatusType.Attack:
                Attack += newStat.value;
                break;
            case StatusType.Defense:
                Defense += newStat.value;
                break;
            case StatusType.Health:
                Health += newStat.value;
                break;
            case StatusType.CriticalRate:
                CriticalRate += newStat.value;
                break;
            case StatusType.Cute:
                Cute += newStat.value;
                break;
            default:
                break;
        }
    }

    public void UnApplyStat(EquipableStat oldStat)
    {
        switch (oldStat.type)
        {
            case StatusType.Attack:
                Attack -= oldStat.value;
                break;
            case StatusType.Defense:
                Defense -= oldStat.value;
                break;
            case StatusType.Health:
                Health -= oldStat.value;
                break;
            case StatusType.CriticalRate:
                CriticalRate -= oldStat.value;
                break;
            case StatusType.Cute:
                Cute -= oldStat.value;
                break;
            default:
                break;
        }
    }
}
