using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasrifle = false;
    public int ammo0, ammo1, ammo2;
    private void Update()
    {
        
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
