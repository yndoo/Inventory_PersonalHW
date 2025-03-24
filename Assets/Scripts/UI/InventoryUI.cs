using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<ItemSlot> slots = new List<ItemSlot>();
    public int LastItemIndex = -1;
    public int CurEquipIndex;
    public RectTransform InventoryParent;

    private void Start()
    {
        GameObject slotPrefab = ResourceManager.Instance.LoadResource("Slot", "Prefab/UI");
        for(int i = 0; i < 16; i++)
        {
            GameObject slotGO = Instantiate(slotPrefab);
            slotGO.GetComponent<RectTransform>().SetParent(InventoryParent.transform, false);
            ItemSlot slot = slotGO.GetComponent<ItemSlot>();
            slot.indexId = i;
            slot.Inventory = this;
            slots.Add(slot);
            slotGO.SetActive(false);
        }
    }

    void AddItem()
    {
        ItemData data = GameManager.Instance.Player.CurItemData;
        if (data == null) return;

        // TODO : 아이템 먹는 코드 작성
        // LastItemIndex + 1 에 AddItem 
    }
}
