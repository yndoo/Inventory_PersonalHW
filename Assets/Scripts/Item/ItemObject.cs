using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData Data;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            if(player.Inventory.AddItem(Data))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
