using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public int enemyHealth = 5;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            anim.SetTrigger("die");
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("pistolBullet")){
            enemyHealth -= 2;
        }
        if (collision.collider.CompareTag("rifleBullet"))
        {

            enemyHealth -= 1;
        }
        if (collision.collider.CompareTag("shotgunBullet"))
        {
            Debug.Log("col");

            enemyHealth -= 3;
            Debug.Log(enemyHealth);
        }
        if (collision.collider.CompareTag("revolverBullet"))
        {
            Debug.Log("col");

            enemyHealth -= 25;
        }
    }
}
