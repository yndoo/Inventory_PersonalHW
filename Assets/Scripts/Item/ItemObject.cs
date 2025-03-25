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
            player.Info.AddExp(Random.Range(0.5f, 5f));
            player.Info.AddGold(Random.Range(100f, 1000f));

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
