using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo Info;
    public PlayerStat Stat;
    public ItemData CurItemData;

    private void Awake()
    {
        Info = new PlayerInfo("Mandoo", 1, 0f, 10f);
        Stat = new PlayerStat(50, 10, 100, 0, 10);
    }

    void Start()
    {
        UIManager.Instance.Show(EUIType.UserInfoUI, Info.Name, Info.Level, Info.CurExp, Info.MaxExp);   
    }
}

 