using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pickUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerHealth = 8;
    private bool playerDead = false;

    public bool candestroy = false;
    public int goldcount = 30;
    public bool hasRevCard = false;
    public bool hasSpadeKey = false;
    public bool hasDiamondKey = false;
    public bool hasRevolver = false;
    public bool hasEmerald = false;
    public bool hasGreenHerb = false;
    public bool hasRedHerb = false;
    public bool hasGrenade = false;
    public bool hasFlashGrenade = false;
    public bool hasNormalGunpowder = false;
    public bool hasHeavyGunpoder = false;


    public TMPro.TMP_Text healthText;
    //door animators:
    public Animator playerAnim;
    public Animator revD;
    public Animator normalDoorA;
    public Animator spadeDoorA;
    public Animator diamondDoorA;
    public Animator emeraldDoorA;

    public AudioSource winAudio;
    public GameObject loseUi;

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
    /*     public GameObject gold1, gold2, gold3, gold4, gold5, gold6,gold7;
         public bool  bool9=true;
         public bool bool10 = true;
         public bool bool11 = true;
         public bool bool12 = true;
         public bool bool13 = true;
         public bool bool14 = true;
         public bool bool15 = true;
    */
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
    public GameObject emerald;
    public bool bool23;
    public GameObject emeraldDoor;
    public bool bool24;
    public bool bool25;
    public bool bool26;
    public bool bool27;
    public bool bool28;
    public bool bool29;
    public bool bool30;
    public GameObject treasure;

    public GameObject coins0, coins1, coins2, coins3, coins4, coins5, coins6, coins7
        , coins8, coins9, coins10, coins11;


    public bool dead =false;

    private GameObject currentObject;
    private GameObject currentDoor;

    public GameObject doorUI;
    public GameObject ui;
    public GameObject winUI;
    public GameObject greenHerb;
    public GameObject redHerb;
    public GameObject grenade;
    public GameObject flashGrenade;
    public GameObject normalGunpowder;
    public GameObject heavyGunPowder;

    public bool b0, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11;


    public AudioSource dieAudio;
    public bool dieAudioBool = true;
    public AudioSource openDoorAudio;
    public AudioSource hitAudio;

    public InventoryManager InventoryManager;



    private void Update()
    {
        if (playerHealth > 8)
        {
            playerHealth = 8;
        }
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }
        
        healthText.SetText("Player Health: "+ playerHealth);
        //cheat
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerHealth += 8;
        }
        if (playerHealth <= 0) { playerAnim.SetTrigger("die"); PlayDie();dead = true; loseUi.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(0); // call main menu

            }
            Invoke("PauseGame", 8); }


        candestroy = false;
        ui.SetActive(false);
        doorUI.SetActive(false);

        // check the nearest object to pickup

        if (b0 == true && Vector3.Distance(transform.position, coins0.transform.position) < 2 && coins0.activeSelf)
         {
             ui.SetActive(true);
             currentObject = coins0;
             candestroy = true;

         }
        if (b1 == true && Vector3.Distance(transform.position, coins1.transform.position) < 2 && coins1.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins1;
            candestroy = true;

        }
        if (b2 == true && Vector3.Distance(transform.position, coins2.transform.position) < 2 && coins2.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins2;
            candestroy = true;

        }
        if (b3 == true && Vector3.Distance(transform.position, coins3.transform.position) < 2 && coins3.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins3;
            candestroy = true;

        }
        if (b4 == true && Vector3.Distance(transform.position, coins4.transform.position) < 2 && coins4.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins4;
            candestroy = true;

        }
        if (b5 == true && Vector3.Distance(transform.position, coins5.transform.position) < 2 && coins5.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins5;
            candestroy = true;

        }
        if (b6 == true && Vector3.Distance(transform.position, coins6.transform.position) < 2 && coins6.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins6;
            candestroy = true;

        }
        if (b7 == true && Vector3.Distance(transform.position, coins7.transform.position) < 2 && coins7.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins7;
            candestroy = true;

        }
        if (b8 == true && Vector3.Distance(transform.position, coins8.transform.position) < 2 && coins8.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins8;
            candestroy = true;

        }
        if (b9 == true && Vector3.Distance(transform.position, coins9.transform.position) < 2 && coins9.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins9;
            candestroy = true;

        }
        if (b10 == true && Vector3.Distance(transform.position, coins10.transform.position) < 2 && coins10.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins10;
            candestroy = true;

        }
        if (b11 == true && Vector3.Distance(transform.position, coins11.transform.position) < 2 && coins11.activeSelf)
        {
            ui.SetActive(true);
            currentObject = coins11;
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
        if (bool23 == true && Vector3.Distance(transform.position, emerald.transform.position) < 2)
        {
            ui.SetActive(true);
            currentObject = emerald;
            candestroy = true;

        }
        if (bool24 == true && Vector3.Distance(transform.position, emeraldDoor.transform.position) < 2)
        {
            doorUI.SetActive(true);
            currentDoor = emeraldDoor;
        }
        /*  if (bool25 == true && Vector3.Distance(transform.position,greenHerb.transform.position) < 2)
          {
              ui.SetActive(true);
              currentObject = greenHerb;
              candestroy = true;
          }
          if (bool26 == true && Vector3.Distance(transform.position, redHerb.transform.position) < 2)
          {
              ui.SetActive(true);
              currentObject = redHerb;
              candestroy = true;
          }
          if (bool27 == true && Vector3.Distance(transform.position, grenade.transform.position) < 2)
          {
              ui.SetActive(true);
              currentObject = grenade;
              candestroy = true;
          }
          if (bool28 == true && Vector3.Distance(transform.position, flashGrenade.transform.position) < 2)
          {
              ui.SetActive(true);
              currentObject = flashGrenade;
              candestroy = true;
          }
          if (bool29 == true && Vector3.Distance(transform.position,normalGunpowder.transform.position) < 2)
          {
              ui.SetActive(true);
              currentObject = normalGunpowder;
              candestroy = true;
          }
          if(bool30 == true && Vector3.Distance(transform.position,heavyGunPowder.transform.position) < 2)
          {
              ui.SetActive(true);
              currentObject = heavyGunPowder;
              candestroy = true;
          }
        */
        if (Vector3.Distance(transform.position, treasure.transform.position) < 3)
        {
            winUI.SetActive(true);
            winAudio.Play();
            Invoke("PauseGame", 3);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(0); // call main menu

            }
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
    //performed when pressing pickup key
    public void PickUPs()
    {

        if (currentObject == revolver) { bool1 = false; hasRevolver = true; }
        if (currentObject == coins0) { b0 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins1) { b1 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins2) { b2 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins3) { b3 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins4) { b4 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins5) { b5 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins6) { b6 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins7) { b7 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins8) { b8 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins9) { b9 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins10) { b10 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
        if (currentObject == coins11) { b11 = false; InventoryManager.goldCoins += 10; InventoryManager.UpdateKnifeGoldCoinsText();
            InventoryManager.UpdateGoldCoinsInvText();
            InventoryManager.UpdateGoldCoinsStoreText();
            InventoryManager.UpdateInvKnifeDurabilityText();
            InventoryManager.UpdateStotageGoldCoinsText();
            InventoryManager.UpdateInvStotageGoldCoinsText();
            InventoryManager.UpdatesellGoldCoinsTxt();
        }
    

        /*
        if (currentObject == gold1) { bool9 = false; goldcount += 10; }
        if (currentObject == gold2) { bool10 = false; goldcount += 10; }
        if (currentObject == gold3) { bool11= false; goldcount += 10; }
        if (currentObject == gold4) { bool12= false; goldcount += 10; }
        if (currentObject == gold5) { bool13 = false; goldcount += 10; }
        if (currentObject == gold6) { bool14 = false; goldcount += 10; }
        if (currentObject == gold7) { bool15 = false; goldcount += 10; }
        */
        if (currentObject == revCard) { bool16 = false; hasRevCard = true; }

        if (currentObject == spadeKey) { bool18 = false; hasSpadeKey = true;  }
        if (currentObject == diamondKey) { bool20 = false; hasDiamondKey = true; }

        if (currentObject == emerald) { bool23 = false; hasEmerald = true; }
        /*
        if(currentObject == greenHerb) {  bool25 = false;hasGreenHerb = true; }
        if (currentObject == redHerb) { bool26 = false; hasRedHerb = true; }
        if (currentObject == grenade) {  bool27 = false; hasGrenade = true; }
        if (currentObject == flashGrenade) { bool28 = false; hasFlashGrenade = true; }
        if(currentObject == normalGunpowder) {  bool29 = false; hasNormalGunpowder = true; }
        if (currentObject == heavyGunPowder) { bool30 = false; hasHeavyGunpoder = true; }
        */

        if (currentObject==coins0 || currentObject == coins1 || currentObject == coins2 || currentObject == coins3 || currentObject == coins4 || currentObject == coins5 || currentObject == coins6 ||
            currentObject == coins7 || currentObject == coins8 || currentObject == coins9 || currentObject == coins10 || currentObject == coins11 )
        {
            currentObject.SetActive(false);

        }
        else
        {
            Destroy(currentObject);
        }
        //currentObject.SetActive(false);
        candestroy = false;
    }

    //performed when pressing open door
    public void OpenDoor()
    {
        if (currentDoor == revDoor && hasRevCard == true)
        {
            bool17 = false;
            revD.SetTrigger("revdoor");
            openDoorAudio.Play();
        }
        if (currentDoor == spadeDoor && hasSpadeKey == true)
        {
            Debug.Log("hi");
            bool19 = false;
            spadeDoorA.SetTrigger("openDoor");
            openDoorAudio.Play();

        }
        if (currentDoor == diamondDoor && hasDiamondKey == true)
        {
            bool21 = false;
            diamondDoorA.SetTrigger("openDoor");
            openDoorAudio.Play();

        }
        if (currentDoor == normalDoor)
        {
            bool22 = false;
            normalDoorA.SetTrigger("openDoor");
            openDoorAudio.Play();

        }
        if (currentDoor == emeraldDoor && hasEmerald == true)
        {
            bool24 = false;
            emeraldDoorA.SetTrigger("openDoor");
            openDoorAudio.Play();

        }


    }

    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        Debug.Log("PLayer Health ");
        Debug.Log(playerHealth);
        hitAudio.Play();

        if (playerHealth <= 0)
        {
            playerDead = true;
            //Play Death animation 
        }
        else
        {
            //Play Damage Animation
        }
    }

    void PlayDie()
    {
        if (dieAudioBool)
        {
            dieAudio.Play();
            dieAudioBool = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("explosion"))
        {
            playerHealth -= 3;
            Debug.Log("playerH after bomb" + playerHealth);
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;

    }
}