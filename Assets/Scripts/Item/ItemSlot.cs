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
        // TODO : ������ ���� �����ֱ�
        Debug.Log("���콺 ȣ��");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // TODO : ����â �ݱ�
        Debug.Log("���콺 ����");
    }

    void Equip()
    {
        if (Inventory.slots[Inventory.CurEquipIndex].isEquiped) // ���� ������ ����
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
