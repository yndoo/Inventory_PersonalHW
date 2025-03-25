using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EUIType
{ 
    UserInfoUI,
    MenuUI,
    GameUI,
    ClearMessage,
    End,
}

public class UIManager : Singleton<UIManager>
{
    public Canvas canvas;
    public List<UIBase> uiList;
    public List<GameObject> uiObjectList;

    protected override void Awake()
    {
        base.Awake();
        if (uiList == null) LoadUI();
    }

    public void LoadUI()
    {
        uiList = new List<UIBase>();
        if(canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
        }
        
        for(int i = 0; i < (int)EUIType.End; i++)
        {
            GameObject res = ResourceManager.Instance.LoadResource(((EUIType)i).ToString(), "Prefab/UI");
            if (res == null) return;

            GameObject go = Instantiate(res);
            go.GetComponent<RectTransform>().SetParent(canvas.transform, false);

            UIBase ui = go.GetComponent<UIBase>();

            if(ui == null)
            {
                uiObjectList.Add(go);
            }
            else
            {
                ui.Init();
                go.SetActive(ui.IsInitActive);
                uiList.Add(ui);
            }
        }
    }

    public void Show(EUIType type, params object[] contexts)
    {
        UIBase ui = uiList[(int)type];
        ui.gameObject.SetActive(true);
        ui.Open(contexts);
    }

    public void Hide(EUIType type, params object[] contexts)
    {
        UIBase ui = uiList[(int)type];
        ui.gameObject.SetActive(false);
    }

    public UIBase GetUI(EUIType type) 
    {
        return uiList[(int)type];
    }

    public T GetUI<T>(EUIType type) where T : UIBase 
    {
        return uiList[(int)type] as T;
    }

    public GameObject GetUIObject(int index)
    {
        if(index < 0 || index >= uiObjectList.Count) return null;
        return uiObjectList[index];
    }
}
