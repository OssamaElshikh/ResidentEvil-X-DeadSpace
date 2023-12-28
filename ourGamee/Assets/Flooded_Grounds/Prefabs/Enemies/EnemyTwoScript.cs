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
            Vector3 shootDirection = transform.forward - transform.right * 0.1f;  // Adjust the 0.1f to control the rightward deviation
            shootDirection.Normalize();  // Normalize to maintain consistent force

            rb.AddForce(shootDirection * 30f, ForceMode.Impulse);
            hasShot = true;
        }
        

    }
   
}
