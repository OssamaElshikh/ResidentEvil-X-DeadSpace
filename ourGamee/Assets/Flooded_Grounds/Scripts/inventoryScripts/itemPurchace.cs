using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPurchace : MonoBehaviour
{
     
    // Start is called before the first frame update
    

    // Update is called once per frame
    

    public void Pickup(Item item)
    {
        InventoryManager.Instance.Add(item);
        Debug.Log("item count " + item.count);
        if (item.ItemsCount < 6)
        {
            Destroy(gameObject);
        }
    }
}
