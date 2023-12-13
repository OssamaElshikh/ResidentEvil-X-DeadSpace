using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasrifle = false;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public int ammo0, ammo1, ammo2=0;
    public Transform bulletPoint;
    public StarterAssets.StarterAssetsInputs st;
    public string weapon = "pistol";
    private void Update()
    {
        if (st.isAiming == false)
        {
            {


                if (Input.GetKeyDown(KeyCode.K) && weapon=="pistol")
                {
                    var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {  
        if (other.CompareTag("rifle"))
        {
            Destroy(other.gameObject);
            hasrifle = true;
        }
        if (other.CompareTag("ammo0"))
        {
            Destroy(other.gameObject);
            ammo0 += 10;
        }
        if (other.CompareTag("ammo1"))
        {
            Destroy(other.gameObject);
            ammo1 += 10;
        }
        if (other.CompareTag("ammo2"))
        {
            Destroy(other.gameObject);
            ammo2 += 10;
        }
    }

}
