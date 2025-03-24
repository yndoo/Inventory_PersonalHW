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

    public int indexId = -1; // ���� ��ȣ
    public bool isEquiped = false; // ���� ���� �������� �����ߴ��� 

    private void Start()
    {
        SlotBtn.onClick.AddListener(OnClickSlot);
    }

    void OnClickSlot() // ���
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
        if (Inventory.CurEquipIndex >= 0 && Inventory.slots[Inventory.CurEquipIndex] != null && Inventory.slots[Inventory.CurEquipIndex].isEquiped) // ���� ������ ����
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
