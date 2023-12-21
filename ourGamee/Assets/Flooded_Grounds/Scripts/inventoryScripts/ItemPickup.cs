using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public pickUpScript pickUpScript;
    public Item item;

    public float pickupDistance = 2f;

    private void Update()
    {
        // Check if the player is within the pickup distance and presses the "E" key
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            Pickup();
        }
    }
    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Debug.Log("item count " + item.count);
        if (item.ItemsCount < 6)
        {
            Destroy(gameObject);
        }
    }
    bool IsPlayerInRange()
    {
        // Assuming the player is tagged as "Player." Adjust this based on your setup.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance < pickupDistance;
        }

        return false;
    }
    private void OnMouseDown()
    {
        Pickup();
    }


}
