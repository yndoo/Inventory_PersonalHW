using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EUIType
{ 
    UserInfoUI,
    MenuUI,
    GameUI,
    End,
}

public class UIManager : Singleton<UIManager>
{
    public List<UIBase> uiList;
    private void LoadUI()
    {
        uiList = new List<UIBase>();
        
        for(int i = 0; i < (int)EUIType.End; i++)
        {
            //ResourceManager.Instance.LoadResource(((EUIType)i).ToString(), "Prefab/UI");
            //uiList.Add();
        }
    }

    public void Show(EUIType type)
    {

    }
}
