using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotBullet : MonoBehaviour
{
    public int damage = 3;
    void Awake()
    {
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("enemy"))
        {

        }
        Destroy(gameObject);
    }
}
