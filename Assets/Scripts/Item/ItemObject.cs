using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData Data;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player player = other.GetComponentInParent<Player>();
            PlayerInfo info = player.Info;
            info.AddExp(info.Level * Random.Range(0.5f, 5f));
            info.AddGold(info.Level * Random.Range(30f, 1000f));

            if (player.Inventory.AddItem(Data))
            {
                Invoke("ItemRegen", 5f);
                Invoke("ItemHide", 0.01f);
            }
        }
    }

    void ItemHide()
    {
        this.gameObject.SetActive(false);
    }

    void ItemRegen()
    {
        float rx = Random.Range(-45, 45);
        float rz = Random.Range(-45, 45);
        transform.position = new Vector3(rx, 1, rz);
        this.gameObject.SetActive(true);
    }
}
