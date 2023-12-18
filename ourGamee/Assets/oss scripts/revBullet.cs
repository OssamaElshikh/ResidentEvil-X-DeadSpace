using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revBullet : MonoBehaviour
{
    public int damage = 5;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("enemy"))
        {

        }
        Destroy(gameObject);
    }
}
