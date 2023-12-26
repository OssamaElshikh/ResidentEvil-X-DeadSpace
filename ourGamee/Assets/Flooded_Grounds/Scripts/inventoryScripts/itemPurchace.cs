using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPurchace : MonoBehaviour
{
     
    // Start is called before the first frame update
    

    // Update is called once per frame
    

    public void Pickup(Item item)
    {
        if(InventoryManager.Instance.purchasable == true)
        {
            Debug.Log("picked item " + item.itemName);
            InventoryManager.Instance.Add(item);
            Debug.Log("item count " + item.count);

        }
        else
        {
            Debug.Log("unpicked item " + item.itemName);
        }

        

        //if (item.ItemsCount < 6)
        //{
        //    Destroy(gameObject);
        //}

    }
}
