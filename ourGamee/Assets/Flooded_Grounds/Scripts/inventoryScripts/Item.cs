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
    public int ItemsCount; 

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
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        // Compare items based on their unique properties (e.g., Name)
        return itemName == ((Item)obj).itemName;
    }

    public override int GetHashCode()
    {
        return itemName.GetHashCode();
    }
}
