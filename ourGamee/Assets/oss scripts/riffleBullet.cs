using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riffleBullet : MonoBehaviour
{
    public int damage = 1;
    void Awake()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("enemy"))
        {

        }
        Destroy(gameObject);
    }
}
