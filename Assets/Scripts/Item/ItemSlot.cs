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


    private void Start()
    {
        SlotBtn.onClick.AddListener(OnClickSlot);
    }

    void OnClickSlot()
    {
        // TODO : Ŭ�� �� �����ϱ�
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
}
