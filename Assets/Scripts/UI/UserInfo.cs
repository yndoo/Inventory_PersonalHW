using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UserInfo : UIBase
{
    public TextMeshProUGUI UserIdText;
    public TextMeshProUGUI LevelTxt;
    public TextMeshProUGUI ExpText;
    public TextMeshProUGUI GoldText;
    public Image ExpFill;
    public Image GoldFill;

    public override void Init()
    {
        PlayerInfo p = GameManager.Instance.Player.Info;
        Open(p.Name, p.Level, p.CurExp, p.MaxExp, 0, p.MaxGold);
    }

    /// <param name="contexts">UserName, Level, CurExp, MaxExp</param>
    public override void Open(params object[] contexts)
    {
        if(contexts.Length < 4)
        {
            object[] old = contexts;
            contexts = new string[4];
            for(int i = 0; i < 4; i++)
            {
                contexts[i] = i < old.Length ? old[i] : -1;
            }
        }
        UpdateUserName(contexts[0].ToString());
        UpdateLevelUI(contexts[1].ToString(), Convert.ToSingle(contexts[2]), Convert.ToSingle(contexts[3]));
        UpdateGoldUI(Convert.ToSingle(contexts[4]), Convert.ToSingle(contexts[5]));
    }

    public void UpdateUserName(string Name)
    {
        UserIdText.text = Name;
    }

    public void UpdateLevelUI(string level, float exp, float maxExp)
    {
        LevelTxt.text = $"Lv {level.ToString()}";
        ExpFill.fillAmount = exp / maxExp;
        ExpText.text = $"{exp.ToString()} / {maxExp.ToString()}";
    }

    public void UpdateGoldUI(float curGold, float maxGold)
    {
        GoldFill.fillAmount = curGold / maxGold;
        GoldText.text = $"{curGold.ToString()} / {maxGold.ToString()}";
    }
}
