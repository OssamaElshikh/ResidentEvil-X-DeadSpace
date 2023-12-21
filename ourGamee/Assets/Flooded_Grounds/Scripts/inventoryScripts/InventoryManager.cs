using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;

    public Image ErrorMessage;
    public GameObject Health;
    public GameObject Stasis;
    public GameObject Gold;
    public GameObject Weapon;
    public GameObject Knife;
    public GameObject Grenade;

    public Sprite greenMixIcon;
    public Sprite redMixIcon;
    public Sprite yellowMixIcon;

    public Sprite pistolAmmo;
    public Sprite shotgunAmmo;
    public Sprite riffleAmmo;

    private GameObject selectedObject;
    private Item selectedItem;

    private bool isCombining = false;
    private GameObject combineObject;
    private Item combineItem;

    //private bool isInventoryOpen = false;

    //public void OnInventoryButtonClick()
    //{
    //    ToggleInventory();
    //}

    //void ToggleInventory()
    //{
    //    isInventoryOpen = !isInventoryOpen;

    //    if (isInventoryOpen)
    //    {
    //        // Pause the game
    //        Time.timeScale = 0f;
    //        // Show the inventory panel
           
    //    }
    //    else
    //    {
    //        // Unpause the game
    //        Time.timeScale = 1f;
    //        // Hide the inventory panel
      
    //    }
    //}

    private void Awake()
    {
        Instance = this;
    }



    public void Add(Item item)
    {
        if (Items.Count < 6)
        {
            item.ItemsCount = Items.Count;
            Debug.Log(item.ItemsCount);

            if (Items.Contains(item))
            {
                GetExistingItemAndUpdateCount(item);
            }
            else
            {
                Items.Add(item);
            }


        }
        else
        {
            item.ItemsCount = Items.Count+1;
            //Debug.Log(item.count);
            ErrorMessage.gameObject.SetActive(true);
        }
    }

    public void Remove()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType == Item.ItemType.Weapon || selectedItem.itemType == Item.ItemType.Grenade || selectedItem.itemType == Item.ItemType.KeyItem)
            {
                ErrorMessage.gameObject.SetActive(true);
            }
            else
            {
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                ListItems();
            }
        }
    }

    public void Equip()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType != Item.ItemType.Weapon && selectedItem.itemType != Item.ItemType.Grenade)
            {
                ErrorMessage.gameObject.SetActive(true);
            }
            else if (selectedItem.itemType == Item.ItemType.Weapon)
            {
                Debug.Log("Equipped weapon: " + selectedItem.itemName);
                Text weaponText = Weapon.GetComponentInChildren<Text>();
                weaponText.text = selectedItem.itemName;
            }
            else if (selectedItem.itemType == Item.ItemType.Grenade)
            {
                Debug.Log("Equipped grenade: " + selectedItem.itemName);
                Text grenadeText = Grenade.GetComponentInChildren<Text>();
                grenadeText.text = selectedItem.itemName;
            }
        }
    }

    public void Use()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType != Item.ItemType.Herb && selectedItem.itemType != Item.ItemType.Mixture)
            {
                ErrorMessage.gameObject.SetActive(true);
            }
            else if (selectedItem.itemName == "Green Herb")
            {
                Text healthText = Health.GetComponentInChildren<Text>();
                string healthString = healthText.text.ToString();
                string[] healthSplit = healthString.Split(' ');
                int newHealth = int.Parse(healthSplit[1]) + 2;
                healthText.text = "Health: " + newHealth.ToString();
                Remove();
            }
            else if (selectedItem.itemName == "Red Herb")
            {
                Text stasisText = Stasis.GetComponentInChildren<Text>();
                string stasisString = stasisText.text.ToString();
                string[] stasisSplit = stasisString.Split(' ');
                int newStasis = int.Parse(stasisSplit[1]) + 2;
                stasisText.text = "Stasis: " + newStasis.ToString();
                Remove();
            }
            else if (selectedItem.itemName == "Emerald Green Mix")
            {
                Text healthText = Health.GetComponentInChildren<Text>();
                string healthString = healthText.text.ToString();
                string[] healthSplit = healthString.Split(' ');
                int newHealth = int.Parse(healthSplit[1]) + 6;
                healthText.text = "Health: " + newHealth.ToString();
                Remove();
            }
            else if (selectedItem.itemName == "Scarlet Red Mix")
            {
                Text stasisText = Stasis.GetComponentInChildren<Text>();
                string stasisString = stasisText.text.ToString();
                string[] stasisSplit = stasisString.Split(' ');
                int newStasis = int.Parse(stasisSplit[1]) + 6;
                stasisText.text = "Stasis: " + newStasis.ToString();
                Remove();
            }
            else if (selectedItem.itemName == "Yellow Mix")
            {
                Text healthText = Health.GetComponentInChildren<Text>();
                string healthString = healthText.text.ToString();
                string[] healthSplit = healthString.Split(' ');
                int newHealth = int.Parse(healthSplit[1]) + 8;
                healthText.text = "Health: " + newHealth.ToString();
                Remove();
            }
        }
    }

    public void Combine()
    {
        isCombining = true;
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
            
            if (item.itemName == "Pistol" || item.itemName == "Shotgun"  || item.itemName == "Riffle" || item.itemName == "Revolver")
            {
                itemName.text += " : ";
                itemName.text += item.ammo;
            }
            button.onClick.AddListener(() => SelectItem(obj, item));
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

    public Item GetExistingItemAndUpdateAmmo(Item newItem)
    {
        // Check if an item with the same properties already exists in the list
        Item existingItem = Items.Find(item => item.Equals(newItem));

        if (existingItem != null)
        {
            // Item already exists, update its properties (e.g., ammo)
            existingItem.ammo += newItem.ammo; // Adjust as needed
        }

        return existingItem;
    }
    public Item GetExistingItemAndUpdateCount(Item newItem)
    {
        // Check if an item with the same properties already exists in the list
        Item existingItem = Items.Find(item => item.Equals(newItem));

        if (existingItem != null)
        {
            // Item already exists, update its properties (e.g., ammo)
            Debug.Log("Count before "+existingItem.count);

            existingItem.count += 1; // Adjust as needed
            Debug.Log(existingItem.itemName);
            Debug.Log("count after "+existingItem.count); 
        }

        return existingItem;
    }

}
