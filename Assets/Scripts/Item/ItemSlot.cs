using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemData Item;
    public GameObject EquipCheckMark;
    public Button SlotBtn;
    public InventoryUI Inventory;

    public int indexId = -1;
    public bool isEquiped = false;

    private void Start()
    {
        SlotBtn.onClick.AddListener(OnClickSlot);
    }

    void OnClickSlot()
    {
        isEquiped = !isEquiped;
        EquipCheckMark.SetActive(isEquiped);
        if(isEquiped)
        {
            Equip();
        }
        else
        {
            UnEquip();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // TODO : 아이템 정보 보여주기
        Debug.Log("마우스 호버");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // TODO : 정보창 닫기
        Debug.Log("마우스 나감");
    }

    void Equip()
    {
        if (Inventory.slots[Inventory.CurEquipIndex].isEquiped) // 현재 장착템 해제
        {
            Inventory.slots[Inventory.CurEquipIndex].UnEquip();
        }
        Inventory.CurEquipIndex = indexId;
        foreach(EquipableStat addStat in Item.Equipables)
        {
            GameManager.Instance.Player.Stat.ApplyStat(addStat);
        }
    }

    void UnEquip()
    {
        Inventory.CurEquipIndex = -1;
        foreach (EquipableStat addStat in Item.Equipables)
        {
            GameManager.Instance.Player.Stat.UnApplyStat(addStat);
        }
    }
}
