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

    //public GameObject rifle;
    //public bool rifleFlag=true;
    public GameObject revolver;
    public bool bool1 = true;
    //public GameObject ammo01;
    //public bool bool2 = true;
    //public GameObject ammo10;
    //public bool bool3 = true;
    //public GameObject ammo11;
    //public bool bool4 = true;
    //public GameObject ammo20;
    //public bool bool5 = true;
    //public GameObject ammo21;
    //public bool bool6 = true;
    //public GameObject gunpowder1;
    //public bool bool7 = true;
    //public GameObject gunpowder2;
    //public bool bool8 = true;
    public GameObject gold1, gold2, gold3, gold4, gold5, gold6,gold7;
    public bool  bool9=true;
    public bool bool10 = true;
    public bool bool11 = true;
    public bool bool12 = true;
    public bool bool13 = true;
    public bool bool14 = true;
    public bool bool15 = true;
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

    public Item item;

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
        // if (bool2 == true && Vector3.Distance(transform.position, ammo01.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = ammo01;
        //    candestroy = true;
            
        //}
        // if (bool3 == true && Vector3.Distance(transform.position, ammo10.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = ammo10;
        //    candestroy = true;
            
        //}
        // if (bool4 == true && Vector3.Distance(transform.position, ammo11.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = ammo11;
        //    candestroy = true;
            
        //}
        // if (bool5 == true && Vector3.Distance(transform.position, ammo20.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = ammo20;
        //    candestroy = true;
            
        //}
        //if (rifleFlag == true && Vector3.Distance(transform.position, rifle.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = rifle;
        //    candestroy = true;

        //}
        //if (bool6 == true && Vector3.Distance(transform.position, ammo21.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = ammo21;
        //    candestroy = true;

        //}
        //if (bool7 == true && Vector3.Distance(transform.position, gunpowder1.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = gunpowder1;
        //    candestroy = true;

        //}
        //if (bool8 == true && Vector3.Distance(transform.position, gunpowder2.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = gunpowder2;
        //    candestroy = true;

        //}
        if (bool9 == true && Vector3.Distance(transform.position, gold1.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gold1;
            candestroy = true;

        }
        if (bool10 == true && Vector3.Distance(transform.position, gold2.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gold2;
            candestroy = true;

        }
        if (bool11 == true && Vector3.Distance(transform.position, gold3.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gold3;
            candestroy = true;

        }
        if (bool12 == true && Vector3.Distance(transform.position, gold4.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gold4;
            candestroy = true;

        }
        if (bool13 == true && Vector3.Distance(transform.position, gold5.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gold5;
            candestroy = true;

        }
        if (bool14 == true && Vector3.Distance(transform.position, gold6.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gold6;
            candestroy = true;

        }
        if (bool15 == true && Vector3.Distance(transform.position, gold7.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gold7;
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
       
        if (currentObject == revolver) { bool1 = false; hasRevolver = true; item.itemName = "revolver"; item.itemType = Item.ItemType.Weapon;  }

        if (currentObject == gold1) {
            bool9 = false; goldcount += 10;
            InventoryGold = true; 
           
        }
        if (currentObject == gold2) { bool10 = false; goldcount += 10;  }
        if (currentObject == gold3) { bool11= false; goldcount += 10; }
        if (currentObject == gold4) { bool12= false; goldcount += 10; }
        if (currentObject == gold5) { bool13 = false; goldcount += 10; }
        if (currentObject == gold6) { bool14 = false; goldcount += 10; }
        if (currentObject == gold7) { bool15 = false; goldcount += 10; }
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
        }
        if (currentDoor == normalDoor) {
            bool22 = false;
            normalDoorA.SetTrigger("openDoor");
        }



    }
 
}
