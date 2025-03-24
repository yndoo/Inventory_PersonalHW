using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIBase
{
    public StatusUI StatusUI;
    public InventoryUI InventoryUI;
    public Button BackBtn;

    private void Start()
    {
        BackBtn.onClick.AddListener(OnBack);
    }

    public override void Open(params object[] contexts)
    {
        StatusUI.gameObject.SetActive(Convert.ToBoolean(contexts[0]));
        InventoryUI.gameObject.SetActive(Convert.ToBoolean(contexts[1]));
    }

    void OnBack()
    {
        UIManager.Instance.Hide(EUIType.GameUI);
    }
}
