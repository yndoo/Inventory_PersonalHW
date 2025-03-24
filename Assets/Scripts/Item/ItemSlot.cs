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
        // TODO : 클릭 시 장착하기
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
}
