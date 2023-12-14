using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int ammo0, ammo1, ammo2 = 0;
    public bool candestroy = false;

    public GameObject rifle;
    public bool rifleFlag=true;
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



    private GameObject currentObject;

    public GameObject ui;
    private void Update()
    {
        candestroy = false;
        ui.SetActive(false);

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
        if (rifleFlag == true && Vector3.Distance(transform.position, rifle.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = rifle;
            candestroy = true;

        }
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
        //else
        //{
        //    ui.SetActive(false);
        //    candestroy = false;
        //}
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
        if (currentObject == rifle) { rifleFlag =false; }
        if (currentObject == ammo00) { bool1 = false; }
        if (currentObject == ammo01) { bool2 = false; }
        if (currentObject == ammo10) { bool3 = false; }
        if (currentObject == ammo11) { bool4 = false; }
        if (currentObject == ammo20) { bool5 = false; }
        if (currentObject == ammo21) { bool6 = false; }
        if (currentObject == gunpowder1) { bool7 = false; }
        if (currentObject == gunpowder2) { bool8 = false; }

        Destroy(currentObject);
        candestroy = false;
    }
 
}
