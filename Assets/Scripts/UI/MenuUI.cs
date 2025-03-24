using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : UIBase
{
    public Button StatusBtn;
    public Button InventoryBtn;

    private void Start()
    {
        StatusBtn.onClick.AddListener(OnStatus);
        InventoryBtn.onClick.AddListener(OnInventory);
    }

    public override void Open(params object[] contexts)
    {

    }

    private void OnStatus()
    {
        Debug.Log("Status창 열기");
        UIManager.Instance.Show(EUIType.GameUI, true, false);
    }
    private void OnInventory()
    {
        Debug.Log("Inventory 열기");
        UIManager.Instance.Show(EUIType.GameUI, false, true);
    }
}
