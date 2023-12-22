using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public enemyDamage ed;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            ed.enemyHealth -= 5;
            Debug.Log("bomb");
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            ed.enemyHealth -= 5;
            Debug.Log("bomb");

        }
    }
}
