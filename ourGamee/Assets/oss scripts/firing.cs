using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public string weapon = "pistol";
    public StarterAssets.StarterAssetsInputs st;
    public Transform bulletPoint;


    void Update()
    {
        //firing
        if (st.isAiming == false)
        {
            {


                if (Input.GetKeyDown(KeyCode.K) && weapon == "pistol")
                {
                    // Create a rotation Quaternion with a 90-degree rotation around the Y-axis
                    Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);

                    // Instantiate the bullet prefab with the specified rotation
                    var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletRotation);

                    // Set the velocity of the bullet
                    bullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;
                }
            }
        }
    }
}
