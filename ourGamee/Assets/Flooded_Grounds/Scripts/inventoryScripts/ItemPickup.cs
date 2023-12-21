using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Debug.Log(item.count);
        if (item.count < 6)
        {
            Destroy(gameObject);
        }

    }

    private void OnMouseDown()
    {
        Pickup();
    }


}
