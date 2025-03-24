using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<ItemSlot> slots = new List<ItemSlot>();
    public int LastItemIndex = -1;
    public int CurEquipIndex = -1;
    public RectTransform InventoryParent;

    // 아이템 정보창
    public GameObject ItemDescObj;
    private TextMeshProUGUI[] ItemDescTexts;

    public void InitInventory()
    {
        GameManager.Instance.Player.Inventory = this;
        GameObject slotPrefab = ResourceManager.Instance.LoadResource("Slot", "Prefab/UI");
        for (int i = 0; i < 16; i++)
        {
            GameObject slotGO = Instantiate(slotPrefab);
            slotGO.GetComponent<RectTransform>().SetParent(InventoryParent.transform, false);
            ItemSlot slot = slotGO.GetComponent<ItemSlot>();
            slot.indexId = i;
            slot.Inventory = this;
            slots.Add(slot);
            slotGO.SetActive(false);
        }

        ItemDescTexts = ItemDescObj.GetComponentsInChildren<TextMeshProUGUI>();
    }

    public bool AddItem(ItemData addItem)
    {
        if(LastItemIndex + 1 >= slots.Count)
        {
            return false;
        }
        slots[LastItemIndex + 1].gameObject.SetActive(true);
        slots[LastItemIndex + 1].SetSlot(addItem);
        LastItemIndex++;
        return true;
    }

    public void ShowItemDesc(string name, string desc)
    {
        ItemDescObj.SetActive(true);
        ItemDescTexts[0].text = name;
        ItemDescTexts[1].text = desc;
    }
    public void OffItemDesc()
    {
        ItemDescObj.SetActive(false);
    }
}
