using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPurchace : MonoBehaviour
{

    // Start is called before the first frame update


    // Update is called once per frame


    public void Pickup(Item item)
    {
        if (InventoryManager.Instance.purchasable == true)
        {
            Debug.Log("picked item " + item.itemName);

            Debug.Log("item count " + item.count);
            if (item.itemType == Item.ItemType.Ammo)
            {
                bool itemExists = false;

                // Check if an item with the same itemName exists in the list
                foreach (Item existingItem in InventoryManager.Instance.Items)
                {
                    if (existingItem.itemName == item.itemName)
                    {
                        itemExists = true;
                        InventoryManager.Instance.GetExistingItemAndUpdateCount(existingItem);
                        Debug.Log("Item exists in list" + existingItem.ammo);

                        break; // Exit the loop since we found a matching item
                    }
                }

                if (!itemExists)
                {
                    InventoryManager.Instance.Add(item);
                }
            }
            else
            {
                InventoryManager.Instance.Add(item);
            }


        }
        else
        {
            Debug.Log("unpicked item " + item.itemName);
        }



        //if (item.ItemsCount < 6)
        //{
        //    Destroy(gameObject);
        //}
        InventoryManager.Instance.ListItems();

    }

}