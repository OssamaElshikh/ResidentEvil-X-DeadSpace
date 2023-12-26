using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public pickUpScript pickUpScript;
    public int enemyHealth = 5;
    public Animator anim;

    public bool hasBeenDamaged = false;
    public AudioSource dieSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            hasBeenDamaged = false;

        }
        if (!hasBeenDamaged)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("explosion"))
                {
                    enemyHealth -= 3;
                    hasBeenDamaged = true;
                    break;
                }
                if (collider.CompareTag("whiteExplosion"))
                {
                    Debug.Log("white");
                }
            }
        }
        if (enemyHealth <= 0)
        {
            anim.SetTrigger("die");
            dieSound.Play();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collison");
        if (collision.collider.CompareTag("pistolBullet"))
        {
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

            enemyHealth -= 5;
        }

        if (collision.collider.CompareTag("explosion"))
        {
            Debug.Log("yooo");
            enemyHealth -= 5;
        }


        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("hi");
            pickUpScript.playerHealth--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("explosion"))
        {
            Debug.Log("yay");
            enemyHealth -= 5;
        }
    }
    public void applyDamage()
    {
        enemyHealth -= 3;
        Debug.Log("newbomb");
    }
}
