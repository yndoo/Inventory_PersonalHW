using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public string Name;
    public int Level = 1;
    public float CurExp;
    public float CurGold;
    public float MaxExp;
    public float MaxGold = 50000;

    public PlayerInfo(string name, int level, float curExp, float maxExp)
    {
        Name = name;
        Level = level;
        CurExp = curExp;
        MaxExp = maxExp;
    }

    public void AddExp(float amount)
    {
        CurExp += amount;
        if (CurExp >= MaxExp)
        {
            Level += (int)(CurExp / MaxExp);
            CurExp %= MaxExp;
            MaxExp = Level * 5;
        }

        UIManager.Instance.GetUI<UserInfo>(EUIType.UserInfoUI).UpdateLevelUI(Level.ToString(), CurExp, MaxExp);

        if(Level >= 10)
        {
            GameManager.Instance.GameClear();
        }
    }

    public void AddGold(float amount)
    {
        CurGold += amount;
        if(CurGold >= MaxGold)
        {
            CurGold = MaxGold;
            GameManager.Instance.GameClear();
        }
        UIManager.Instance.GetUI<UserInfo>(EUIType.UserInfoUI).UpdateGoldUI(CurGold, MaxGold);
    }
}

