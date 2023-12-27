using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    float pickupDistance = 2f;

    public AudioSource pickAudio;

    public GameObject canv;
    private void Update()
    {
        if (IsPlayerInRange())
        {
            
            canv.SetActive(true);
            Invoke("Dis", 3);
        }
      
       
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
            pickAudio.Play();
        }
        canv.SetActive(false);
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
    void Dis()
    {
        canv.SetActive(false);
    }

}