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
    public GameObject knife;

    public pickUpScript pickUpScript;

    public GameObject bulletPrefab;
    public GameObject shotgunbullet;
    public GameObject riffleBullet;
    public GameObject revBullet;

    public AudioSource relodeAudio;
    public AudioSource fireAudio;


    public int bulletSpeed = 2;


    // 1 for pistol 2 for shotgun 3 for rifle 4 for revolver
    public int weapon = 0;
    public StarterAssets.StarterAssetsInputs st;

    //capacity:
    public int pistolCap = 12;
    public int rifleCap = 30;
    public int shotGunCap = 8;
    public int revolverCap = 6;

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

    public bool isAiming;

    private void Start()
    {
        isAiming = false;
        weapon = 0;
    }

    void Update()
    {

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
        if (Input.GetKeyDown(KeyCode.K) && weapon == 5)
        {
            anim.SetTrigger("stab");
        }

            //firing
            if (st.isAiming == false)
        {


            //pistol
            if (Input.GetKeyDown(KeyCode.K) && weapon == 1)
            {
                // Create a rotation Quaternion with a 90-degree rotation around the Y-axis
                Quaternion bulletRotation = Quaternion.Euler(-90f, 0f, 0f);

                // Instantiate the bullet prefab with the specified rotation
                var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletRotation);

                // Set the velocity of the bullet
                bullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;

                fireAudio.Play();
            }

            //shotgun
            if (Input.GetKeyDown(KeyCode.K) && weapon == 2)
                {
                    Quaternion bulletRotation = Quaternion.Euler(0f, -90f, 90f);

                    var bullet = Instantiate(shotgunbullet, shotguntrans.position, bulletRotation);

                    bullet.GetComponent<Rigidbody>().velocity = shotguntrans.forward * bulletSpeed;
                fireAudio.Play();

            }
            //rifle
            if (Input.GetKey(KeyCode.K) && weapon == 3)
            {
                Quaternion bulletRotation = Quaternion.Euler(0f, -90f, 90f);

                var bullet = Instantiate(riffleBullet, riffleTrans.position, bulletRotation);

                bullet.GetComponent<Rigidbody>().velocity = riffleTrans.forward * bulletSpeed;
                fireAudio.Play();

            }
            //revolver
            if (Input.GetKeyDown(KeyCode.K) && weapon == 4)
            {
                Quaternion bulletRotation = Quaternion.Euler(-90f, 0f, 0f);

                var bullet = Instantiate(revBullet, revTrans.position, bulletRotation);

                bullet.GetComponent<Rigidbody>().velocity = revTrans.forward * bulletSpeed;
                fireAudio.Play();

            }
            if (Input.GetKeyDown(KeyCode.R))
                {
                if (weapon == 1 )
                {
                    pistAv += pistolCap;
                    anim.SetTrigger("relode");
                    relodeAudio.Play();

                }
                if (weapon == 2)
                {
                    rifAv += rifleCap;
                    anim.SetTrigger("relode");
                    relodeAudio.Play();

                }
                if (weapon == 3)
                {
                    shotAv += shotGunCap;
                    anim.SetTrigger("relode");
                    relodeAudio.Play();

                }
                if (weapon == 4)
                {
                    revAv += revolverCap;
                    anim.SetTrigger("relode");
                    relodeAudio.Play();

                }


            }



        }
        if (Input.GetKeyDown(KeyCode.U) && isAiming==false) { weapon = 1; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.I) && isAiming == false) { weapon = 2; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.O) && isAiming == false) { weapon = 3; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.P) && isAiming == false && pickUpScript.hasRevolver==true) { weapon = 4; SetActiveWeapon(); }
        if (Input.GetKeyDown(KeyCode.Z) && isAiming == false) { weapon = 5; SetActiveWeapon(); }





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
}
