using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenades : MonoBehaviour
{

    public Animator anim;
    public Transform cam;
    public Transform attackPoint;
    public GameObject grenade;
    public GameObject explostion;
    private GameObject currentGren;

    public int totalThrows;
    public float throwCoolDown;

    public float throwForce;
    public float throwUpwardForce;

    public bool hasExploded;
    private GameObject dest;

    bool readyToThrow;

    // Start is called before the first frame update
    void Start()
    {
        readyToThrow=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && readyToThrow && totalThrows > 0)
        {
            anim.SetTrigger("bomb");
            hasExploded = false;
            Throw ();
        }
        
    }
    public void Throw()
    {

        
        readyToThrow = false;

        GameObject projectile = Instantiate(grenade, attackPoint.position, attackPoint.rotation);
        currentGren = projectile;

        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = attackPoint.transform.forward;
  

        RaycastHit hit;

        if(Physics.Raycast(attackPoint.position,attackPoint.forward,out hit , 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRB.AddForce(forceToAdd, ForceMode.Impulse);


        totalThrows--;

        if (!hasExploded)
        {
            Invoke("Explode", 3f);
        }

        Invoke(nameof(ResetThrow), throwCoolDown);
    }

    public void ResetThrow()
    {
        readyToThrow = true;
    }
    public void Explode()
    {
        GameObject ex =Instantiate(explostion, currentGren.transform.position, Quaternion.identity);
        dest = ex;
        hasExploded = true;
        Destroy(currentGren);
        Invoke("DestroyX", 2);
        
       

    }
    public void DestroyX()
    {
        Destroy(dest);
    }
}
