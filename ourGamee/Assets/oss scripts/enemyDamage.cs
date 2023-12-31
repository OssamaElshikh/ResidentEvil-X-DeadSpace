using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public pickUpScript pickUpScript;
    public int enemyHealth = 5;
    public Animator anim;

    public bool hasBeenDamaged = false;
    public bool hasBeenDamaged2 = false;

    private InventoryManager KnifeDurabilityU;

    public GameObject coins;
    public AudioSource dieSound;
    public bool playA;
    public int knifeDurability = 10;

    //public Animator anim2;
    // Start is called before the first frame update
    void Start()
    {
        
        KnifeDurabilityU = FindObjectOfType<InventoryManager>();

        knifeDurability = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.F))
        {
            hasBeenDamaged = false;


        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            hasBeenDamaged2 = false;

        }
        if (!hasBeenDamaged)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("explosion"))
                {
                    enemyHealth -= 2;
                    hasBeenDamaged = true;
                    break;
                }
                if (collider.CompareTag("whiteExplosion"))
                {
                    Knock();
                    hasBeenDamaged = true;
                    break;
                }


            }
        }
        if (!hasBeenDamaged2)
        {

            Collider[] colliders2 = Physics.OverlapSphere(transform.position, 1);
            foreach (Collider collider in colliders2)
            {
                if (collider.CompareTag("knife") && knifeDurability > 0)
                {
                    Debug.Log("knifeHit");
                    knifeDurability--;
                    Debug.Log("Knife Stab!" + knifeDurability);
                    KnifeDurabilityU.UpdateKnifeDurabilityText();

                    enemyHealth -= 2;
                    hasBeenDamaged2 = true;
                    break;
                }
            }
        }
        if (enemyHealth <= 0)
        {
            anim.SetTrigger("die");
            coins.SetActive(true);
            PlaySound();
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
    void Knock()
    {
        anim.SetTrigger("knock");

    }
    void PlaySound()
    {
        if (!playA)
        {
            dieSound.Play();
            playA = true;
        }
    }
}
