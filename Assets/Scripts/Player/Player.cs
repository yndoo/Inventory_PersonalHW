using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo Info;
    void Start()
    {
        UIManager.Instance.Show(EUIType.UserInfoUI, Info.Name, Info.Level, Info.CurExp, Info.MaxExp);   
    }
}

 