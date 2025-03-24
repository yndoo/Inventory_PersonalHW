using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    void AddItem()
    {
        ItemData data = GameManager.Instance.Player.CurItemData;
        if (data == null) return;


    }
}
