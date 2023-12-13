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

    public Image InvalidModal;
    public GameObject Health;
    public GameObject Stasis;
    public GameObject Gold;
    public GameObject Weapon;
    public GameObject Knife;
    public GameObject Grenade;

    public Sprite greenMixIcon;
    public Sprite redMixIcon;
    public Sprite yellowMixIcon;



    private GameObject selectedObject;
    private Item selectedItem;

    private bool isCombining = false;
    private GameObject combineObject;
    private Item combineItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        if (item.count < 6)
        {
            Items.Add(item);
        }
        else
        {
            InvalidModal.gameObject.SetActive(true);
        }
    }

    public void Remove()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType == Item.ItemType.Weapon || selectedItem.itemType == Item.ItemType.Grenade || selectedItem.itemType == Item.ItemType.KeyItem)
            {
                InvalidModal.gameObject.SetActive(true);
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
                InvalidModal.gameObject.SetActive(true);
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

    public void Use()
    {
        if (selectedItem != null && selectedObject != null)
        {
            if (selectedItem.itemType != Item.ItemType.Herb && selectedItem.itemType != Item.ItemType.Mixture)
            {
                InvalidModal.gameObject.SetActive(true);
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

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

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
                    InvalidModal.gameObject.SetActive(true);
                    selected.transform.localScale = Vector3.one;
                    combineItem = null;
                    combineObject = null;
                }

            }
            else
            {
                InvalidModal.gameObject.SetActive(true);
                selected.transform.localScale = Vector3.one;
                combineItem = null;
                combineObject = null;
            }
            isCombining = false;
        }
    }

}