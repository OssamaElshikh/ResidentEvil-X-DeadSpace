using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public TextMeshProUGUI knifeGoldCoinsText;
    public TextMeshProUGUI KnifeDurabilityText;
    
    private firing fire;
    private enemyDamage enemydamage;// Reference to the firing script


    public static InventoryManager Instance;
    public TextMeshProUGUI invKnifeDurabilityText;
    public TextMeshProUGUI buyGoldCoinsText; // Reference to the Text UI element displaying gold coins
    public TextMeshProUGUI invGoldCoinsText;
    public TextMeshProUGUI StorageGoldCoinsText;
    public TextMeshProUGUI invStorageGoldCoinsText;
    public TextMeshProUGUI sellGoldCoinsText;

    public bool weapon1Equiped = true;
    public bool weapon2Equiped;
    public bool weapon3Equiped;
    public bool weapon4Equiped;
    public bool weapon5Equiped;

    
    public int goldCoins = 30;
    public TextMeshProUGUI DebugText; // Reference to the Text UI element displaying gold coins

    public List<Item> Items = new List<Item>();
    public List<Item> storageItems = new List<Item>();
    public List<Item> sellItems = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Transform storageItemContent;
    public Transform sellItemContent;
    public GameObject storageItem;
    public GameObject sellItem;

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

    public bool haveGrenade;
    public bool haveFlashGrenade;


    public GameObject ui;

    public Item Pist;
    public Item YellowMix;
    public Item RRMix;
    public Item GGmix;
    public Item PistAmmo;
    public Item shotAmmo;
    public Item riffAmmo;
    public bool purchasable;




    private void Start()
    {
        Add(Pist);
        enemydamage = FindObjectOfType<enemyDamage>();

        if (enemydamage != null)
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
        UpdateStotageGoldCoinsText();
        UpdateInvStotageGoldCoinsText();
        UpdatesellGoldCoinsTxt();

    }

    public void UpdatesellGoldCoinsTxt()
    {
        sellGoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }

    public void UpdateStotageGoldCoinsText()
    {
        StorageGoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }
    public void UpdateInvStotageGoldCoinsText()
    {
        invStorageGoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }


    public void UpdateKnifeGoldCoinsText()
    {
        knifeGoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }

    public void UpdateKnifeDurabilityText()
    {
        if (enemydamage != null)
        {
            KnifeDurabilityText.text = "Knife Durability: " + enemydamage.knifeDurability.ToString();
        }
    }
    public void UpdateInvKnifeDurabilityText()
    {
        if (enemydamage != null)
        {
            invKnifeDurabilityText.text = "Knife Durability: " + enemydamage.knifeDurability.ToString();
        }
    }

    public void OnRepairButtonPressed()
    {
        if (enemydamage != null)

        {
            if (goldCoins < 100)
            {
                // DebugTxt.text = ("Not Enough Coins.");
            }
            else if (enemydamage.knifeDurability == 10)
            {
                // DebugTxt.text = ("Durability is already Full.");
            }
            else
            {
                goldCoins -= 100;
                enemydamage.knifeDurability = 10;
                UpdateKnifeDurabilityText();
                UpdateInvKnifeDurabilityText();
                UpdateKnifeGoldCoinsText();
                UpdateGoldCoinsInvText();
                UpdateGoldCoinsStoreText();
                UpdateStotageGoldCoinsText();
                UpdateInvStotageGoldCoinsText();
                UpdatesellGoldCoinsTxt();
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
        if (goldCoins >= itemCost && Items.Count<6)
        {
            purchasable = true;
            goldCoins -= itemCost;
            UpdateKnifeGoldCoinsText();
            UpdateGoldCoinsInvText();
            UpdateGoldCoinsStoreText();
            UpdateStotageGoldCoinsText();
            UpdateInvStotageGoldCoinsText();
            UpdatesellGoldCoinsTxt();

            DebugText.text = "Purchase successful!";
            Debug.Log("purchased!!");
        }
        else
        {
            purchasable = false;
            DebugText.text = "Not enough gold coins! \\ no space";
            Debug.Log("not enough coins !!");

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
    public bool Add(Item item)
    {
        if (Items.Count < 6)
        {

            //Debug.Log("items count " + item.ItemsCount);

            if (item.itemName == "shotgunAmmo" || item.itemName == "riffleAmmo" || item.itemName == "pistolAmmo" || item.itemName == "revolverAmmo")
            {
                GetExistingItemAndUpdateCount(item);


            }

            else if (item.itemName == "Shotgun" && item.ammo < 8)
            {
                item.ammo = 8;
                Items.Add(item);
                sellItems.Add(item);
            }
            else if (item.itemName == "Riffle" && item.ammo < 30)
            {
                item.ammo = 30;
                Items.Add(item);
                sellItems.Add(item);
            }
            else if (item.itemName == "Pistol" && item.ammo < 12)
            {
                item.ammo = 12;
                Items.Add(item);
                sellItems.Add(item);
            }
            else if (item.itemName == "Revolver" && item.ammo < 6)
            {
                item.ammo = 6;
                Items.Add(item);
                sellItems.Add(item);
            }

            else
            {
                Items.Add(item);
                sellItems.Add(item);
                Debug.Log("added to sellitems" + item.name);
            }
            ListItems();
            listSellItems();
            return true;
            //storageListItems(); 
        }
        else
        {

            ErrorMessage.gameObject.SetActive(true);
            return false;
        }
    }

    public void MoveToStorage()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType == Item.ItemType.Weapon && selectedItem.itemName == "pistol")
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
                //storageListItems();
            }
        }

    }

    public void MoveToInventory()
    {
        if (Items.Count >= 6)
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

    public void sell()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemName == "Green Herb")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "Red Herb")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();

            }
            else if (selectedItem.itemName == "Hand Grenade ")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "Flash Grenade")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "Normal Gunpowder")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "High-Grade Gunpowder")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "G+GMixture")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();

            }
            else if (selectedItem.itemName == "G+RMixture")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "R+RMixture")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "gold")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "emerald")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            else if (selectedItem.itemName == "ruby")
            {
                goldCoins += selectedItem.sellPrice;
                sellItems.Remove(selectedItem);
                Items.Remove(selectedItem);
                selectedItem = null;
                selectedObject = null;
                listSellItems();
                ListItems();
            }
            UpdateKnifeGoldCoinsText();
            UpdateGoldCoinsInvText();
            UpdateGoldCoinsStoreText();
            UpdateStotageGoldCoinsText();
            UpdateInvStotageGoldCoinsText();
            UpdatesellGoldCoinsTxt();
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
                if (selectedItem.itemName == "Pistol")
                {
                    weapon1Equiped = true;
                    weapon2Equiped = false;
                    weapon3Equiped = false;
                    weapon4Equiped = false;
                }
                else if (selectedItem.itemName == "Shotgun")
                {
                    weapon1Equiped = false;
                    weapon2Equiped = true;
                    weapon3Equiped = false;
                    weapon4Equiped = false;
                }
                else if (selectedItem.itemName == "Riffle")
                {
                    weapon1Equiped = false;
                    weapon2Equiped = false;
                    weapon3Equiped = true;
                    weapon4Equiped = false;
                }
                else if (selectedItem.itemName == "Revolver")
                {
                    weapon1Equiped = false;
                    weapon2Equiped = false;
                    weapon3Equiped = false;
                    weapon4Equiped = true;
                }
            }
            else if (selectedItem.itemType == Item.ItemType.Grenade)
            {
                if (selectedItem.itemName == "Hand Grenade ")
                {
                    haveGrenade = true;
                    haveFlashGrenade = false;

                }
                else
                {
                    haveGrenade = false;
                    haveFlashGrenade = true;
                }
                    Debug.Log("Equipped grenade: " + selectedItem.itemName);
                Text grenadeText = Grenade.GetComponentInChildren<Text>();
                grenadeText.text = selectedItem.itemName;
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
                sellItems.Remove(selectedItem);
                listSellItems();
                Remove();
                
            }
            else if (selectedItem.itemName == "Red Herb")
            {
                Text stasisText = Stasis.GetComponentInChildren<Text>();
                string stasisString = stasisText.text.ToString();
                string[] stasisSplit = stasisString.Split(' ');
                int newStasis = int.Parse(stasisSplit[1]) + 2;
                stasisText.text = "Stasis: " + newStasis.ToString();
                sellItems.Remove(selectedItem);
                listSellItems();
                Remove();
                
            }
            else if (selectedItem.itemName == "G+GMixture")
            {
                Text healthText = Health.GetComponentInChildren<Text>();
                string healthString = healthText.text.ToString();
                string[] healthSplit = healthString.Split(' ');
                int newHealth = int.Parse(healthSplit[1]) + 6;
                healthText.text = "Health: " + newHealth.ToString();
                sellItems.Remove(selectedItem);
                listSellItems();
                Remove();
                
            }
            else if (selectedItem.itemName == "R+RMixture")
            {
                Text stasisText = Stasis.GetComponentInChildren<Text>();
                string stasisString = stasisText.text.ToString();
                string[] stasisSplit = stasisString.Split(' ');
                int newStasis = int.Parse(stasisSplit[1]) + 6;
                stasisText.text = "Stasis: " + newStasis.ToString();
                sellItems.Remove(selectedItem);
                listSellItems();
                Remove();
                

            }
            else if (selectedItem.itemName == "G+RMixture")
            {
                Text healthText = Health.GetComponentInChildren<Text>();
                string healthString = healthText.text.ToString();
                string[] healthSplit = healthString.Split(' ');
                int newHealth = int.Parse(healthSplit[1]) + 8;
                healthText.text = "Health: " + newHealth.ToString();
                sellItems.Remove(selectedItem);
                listSellItems();
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
            Debug.Log("item destroyed");
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();



            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var button = obj.GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if (item.itemName == "Pistol" || item.itemName == "Shotgun" || item.itemName == "Riffle" || item.itemName == "Revolver")
            {
                itemName.text += " : ";
                itemName.text += item.ammo;
            }
            else if (item.itemType == Item.ItemType.Ammo)
            {
                itemName.text += " : ";
                itemName.text += item.ammo;
            }
            button.onClick.AddListener(() => SelectItem(obj, item));
        }

    }

    public void listSellItems()
    {
        foreach (Transform item in sellItemContent)
        {
            Destroy(item.gameObject);
            Debug.Log("sell item destroyed");
        }

        foreach (var sellitem in sellItems)
        {
            if (sellitem.sellable == true)
            {


                GameObject obj = Instantiate(sellItem, sellItemContent);

                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();



                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                var button = obj.GetComponent<Button>();


                itemName.text = sellitem.itemName + " x" + sellitem.count;
                itemIcon.sprite = sellitem.icon;
                Debug.Log("sellable == true");

                if (sellitem.itemName == "Pistol" || sellitem.itemName == "Shotgun" || sellitem.itemName == "Riffle" || sellitem.itemName == "Revolver")
                {
                    itemName.text += " : ";
                    itemName.text += sellitem.ammo;
                }
                button.onClick.AddListener(() => SelectItem(obj, sellitem));
            }
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
            Debug.Log("Scaled: " + item.itemName);
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
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    
                    Items.Add(GGmix);
                    sellItems.Add(GGmix); 
                    ListItems();
                    listSellItems();
                }
                else if (selectedItem.itemName == "Red Herb" && combineItem.itemName == "Red Herb")
                {
                    Debug.Log("Combined Red Herb with Red Herb");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    
                    Items.Add(RRMix);
                    sellItems.Add(RRMix);
                    ListItems();
                    listSellItems();
                }
                else if (selectedItem.itemName == "Green Herb" && combineItem.itemName == "Red Herb")
                {
                    Debug.Log("Combined Green Herb with Red Herb");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    
                    Items.Add(YellowMix);
                    sellItems.Add(YellowMix);
                    ListItems();
                    listSellItems();
                }
                else if (selectedItem.itemName == "Red Herb" && combineItem.itemName == "Green Herb")
                {
                    Debug.Log("Combined Red Herb with Green Herb");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    Item newItem = new Item { itemName = "Yellow Mix", itemType = Item.ItemType.Mixture };
                    newItem.icon = yellowMixIcon;
                    newItem.count = 1;
                    newItem.buyPrice = 0;
                    newItem.sellPrice = 20;
                    Items.Add(YellowMix);
                    sellItems.Add(YellowMix);
                    ListItems();
                    listSellItems();
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
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    listSellItems();
                    Item newItem = new Item { itemName = "pistolAmmo", itemType = Item.ItemType.Ammo };

                    newItem.icon = pistolAmmo;
                    newItem.count = 1;
                    newItem.buyPrice = 30;
                    newItem.sellPrice = 0;
                    newItem.ammo = 12;



                    bool itemExists = false;

                    // Check if an item with the same itemName exists in the list
                    foreach (Item existingItem in Items)
                    {
                        if (existingItem.itemName == newItem.itemName)
                        {
                            itemExists = true;
                            Debug.Log("Item exists in list");
                            GetExistingItemAndUpdateCount(existingItem);
                            break; // Exit the loop since we found a matching item
                        }
                    }

                    if (!itemExists)
                    {
                        Items.Add(newItem);
                    }

                    ListItems();
                }
                else if (selectedItem.itemName == "Normal Gunpowder" && combineItem.itemName == "High-Grade Gunpowder")
                {
                    Debug.Log("Combined Normal Gunpowder with Normal Gunpowder");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    listSellItems();
                    Item newItem = new Item { itemName = "shotgunAmmo", itemType = Item.ItemType.Ammo };

                    newItem.icon = shotgunAmmo;
                    newItem.count = 1;
                    newItem.buyPrice = 40;
                    newItem.sellPrice = 0;
                    newItem.ammo = 8;
                    bool itemExists = false;

                    // Check if an item with the same itemName exists in the list
                    foreach (Item existingItem in Items)
                    {
                        if (existingItem.itemName == newItem.itemName)
                        {
                            itemExists = true;
                            Debug.Log("Item exists in list");
                            GetExistingItemAndUpdateCount(existingItem);
                            break; // Exit the loop since we found a matching item
                        }
                    }

                    if (!itemExists)
                    {
                        Items.Add(newItem);
                    }

                    ListItems();
                }
                else if (selectedItem.itemName == "High-Grade Gunpowder" && combineItem.itemName == "Normal Gunpowder")
                {
                    Debug.Log("Combined Normal Gunpowder with Normal Gunpowder");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    listSellItems();
                    Item newItem = new Item { itemName = "shotgunAmmo", itemType = Item.ItemType.Ammo };

                    newItem.icon = shotgunAmmo;
                    newItem.count = 1;
                    newItem.buyPrice = 40;
                    newItem.sellPrice = 0;
                    newItem.ammo = 8;

                    bool itemExists = false;

                    // Check if an item with the same itemName exists in the list
                    foreach (Item existingItem in Items)
                    {
                        if (existingItem.itemName == newItem.itemName)
                        {
                            itemExists = true;
                            Debug.Log("Item exists in list");
                            GetExistingItemAndUpdateCount(existingItem);
                            break; // Exit the loop since we found a matching item
                        }
                    }

                    if (!itemExists)
                    {
                        Items.Add(newItem);
                    }

                    ListItems();
                }
                else if (selectedItem.itemName == "High-Grade Gunpowder" && combineItem.itemName == "High-Grade Gunpowder")
                {
                    Debug.Log("Combined Normal Gunpowder with Normal Gunpowder");
                    Items.Remove(selectedItem);
                    Items.Remove(combineItem);
                    sellItems.Remove(selectedItem);
                    sellItems.Remove(combineItem);
                    listSellItems();
                    Item newItem = new Item { itemName = "riffleAmmo", itemType = Item.ItemType.Ammo };
                    newItem.icon = riffleAmmo;
                    newItem.count = 1;
                    newItem.buyPrice = 50;
                    newItem.sellPrice = 0;
                    newItem.ammo = 30;
                    bool itemExists = false;

                    // Check if an item with the same itemName exists in the list
                    foreach (Item existingItem in Items)
                    {
                        if (existingItem.itemName == newItem.itemName)
                        {
                            itemExists = true;
                            Debug.Log("Item exists in list");
                            GetExistingItemAndUpdateCount(existingItem);
                            break; // Exit the loop since we found a matching item
                        }
                    }

                    if (!itemExists)
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
            if (existingItem.itemName == "shotgunAmmo")
            {
                existingItem.ammo += 8;
            }
            else if (existingItem.itemName == "riffleAmmo")
            {
                existingItem.ammo += 30;
            }
            else if (existingItem.itemName == "pistolAmmo")
            {
                existingItem.ammo += 12;
            }
            else if (existingItem.itemName == "revolverAmmo")
            {
                existingItem.ammo += 6;
            }

            Debug.Log("count after " + existingItem.count);
        }
        else
        {

            if (newItem.itemName == "shotgunAmmo" && newItem.ammo < 8)
            {
                newItem.ammo = 8;


            }
            if (newItem.itemName == "riffleAmmo" && newItem.ammo < 30)
            {
                newItem.ammo = 30;


            }
            if (newItem.itemName == "pistolAmmo" && newItem.ammo < 12)
            {
                newItem.ammo = 12;


            }
            Items.Add(newItem);
            Debug.Log("ammo added");

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