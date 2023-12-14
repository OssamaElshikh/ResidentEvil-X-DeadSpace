using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    public bool candestroy = false;
    public int goldcount = 30;
    public bool hasRevCard = false;

    //door animators:
    public Animator revD;

    //public GameObject rifle;
    //public bool rifleFlag=true;
    public GameObject ammo00;
    public bool bool1 = true;
    public GameObject ammo01;
    public bool bool2 = true;
    public GameObject ammo10;
    public bool bool3 = true;
    public GameObject ammo11;
    public bool bool4 = true;
    public GameObject ammo20;
    public bool bool5 = true;
    public GameObject ammo21;
    public bool bool6 = true;
    public GameObject gunpowder1;
    public bool bool7 = true;
    public GameObject gunpowder2;
    public bool bool8 = true;
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




    private GameObject currentObject;
    private GameObject currentDoor;

    public GameObject doorUI;
    public GameObject ui;
  
    private void Update()
    {
        Debug.Log("hi" + bool11);
        candestroy = false;
        ui.SetActive(false);
        doorUI.SetActive(false);

        // check the nearest object to pickup

        if (bool1 == true && Vector3.Distance(transform.position, ammo00.transform.position)<2  )
        {
            ui.SetActive(true);
            currentObject = ammo00;
            candestroy = true;
            
        }
         if (bool2 == true && Vector3.Distance(transform.position, ammo01.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = ammo01;
            candestroy = true;
            
        }
         if (bool3 == true && Vector3.Distance(transform.position, ammo10.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = ammo10;
            candestroy = true;
            
        }
         if (bool4 == true && Vector3.Distance(transform.position, ammo11.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = ammo11;
            candestroy = true;
            
        }
         if (bool5 == true && Vector3.Distance(transform.position, ammo20.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = ammo20;
            candestroy = true;
            
        }
        //if (rifleFlag == true && Vector3.Distance(transform.position, rifle.transform.position) < 2)
        //{
        //    ui.SetActive(true);
        //    currentObject = rifle;
        //    candestroy = true;

        //}
        if (bool6 == true && Vector3.Distance(transform.position, ammo21.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = ammo21;
            candestroy = true;

        }
        if (bool7 == true && Vector3.Distance(transform.position, gunpowder1.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gunpowder1;
            candestroy = true;

        }
        if (bool8 == true && Vector3.Distance(transform.position, gunpowder2.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = gunpowder2;
            candestroy = true;

        }
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

        //for opening doors
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (hasRevCard == true)
            {
                OpenDoor();
            }
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
        //if (currentObject == rifle) { rifleFlag =false; }
        if (currentObject == ammo00) { bool1 = false; }
        if (currentObject == ammo01) { bool2 = false; }
        if (currentObject == ammo10) { bool3 = false; }
        if (currentObject == ammo11) { bool4 = false; }
        if (currentObject == ammo20) { bool5 = false; }
        if (currentObject == ammo21) { bool6 = false; }
        if (currentObject == gunpowder1) { bool7 = false; }
        if (currentObject == gunpowder2) { bool8 = false; }
        if (currentObject == gold1) { bool9 = false; goldcount += 10; }
        if (currentObject == gold2) { bool10 = false; goldcount += 10; }
        if (currentObject == gold3) { bool11= false; goldcount += 10; }
        if (currentObject == gold4) { bool12= false; goldcount += 10; }
        if (currentObject == gold5) { bool13 = false; goldcount += 10; }
        if (currentObject == gold6) { bool14 = false; goldcount += 10; }
        if (currentObject == gold7) { bool15 = false; goldcount += 10; }
        if (currentObject == revCard) { bool16 = false; hasRevCard = true; }


        Destroy(currentObject);
        candestroy = false;
    }

    public void OpenDoor()
    {
        if (currentDoor == revDoor)
        {
            revD.SetTrigger("revdoor");
        }
    }
 
}
