using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Item/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int buyPrice;
    public int sellPrice;
    public int count;
    public int ammo;
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Ammo,
        Herb,
        Mixture,
        Grenade,
        KeyItem,
        Treasure,
        Gunpowder
    }
}
