using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int buyPrice;
    public int sellPrice;
    public int count;
    public Sprite icon;
    public ItemType itemType;
    public int ammo;
    public int ItemsCount;
    public bool sellable;
    




    public enum ItemType
    {
        Weapon,
        Ammo,
        Herb,
        Mixture,
        Grenade,
        KeyItem,
        Gunpowder,
        Treasure
    }

    public GameObject associatedGameObject;

    public void SetAssociatedGameObject(GameObject gameObject)
    {
        associatedGameObject = gameObject;
    }
    

    public Vector3 GetGameObjectPosition()
    {
        if (associatedGameObject != null)
        {
            return associatedGameObject.transform.position;
        }
        else
        {
            Debug.LogError("Associated GameObject not set for item: " + itemName);
            return Vector3.zero; // Or handle the case where the associated GameObject is not set
        }
    }
}