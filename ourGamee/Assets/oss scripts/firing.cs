using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class firing : MonoBehaviour
{
    public int ammo0, ammo1, ammo2 = 0;
    public GameObject bulletPrefab;
    public GameObject shotgunbullet;
    public float bulletSpeed = 10;
    public int weapon = 1;
    public StarterAssets.StarterAssetsInputs st;
    public Transform bulletPoint;
    public Transform shotguntrans;



    void Update()
    {
        //firing
        if (st.isAiming == false)
        {



            if (Input.GetKeyDown(KeyCode.K) && weapon == 2)
            {
                // Create a rotation Quaternion with a 90-degree rotation around the Y-axis
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);

                // Instantiate the bullet prefab with the specified rotation
                var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletRotation);

                // Set the velocity of the bullet
                bullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;
            }
            if (Input.GetKeyDown(KeyCode.K) && weapon == 1)
                {
                    // Create a rotation Quaternion with a 90-degree rotation around the Y-axis
                    Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);

                    // Instantiate the bullet prefab with the specified rotation
                    var bullet = Instantiate(shotgunbullet, shotguntrans.position, bulletRotation);

                    // Set the velocity of the bullet
                    bullet.GetComponent<Rigidbody>().velocity = shotguntrans.forward * bulletSpeed;
                }
            
        }
    }
}
