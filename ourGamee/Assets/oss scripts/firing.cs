using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class firing : MonoBehaviour
{
    public int pistolAmmo, rifleAmmo, shotGunAmmo,revAmmo = 0;
    private InventoryManager KnifeDurabilityU;

    public int KnifeDUR;
    public GameObject pistol;
    public GameObject revolver;
    public GameObject shotgun;
    public GameObject riffle;
    public GameObject knife;

    public CinemachineVirtualCamera camera2;

    public pickUpScript pickUpScript;

    public GameObject bulletPrefab;
    public GameObject shotgunbullet;
    public GameObject riffleBullet;
    public GameObject revBullet;

    public AudioSource relodeAudio;
    public AudioSource fireAudio;

    public int bulletSpeed = 2;

    private InventoryManager Instance;
    // 1 for pistol 2 for shotgun 3 for rifle 4 for revolver
    public int weapon = 0;
    public StarterAssets.StarterAssetsInputs st;

    //capacity:
    public int pistolCap = 12;
    public int rifleCap = 30;
    public int shotGunCap = 8;
    public int revolverCap = 6;


    public int pistolCapCount = 12;
    public int rifleCapCount = 30;
    public int shotGunCapCount = 8;
    public int revolverCapCount = 6;


    public int pistAv;
    public int rifAv;
    public int shotAv;
    public int revAv;

    public int pistDam = 2;
    public int rifleDam = 1;
    public int shotGunDam = 3;
    public int revDam = 5;

    public Transform bulletPoint;
    public Transform shotguntrans;
    public Transform revTrans;
    public Transform riffleTrans;

    public Animator anim;

    public float pistolCooldown = 0.2f;
    public float shotgunCooldown = 0.5f;
    public float rifleCooldown = 0.2f;
    public float revolverCooldown = 1f;

    private float currentCooldown = 0f;

    public bool isAiming;

    private void Start()
    {
        Instance = FindObjectOfType<InventoryManager>();
        isAiming = false;
        weapon = 0;
    }

    void Update()
    {
        if  (Input.GetKey(KeyCode.LeftShift)){
            isAiming = false;
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (currentCooldown <= 0f)
            {
                Fire();
                currentCooldown = GetCooldownForWeapon();
            }
            else
            {
                Debug.Log("Cooldown in progress...");
            }
        }
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isAiming = !isAiming;
            if (weapon == 0 || weapon ==5)
            {
                isAiming = !isAiming;
            }
            if (weapon == 2 || weapon == 3)
            {
                anim.SetBool("aiming", isAiming);
            }
            if (weapon==1 || weapon == 4)
            {
                anim.SetBool("pistolAiming", isAiming);
            }
          
        }
        if (isAiming)
        {
            camera2.Priority = 15;
        }
        else
        {
            camera2.Priority = 5;
        }
        if (Input.GetKeyDown(KeyCode.K) && weapon == 5)
        {

            //KnifeDUR--;
            //Debug.Log("Knife Stab!"+ KnifeDUR);
            //KnifeDurabilityU = FindObjectOfType<InventoryManager>();
            //KnifeDurabilityU.UpdateKnifeDurabilityText();

            anim.SetTrigger("stab");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weapon == 1)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "pistolAmmo");
                Item found = Instance.Items.Find(item => item.itemName == "Pistol");
                if (foundItem == null)
                {

                    Debug.Log("No Amoo in Inventory");
                }
                else
                {
                    Debug.Log("there is pistolAmmo");
                    while (found.ammo < 12 && foundItem.ammo > 0)
                    {

                        foundItem.ammo--;
                        found.ammo++;
                        Instance.ListItems();
                        if (foundItem.ammo == 0)
                        {
                            Instance.Items.Remove(foundItem);
                            Instance.ListItems();
                        }

                    }
                    anim.SetTrigger("reload");
                    relodeAudio.Play();
                }
            }






            if (weapon == 2)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "shotgunAmmo");
                Item found = Instance.Items.Find(item => item.itemName == "Shotgun");
                if (foundItem == null)
                {

                    Debug.Log("No Amoo in Inventory");
                }
                else
                {
                    Debug.Log("there is shotgunAmmo");

                    while (found.ammo < 8 && foundItem.ammo > 0)
                    {
                        //Debug.Log("Inside While");
                        foundItem.ammo--;
                        found.ammo++;
                        Instance.ListItems();
                        if (foundItem.ammo == 0)
                        {
                            Instance.Items.Remove(foundItem);
                            Instance.ListItems();
                        }

                    }
                    anim.SetTrigger("reload");
                    relodeAudio.Play();
                }



            }
            if (weapon == 3)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "riffleAmmo");
                Item found = Instance.Items.Find(item => item.itemName == "Riffle");
                if (foundItem == null)
                {

                    Debug.Log("No Amoo in Inventory");
                }
                else
                {
                    Debug.Log("there is riffle ammo");
                    while (found.ammo < 30 && foundItem.ammo > 0)
                    {
                        anim.SetTrigger("reload");
                        relodeAudio.Play();
                        foundItem.ammo--;
                        found.ammo++;
                        Instance.ListItems();
                        if (foundItem.ammo == 0)
                        {
                            Instance.Items.Remove(foundItem);
                            Instance.ListItems();
                        }

                    }
                    anim.SetTrigger("reload");
                    relodeAudio.Play();
                }

            }
            if (weapon == 4)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "revolverAmmo");
                Item found = Instance.Items.Find(item => item.itemName == "Revolver");
                if (foundItem == null)
                {

                    Debug.Log("No Amoo in Inventory");
                }
                else
                {
                    Debug.Log("there is shotgunAmmo");

                    while (found.ammo < 6 && foundItem.ammo > 0)
                    {
                        //Debug.Log("Inside While");
                        foundItem.ammo--;
                        found.ammo++;
                        Instance.ListItems();
                        if (foundItem.ammo == 0)
                        {
                            Instance.Items.Remove(foundItem);
                            Instance.ListItems();
                        }

                    }
                    anim.SetTrigger("reload");
                    relodeAudio.Play();
                }

            }


        }
        //firing


        // if (Input.GetKeyDown(KeyCode.U) && isAiming == false && Instance.weapon1Equiped == true) { weapon = 1; SetActiveWeapon(); }
        //if (Input.GetKeyDown(KeyCode.I) && isAiming == false && Instance.weapon2Equiped == true) { weapon = 2; SetActiveWeapon(); }
        //if (Input.GetKeyDown(KeyCode.O) && isAiming == false && Instance.weapon3Equiped == true) { weapon = 3; SetActiveWeapon(); }
        //if (Input.GetKeyDown(KeyCode.P) && isAiming == false && pickUpScript.hasRevolver == true && Instance.weapon4Equiped == true) { weapon = 4; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.Z) && isAiming == false) { weapon = 5; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.X)) { EmptyHand(); }




    }

    public void equipweapon()
    {
        if(Instance.weapon1Equiped == true)
        {
            weapon = 1; SetActiveWeapon();
        }
        else if (Instance.weapon2Equiped == true)
        {
            weapon = 2; SetActiveWeapon();
        }
        else if (Instance.weapon3Equiped == true)
        {
            weapon = 3; SetActiveWeapon();
        }
        else if(Instance.weapon4Equiped == true)
        {
            weapon = 4; SetActiveWeapon();
        }



    }
    void Fire()
    {
        if (isAiming == true)
        {


            //pistol
            if (Input.GetKeyDown(KeyCode.K) && weapon == 1)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "Pistol");
                if (foundItem.ammo > 0)
                {

                    // Create a rotation Quaternion with a 90-degree rotation around the Y-axis
                    Quaternion bulletRotation = Quaternion.Euler(-90f, 0f, 0f);

                    // Instantiate the bullet prefab with the specified rotation
                    var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletRotation);

                    // Set the velocity of the bullet
                    bullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;

                    foundItem.ammo--;
                    Instance.ListItems();

                    fireAudio.Play();

                }
                else
                {
                    Debug.Log("Reload needed");
                }
            }

            //shotgun
            if (Input.GetKeyDown(KeyCode.K) && weapon == 2)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "Shotgun");
                if (foundItem.ammo > 0)
                {


                    Quaternion bulletRotation = Quaternion.Euler(0f, -90f, 90f);

                    var bullet = Instantiate(shotgunbullet, shotguntrans.position, bulletRotation);

                    bullet.GetComponent<Rigidbody>().velocity = shotguntrans.forward * bulletSpeed;
                    fireAudio.Play();
                    foundItem.ammo--;
                    Instance.ListItems();
                    
                }
                else
                {
                    Debug.Log("Reload needed");
                }

            }
            //rifle
            if (Input.GetKey(KeyCode.K) && weapon == 3)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "Riffle");
                if (foundItem.ammo > 0)
                {


                    Quaternion bulletRotation = Quaternion.Euler(0f, -90f, 90f);

                    var bullet = Instantiate(riffleBullet, riffleTrans.position, bulletRotation);

                    bullet.GetComponent<Rigidbody>().velocity = riffleTrans.forward * bulletSpeed;


                    foundItem.ammo--;
                    Instance.ListItems();



                    fireAudio.Play();
                }
                else
                {
                    Debug.Log("Reload needed");
                }
            }
            //revolver
            if (Input.GetKeyDown(KeyCode.K) && weapon == 4)
            {
                Item foundItem = Instance.Items.Find(item => item.itemName == "Revolver");

                if (foundItem.ammo > 0)
                {


                    Quaternion bulletRotation = Quaternion.Euler(-90f, 0f, 0f);

                    var bullet = Instantiate(revBullet, revTrans.position, bulletRotation);

                    bullet.GetComponent<Rigidbody>().velocity = revTrans.forward * bulletSpeed;

                    foundItem.ammo--;

                    fireAudio.Play();


                }
                else
                {
                    Debug.Log("Reload needed");
                }
            }




        }
        
    }

    float GetCooldownForWeapon()
    {
        switch (weapon)
        {
            case 1: // Pistol
                return pistolCooldown;
            case 2: // Shotgun
                return shotgunCooldown;
            case 3: // Rifle
                return rifleCooldown;
            case 4: // Revolver
                return revolverCooldown;
            default:
                return 0f; // Default to no cooldown
        }
    }
    void SetActiveWeapon()
    {
        if (weapon == 1)
        {
            knife.SetActive(false);
            riffle.SetActive(false);
            shotgun.SetActive(false);
            revolver.SetActive(false);
            pistol.SetActive(true);

        }
        if (weapon == 2)
        {
            knife.SetActive(false);
            riffle.SetActive(false);
            revolver.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(true);

        }
        if (weapon == 3)
        {
            knife.SetActive(false);
            revolver.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            riffle.SetActive(true);
        }
        if (weapon == 4)
        {
            knife.SetActive(false);
            pistol.SetActive(false);
            riffle.SetActive(false);
            shotgun.SetActive(false);
            revolver.SetActive(true);
        }
        if (weapon == 5)
        {
            pistol.SetActive(false);
            riffle.SetActive(false);
            shotgun.SetActive(false);
            revolver.SetActive(false);
            knife.SetActive(true);
        }
       
    }
    void EmptyHand()
    {
        pistol.SetActive(false);
        riffle.SetActive(false);
        shotgun.SetActive(false);
        revolver.SetActive(false);
        knife.SetActive(false);
        weapon = 0;
        Instance.weapon1Equiped = false;
        Instance.weapon2Equiped = false;
        Instance.weapon3Equiped = false;
        Instance.weapon4Equiped = false;

    }
}
