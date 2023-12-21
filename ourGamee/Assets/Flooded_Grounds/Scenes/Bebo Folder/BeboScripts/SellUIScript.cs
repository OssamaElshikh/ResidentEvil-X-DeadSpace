using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SellUIScript : MonoBehaviour

{
    public GameObject sellItemPrefab; // Prefab for displaying sellable items
    public Transform sellItemsContainer; // Container for the sellable items UI

    public Inventory inventory; // Reference to the inventory script or system
    public List<Item> sellableItems; // List of sellable items

    void Start()
    {
        DisplaySellableItems();
    }

    void DisplaySellableItems()
    {
        foreach (Item item in inventory.GetItems()) // GetItems() returns items in the inventory
        {
            if (sellableItems.Contains(item)) // Check if the item is sellable
            {
                GameObject sellItem = Instantiate(sellItemPrefab, sellItemsContainer);
                // Set sell item UI properties (icon, name, sell price)

                // Example: Set item icon (assuming you have an Image component for the icon)
                // sellItem.GetComponentInChildren<Image>().sprite = item.icon;

                // Example: Set item name and sell price (assuming you have Text components)
                // sellItem.GetComponentInChildren<Text>().text = item.name + " - Sell Price: " + item.sellPrice;

                // Attach a Sell button click event
                Button sellButton = sellItem.GetComponentInChildren<Button>();
                sellButton.onClick.AddListener(() => SellItem(item)); // Sell the item when the button is clicked
            }
        }
    }

    void SellItem(Item item)
    {
        // Logic to sell the item
        // Remove the item from the inventory and add currency, etc.
        inventory.RemoveItem(item);
        // Add currency equivalent to the sell price
    }
}
