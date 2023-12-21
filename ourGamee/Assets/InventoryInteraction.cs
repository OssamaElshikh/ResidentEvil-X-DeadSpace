using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteraction : MonoBehaviour
{
    public GameObject inventoryCanvas; // Reference to the Inventory Canvas GameObject
    private bool isInventoryActive = false;
    InventoryManager inventoryManager;

    void Update()
    {
        ActivateInventory();
    }

    public void ActivateInventory()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            // Toggle the inventory canvas state
            isInventoryActive = !isInventoryActive;
            //inventoryManager.ListItems(); 
            // Set the Inventory Canvas based on the state
            inventoryCanvas.SetActive(isInventoryActive);
        }
    }
}
