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
    public Image ExpFill;

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
    }

    public void UpdateUserName(string Name)
    {
        UserIdText.text = Name;
    }

    public void UpdateLevelUI(string level, float exp, float maxExp)
    {
        LevelTxt.text = level.ToString();
        ExpFill.fillAmount = exp / maxExp;
        ExpText.text = $"{exp.ToString()} / {maxExp.ToString()}";
    }

}
