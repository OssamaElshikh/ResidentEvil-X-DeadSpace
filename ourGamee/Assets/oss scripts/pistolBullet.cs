using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage = 2;
    // Start is called before the first frame update
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
