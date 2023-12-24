using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public TextMeshProUGUI knifeGoldCoinsText;
    public TextMeshProUGUI KnifeDurabilityText;
    private firing fire; // Reference to the firing script


    public static InventoryManager Instance;
    public TextMeshProUGUI invKnifeDurabilityText;
    public TextMeshProUGUI buyGoldCoinsText; // Reference to the Text UI element displaying gold coins
    public TextMeshProUGUI invGoldCoinsText;

    private int goldCoins = 110;
    public TextMeshProUGUI DebugText; // Reference to the Text UI element displaying gold coins

    public List<Item> Items = new List<Item>();
    public List<Item> storageItems = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public Transform storageItemContent;
    public GameObject storageItem;

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
    public Sprite revolverAmmo;


    private GameObject selectedObject;
    private Item selectedItem;

    private bool isCombining = false;
    private GameObject combineObject;
    private Item combineItem;

    public GameObject inventoryCanvas;
    private bool isInventoryActive = false;

    private bool isPaused = false;
    private CursorLockMode previousLockMode; // To store the previous cursor lock mode


    public GameObject ui;


     

    private void Start()
    {
        fire = FindObjectOfType<firing>();

        if (fire != null)
        {
            UpdateKnifeDurabilityText();
            UpdateKnifeGoldCoinsText();
        }
        else
        {
            Debug.LogError("firing script component not found!");
        }

        UpdateKnifeGoldCoinsText();
        UpdateGoldCoinsInvText();
        UpdateGoldCoinsStoreText();
        UpdateInvKnifeDurabilityText();

    }

    void UpdateKnifeGoldCoinsText()
    {
        knifeGoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }

    public void UpdateKnifeDurabilityText()
    {
        if (fire != null)
        {
            KnifeDurabilityText.text = "Knife Durability: " + fire.KnifeDUR.ToString();
        }
    }
    public void UpdateInvKnifeDurabilityText()
    {
        if (fire != null)
        {
            invKnifeDurabilityText.text = "Knife Durability: " + fire.KnifeDUR.ToString();
        }
    }

    public void OnRepairButtonPressed()
    {
        if (fire != null)
        {
            if (goldCoins < 100)
            {
                // DebugTxt.text = ("Not Enough Coins.");
            }
            else if (fire.KnifeDUR == 10)
            {
                // DebugTxt.text = ("Durability is already Full.");
            }
            else
            {
                goldCoins -= 100;
                fire.KnifeDUR = 10;
                UpdateKnifeDurabilityText();
                UpdateInvKnifeDurabilityText();
                UpdateKnifeGoldCoinsText();
                UpdateGoldCoinsInvText() ;
                UpdateGoldCoinsStoreText();
                // DebugTxt.text = "Durability charged";
            }
        }
        else
        {
            Debug.LogError("firing script component not found!");
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    //==============================================================================

    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.H))
        {
            PauseGame();
            ActivateInventory();
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.H))
        {
            ResumeGame();
            DeactivateInventory();
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
    //==============================================================================


    public void UpdateGoldCoinsStoreText()
    {
        buyGoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }

    public void UpdateGoldCoinsInvText()
    {
        invGoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }



    





    public void OnPurchaseButtonClicked(int itemCost)
    {
        if (goldCoins >= itemCost)
        {

            goldCoins -= itemCost;
            UpdateKnifeGoldCoinsText();
            UpdateGoldCoinsInvText();
            UpdateGoldCoinsStoreText();
            DebugText.text = "Purchase successful!";

        }
        else
        {
            DebugText.text = "Not enough gold coins!";

        }
    }

    public void DeactivateInventory()
    {


        // Toggle the inventory canvas state


        // Set the Inventory Canvas based on the state
        inventoryCanvas.SetActive(false);



    }
    public void ActivateInventory()
    {
        
        
            // Toggle the inventory canvas state
            

            // Set the Inventory Canvas based on the state
            inventoryCanvas.SetActive(true);

        

    }
    //==============================================================================
    public void Add(Item item)
    {
        if (Items.Count < 6 )
        {
            
            //Debug.Log("items count " + item.ItemsCount);

            if (item.itemName=="shotgunAmmo"|| item.itemName == "riffleAmmo"|| item.itemName == "pistolAmmo" || item.itemName == "revolverAmmo")
            {
                GetExistingItemAndUpdateCount(item);
            }
            else
            {
                Items.Add(item);
            }
            ListItems();
        }
        else
        {
            ErrorMessage.gameObject.SetActive(true);
        }
    }

    public void MoveToStorage()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType == Item.ItemType.Weapon && selectedItem.itemName== "pisol")
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
            Add(selectedItem);

        }
       
    }

    //==============================================================================

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
    //==============================================================================

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
            }
        }
    }
    //==============================================================================
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

    //==============================================================================

    public void Combine()
    {
        isCombining = true;
    }

    //==============================================================================
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

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(storageItem, storageItemContent);

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
    //==============================================================================
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

    //==============================================================================

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

        return existingItem;
    }

    //==============================================================================

    public void UseInventoryItem(string itemName)
    {
        // Find the item in the inventory based on its name
        Item item = Items.Find(i => i.itemName == itemName);

        if (item != null)
        {
            // If the item count is more than 1, decrease the count
            if (item.count > 1)
            {
                item.count--;
            }
            else
            {
                // If the item count is 1 or less, remove the item from the inventory
                Items.Remove(item);
            }

            // Update the inventory UI
            ListItems();

            Debug.Log("Used 1 " + itemName);
        }
        else
        {
            Debug.LogWarning("Item not found in inventory: " + itemName);
        }
    }

}