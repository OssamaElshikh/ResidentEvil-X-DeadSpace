using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyTwoScript : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectilePoint;
    private bool hasShot = false;  // Flag to check if shot has been fired

    // Start is called before the first frame update

    public void Shoot()
    {
        if (!hasShot)
        {
            Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
            hasShot = true;
        }
        

    }
   
}
