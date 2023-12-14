using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class firing : MonoBehaviour
{
    public int pistolAmmo, rifleAmmo, shotGunAmmo,revAmmo = 0;

    public GameObject pistol;
    public GameObject revolver;
    public GameObject shotgun;
    public GameObject riffle;


    public GameObject bulletPrefab;
    public GameObject shotgunbullet;
    public GameObject riffleBullet;
    public GameObject revBullet;


    public int bulletSpeed = 2;


    // 1 for pistol 2 for shotgun 3 for rifle 4 for revolver
    public int weapon = 1;
    public StarterAssets.StarterAssetsInputs st;

    //capacity:
    public int pistolCap = 12;
    public int RifleCap = 30;
    public int shotGunCap = 8;
    public int revolverCap = 6;

    public int pistDam = 2;
    public int rifleDam = 1;
    public int shotGunDam = 3;
    public int revDam = 5;

    public Transform bulletPoint;
    public Transform shotguntrans;
    public Transform revTrans;
    public Transform riffleTrans;



    void Update()
    {
        //firing
        if (st.isAiming == false)
        {


            //pistol
            if (Input.GetKeyDown(KeyCode.K) && weapon == 1)
            {
                // Create a rotation Quaternion with a 90-degree rotation around the Y-axis
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);

                // Instantiate the bullet prefab with the specified rotation
                var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletRotation);

                // Set the velocity of the bullet
                bullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;
            }

            //shotgun
            if (Input.GetKeyDown(KeyCode.K) && weapon == 2)
                {
                    Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);

                    var bullet = Instantiate(shotgunbullet, shotguntrans.position, bulletRotation);

                    bullet.GetComponent<Rigidbody>().velocity = shotguntrans.forward * bulletSpeed;
                }
            if (Input.GetKeyDown(KeyCode.K) && weapon == 3)
            {
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);

                var bullet = Instantiate(riffleBullet, riffleTrans.position, bulletRotation);

                bullet.GetComponent<Rigidbody>().velocity = riffleTrans.forward * bulletSpeed;
            }
            if (Input.GetKeyDown(KeyCode.K) && weapon == 4)
            {
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);

                var bullet = Instantiate(revBullet, revTrans.position, bulletRotation);

                bullet.GetComponent<Rigidbody>().velocity = revTrans.forward * bulletSpeed;
            }




        }
        if (Input.GetKeyDown(KeyCode.U)) { weapon = 1; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.I)) { weapon = 2; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.O)) { weapon = 3; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.P)) { weapon = 4; SetActiveWeapon(); }




    }
    void SetActiveWeapon()
    {
        if (weapon == 1) {
            riffle.SetActive(false);
            shotgun.SetActive(false);
            revolver.SetActive(false);
            pistol.SetActive(true);

        }
        if (weapon == 2)
        {
            riffle.SetActive(false);
            revolver.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(true);

        }
        if (weapon == 3)
        {
            revolver.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            riffle.SetActive(true);
        }
        if (weapon == 4)
        {
            pistol.SetActive(false);
            riffle.SetActive(false);
            shotgun.SetActive(false);
            revolver.SetActive(true);
        }

    }
}
