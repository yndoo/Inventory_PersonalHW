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
            player.Info.AddExp(Random.Range(0.5f, 2f));
            if(player.Inventory.AddItem(Data))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
