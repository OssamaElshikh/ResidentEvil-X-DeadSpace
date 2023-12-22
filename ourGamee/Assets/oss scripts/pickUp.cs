using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    public bool candestroy = false;
    public int goldcount = 30;
    public bool hasRevCard = false;
    public bool hasSpadeKey = false;
    public bool hasDiamondKey = false;
    public bool hasRevolver = false;


    //door animators:
    public Animator revD;
    public Animator normalDoorA;
    public Animator spadeDoorA;
    public Animator diamondDoorA;

    public GameObject revolver;
    public bool bool1 = true;

    public GameObject revCard;
    public bool bool16;

    public GameObject revDoor;
    public bool bool17;

    public GameObject spadeKey;
    public bool bool18;

    public GameObject spadeDoor;
    public bool bool19;

    public GameObject diamondKey;
    public bool bool20;

    public GameObject diamondDoor;
    public bool bool21;

    public GameObject normalDoor;
    public bool bool22;

    public bool InventoryGold=false;

    private GameObject currentObject;
    private GameObject currentDoor;

    public GameObject doorUI;
    public GameObject ui;

   
    //public Item item;

    private void Update()
    {
        
        candestroy = false;
        ui.SetActive(false);
        doorUI.SetActive(false);

        // check the nearest object to pickup

        if (bool1 == true && Vector3.Distance(transform.position, revolver.transform.position)<2  )
        {
            ui.SetActive(true);
            currentObject = revolver;
            candestroy = true;
            
        }
       
        if (bool16 == true && Vector3.Distance(transform.position, revCard.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = revCard;
            candestroy = true;

        }
        if (bool17 == true && Vector3.Distance(transform.position, revDoor.transform.position) < 2)
        {
            doorUI.SetActive(true);
            currentDoor = revDoor;
        }
        if (bool18 == true && Vector3.Distance(transform.position, spadeKey.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = spadeKey;
            candestroy = true;

        }

        if (bool20 == true && Vector3.Distance(transform.position, diamondKey.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = diamondKey;
            candestroy = true;

        }

        if (bool19 == true && Vector3.Distance(transform.position, spadeDoor.transform.position) < 2)
        {
            doorUI.SetActive(true);
            currentDoor = spadeDoor;
        }
        if (bool21 == true && Vector3.Distance(transform.position, diamondDoor.transform.position) < 2)
        {
            doorUI.SetActive(true);
            currentDoor = diamondDoor;
        }
        if (bool22 == true && Vector3.Distance(transform.position, normalDoor.transform.position) < 2)
        {
            doorUI.SetActive(true);
            currentDoor = normalDoor;
        }


        //for opening doors
        if (Input.GetKeyDown(KeyCode.O))
        { 
                OpenDoor();
        }


        //for picking up items
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (candestroy == true)
            {
                ui.SetActive(false);
                PickUPs();

            }
        }


    }

    public void PickUPs()
    {
       
        if (currentObject == revolver) { bool1 = false; hasRevolver = true;}

        if (currentObject == revCard) { bool16 = false; hasRevCard = true; }
        if (currentObject == spadeKey) { bool18 = false; hasSpadeKey = true; Debug.Log(hasSpadeKey); }

        if (currentObject == diamondKey) { bool20 = false; hasDiamondKey = true; }

        //InventoryManager.Instance.Add(item);

        //Debug.Log("item count " + item.count);
        //if (item.ItemsCount < 6)
        //{
        //    Destroy(currentObject);
        //    candestroy = false;
        //}

        Destroy(currentObject);
        candestroy = false;

    }

    public void OpenDoor()
    {
        //GameObject myGameObject = GameObject.Find("Inventorymanager");

        //InventoryManager myScript = myGameObject.GetComponent<InventoryManager>();


        if (currentDoor == revDoor && hasRevCard==true)
        {
            bool17 = false;
            revD.SetTrigger("revdoor");
        }
        if (currentDoor == spadeDoor && hasSpadeKey == true)
        {
            Debug.Log("hi");
            bool19 = false;
            spadeDoorA.SetTrigger("openDoor");
        }
        if (currentDoor == diamondDoor && hasDiamondKey == true)
        {
            bool21 = false;
            diamondDoorA.SetTrigger("openDoor");
            //myScript.UseInventoryItem("Key Diamond"); 
        }
        if (currentDoor == normalDoor) {
            bool22 = false;
            normalDoorA.SetTrigger("openDoor");
        }



    }
 
}
