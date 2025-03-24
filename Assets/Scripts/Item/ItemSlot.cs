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
    public Image Icon;
    public Button SlotBtn;
    public InventoryUI Inventory;

    public int indexId = -1; // 슬롯 번호
    public bool isEquiped = false; // 현재 슬롯 아이템을 장착했는지 

    private void Start()
    {
        SlotBtn.onClick.AddListener(OnClickSlot);
    }

    void OnClickSlot() // 토글
    {
        if(!isEquiped)
        {
            Equip();
        }
        else
        {
            UnEquip();
        }

        EquipCheckMark.SetActive(isEquiped);
        UIManager.Instance.GetUI<GameUI>(EUIType.GameUI).GetComponentInChildren<StatusUI>(true).UpdateUI();
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
        if (Inventory.CurEquipIndex >= 0 && Inventory.slots[Inventory.CurEquipIndex] != null && Inventory.slots[Inventory.CurEquipIndex].isEquiped) // 현재 장착템 해제
        {
            Inventory.slots[Inventory.CurEquipIndex].UnEquip();
        }
        Inventory.slots[indexId].isEquiped = true;
        Inventory.CurEquipIndex = indexId;
        Player p = GameManager.Instance.Player;
        foreach (EquipableStat addStat in Item.Equipables)
        {
            p.Stat.ApplyStat(addStat);
        }
        p.HairMeshRenderer.material = Item.Material;
    }

    void UnEquip()
    {
        isEquiped = false;
        EquipCheckMark.SetActive(false);
        Inventory.CurEquipIndex = -1;
        Player p = GameManager.Instance.Player;
        foreach (EquipableStat addStat in Item.Equipables)
        {
            GameManager.Instance.Player.Stat.UnApplyStat(addStat);
        }
        p.HairMeshRenderer.material = p.OriginalMat;
    }

    public void SetSlot(ItemData newData)
    {
        Item = newData;
        Icon.sprite = newData.Icon;
    }
}
