using UnityEngine;

[System.Serializable]
public class SellStoreItem
{
    public string SellStoreitemName; // Renamed from 'itemName' to 'itemNameString'
    public Sprite SellStoreitemIcon;
    public int SellStoresellPrice;

    public SellStoreItem(string name, Sprite icon, int price)
    {
        SellStoreitemName = name; // Updated reference to the renamed variable
        SellStoreitemIcon = icon;
        SellStoresellPrice = price;
    }
}
