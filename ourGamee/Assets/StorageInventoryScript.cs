using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageInventoryScript : MonoBehaviour
{
    public InventoryManager invManager;

    public Transform ItemContent;
    public GameObject InventoryItem;

    List<Item> Items;
    public List<Item> storageItems = new List<Item>();

    private GameObject selectedObject;
    private Item selectedItem;


    public Transform storageItemContent;
    public GameObject storageItem;


    private bool isCombining = false;
    private GameObject combineObject;
    private Item combineItem;

    public Sprite greenMixIcon;
    public Sprite redMixIcon;
    public Sprite yellowMixIcon;

    public Sprite pistolAmmo;
    public Sprite shotgunAmmo;
    public Sprite riffleAmmo;
    public Sprite revolverAmmo;

    public Image ErrorMessage;


    private bool isPaused = false;
    private CursorLockMode previousLockMode; // To store the previous cursor lock mode


    // Start is called before the first frame update
    void Start()
    {
        Items = InventoryManager.Instance.Items;
        ListItems();
    }



    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.V))
        {
            PauseGame();
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.V))
        {
            ResumeGame();
        }
     
    }


    public void PauseGame()
    {
        isPaused = true;
        previousLockMode = Cursor.lockState; // Store the current cursor lock mode
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Restore the time scale
        Cursor.lockState = previousLockMode; // Restore the previous cursor lock mode
        Cursor.visible = false; // Hide the cursor
    }


    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();



            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var button = obj.GetComponent<Button>();

            itemName.text = item.itemName + " x" + item.count;
            itemIcon.sprite = item.icon;

            if (item.itemName == "Pistol" || item.itemName == "Shotgun" || item.itemName == "Riffle" || item.itemName == "Revolver")
            {
                itemName.text += " : ";
                itemName.text += item.ammo;
            }
            button.onClick.AddListener(() => SelectItem(obj, item));
        }
    }

    public void storageListItems()
    {
        foreach (Transform item in storageItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in storageItems)
        {
            GameObject obj = Instantiate(storageItem, storageItemContent);
            Debug.Log(storageItem);
            Debug.Log(storageItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();



            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var button = obj.GetComponent<Button>();

            itemName.text = item.itemName + " x" + item.count;
            itemIcon.sprite = item.icon;

            if (item.itemName == "Pistol" || item.itemName == "Shotgun" || item.itemName == "Riffle" || item.itemName == "Revolver")
            {
                itemName.text += " : ";
                itemName.text += item.ammo;
            }

            button.onClick.AddListener(() => SelectItem(obj, item));

            Debug.Log("storage: " + item.itemName);
        }
    }

    public void SelectItem(GameObject selected, Item item)
    {
        if (!isCombining)
        {
            // Deselect the previously selected item
            if (selectedObject != null)
            {
                selectedObject.transform.localScale = Vector3.one;
            }
            // Scale the selected item
            selected.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

            // Store the selected object for future reference
            selectedObject = selected;
            selectedItem = item;

            Debug.Log("Selected item: " + item.itemName);
        }
        else
        {
            selected.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            combineObject = selected;
            combineItem = item;

            if (selectedItem.itemType == Item.ItemType.Herb)
            {

                if (selectedItem.itemName == "Green Herb" && combineItem.itemName == "Green Herb")
                {
                    Debug.Log("Combined Green Herb with Green Herb");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    Item newItem = new Item { itemName = "Emerald Green Mix", itemType = Item.ItemType.Mixture };
                    newItem.icon = greenMixIcon;
                    newItem.count = 1;
                    newItem.buyPrice = 0;
                    newItem.sellPrice = 30;
                    Items.Add(newItem);
                    ListItems();
                }
                else if (selectedItem.itemName == "Red Herb" && combineItem.itemName == "Red Herb")
                {
                    Debug.Log("Combined Red Herb with Red Herb");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    Item newItem = new Item { itemName = "Scarlet Red Mix", itemType = Item.ItemType.Mixture };
                    newItem.icon = redMixIcon;
                    newItem.count = 1;
                    newItem.buyPrice = 0;
                    newItem.sellPrice = 10;
                    Items.Add(newItem);
                    ListItems();
                }
                else if (selectedItem.itemName == "Green Herb" && combineItem.itemName == "Red Herb")
                {
                    Debug.Log("Combined Green Herb with Red Herb");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    Item newItem = new Item { itemName = "Yellow Mix", itemType = Item.ItemType.Mixture };
                    newItem.icon = yellowMixIcon;
                    newItem.count = 1;
                    newItem.buyPrice = 0;
                    newItem.sellPrice = 20;
                    Items.Add(newItem);
                    ListItems();
                }
                else if (selectedItem.itemName == "Red Herb" && combineItem.itemName == "Green Herb")
                {
                    Debug.Log("Combined Red Herb with Green Herb");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    Item newItem = new Item { itemName = "Yellow Mix", itemType = Item.ItemType.Mixture };
                    newItem.icon = yellowMixIcon;
                    newItem.count = 1;
                    newItem.buyPrice = 0;
                    newItem.sellPrice = 20;
                    Items.Add(newItem);
                    ListItems();
                }
                else
                {
                    ErrorMessage.gameObject.SetActive(true);
                    selected.transform.localScale = Vector3.one;
                    combineItem = null;
                    combineObject = null;
                }

            }
            else if (selectedItem.itemType == Item.ItemType.Gunpowder)
            {
                if (selectedItem.itemName == "Normal Gunpowder" && combineItem.itemName == "Normal Gunpowder")
                {
                    Debug.Log("Combined Normal Gunpowder with Normal Gunpowder");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    Item newItem = new Item { itemName = "pistol Ammo", itemType = Item.ItemType.Ammo };

                    newItem.icon = pistolAmmo;
                    newItem.count = 1;
                    newItem.buyPrice = 30;
                    newItem.sellPrice = 0;
                    newItem.ammo = 12;

                    if (Items.Contains(newItem))
                    {
                        GetExistingItemAndUpdateAmmo(newItem);
                    }
                    else
                    {
                        Items.Add(newItem);
                    }

                    ListItems();
                }
                if (selectedItem.itemName == "Normal Gunpowder" && combineItem.itemName == "High-Grade Gunpowder")
                {
                    Debug.Log("Combined Normal Gunpowder with Normal Gunpowder");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    Item newItem = new Item { itemName = "shotgunAmmo", itemType = Item.ItemType.Ammo };

                    newItem.icon = shotgunAmmo;
                    newItem.count = 1;
                    newItem.buyPrice = 40;
                    newItem.sellPrice = 0;
                    newItem.ammo = 8;

                    if (Items.Contains(newItem))
                    {
                        GetExistingItemAndUpdateAmmo(newItem);
                    }
                    else
                    {
                        Items.Add(newItem);
                    }

                    ListItems();
                }
                if (selectedItem.itemName == "High-Grade Gunpowder" && combineItem.itemName == "High-Grade Gunpowder")
                {
                    Debug.Log("Combined Normal Gunpowder with Normal Gunpowder");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    Item newItem = new Item { itemName = "riffleAmmo", itemType = Item.ItemType.Ammo };
                    newItem.icon = riffleAmmo;
                    newItem.count = 1;
                    newItem.buyPrice = 50;
                    newItem.sellPrice = 0;
                    newItem.ammo = 30;
                    if (Items.Contains(newItem))
                    {
                        GetExistingItemAndUpdateAmmo(newItem);
                    }
                    else
                    {
                        Items.Add(newItem);
                    }
                    ListItems();
                }
            }
            else
            {
                ErrorMessage.gameObject.SetActive(true);
                selected.transform.localScale = Vector3.one;
                combineItem = null;
                combineObject = null;
            }
            isCombining = false;
        }
    }
    //==========================================================================

    public Item GetExistingItemAndUpdateAmmo(Item newItem)
    {
        // Check if an item with the same properties already exists in the list
        Item existingItem = Items.Find(item => item.Equals(newItem));

        if (existingItem != null)
        {
            // Item already exists, update its properties (e.g., ammo)
            existingItem.ammo += newItem.ammo; // Adjust as needed
        }
        ListItems();
        return existingItem;
    }
    //==============================================================================

    public Item GetExistingItemAndUpdateCount(Item newItem)
    {
        // Check if an item with the same properties already exists in the list
        Item existingItem = Items.Find(item => item.Equals(newItem));

        if (existingItem != null)
        {
            // Item already exists, update its properties (e.g., ammo)
            Debug.Log("Count before " + existingItem.count);

            existingItem.count += 1; // Adjust as needed
            //Debug.Log(existingItem.itemName);
            Debug.Log("count after " + existingItem.count);
        }
        ListItems();
        return existingItem;
    }
    public void MoveToStorage()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType == Item.ItemType.Weapon && selectedItem.itemName == "pisol")
            {
                ErrorMessage.gameObject.SetActive(true);
            }
            else
            {
                Items.Remove(selectedItem);
                storageItems.Add(selectedItem);
                selectedItem = null;
                selectedObject = null;
                ListItems();
                storageListItems();
            }
        }

    }

    public void MoveToInventory()
    {
        if (Items.Count > 6)
        {
            ErrorMessage.gameObject.SetActive(true);
        }
        else
        {
            InventoryManager.Instance.Add(selectedItem);

        }

    }

}
