using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnifeScript : MonoBehaviour
{
    private bool hasCollided = false; // Flag to check if the knife has already collided
    private float collisionCooldown = 0.2f; // Time in seconds to wait before allowing another collision

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.gameObject.CompareTag("Player"))
        {
            hasCollided = true;
            pickUpScript playerScript = collision.gameObject.GetComponent<pickUpScript>();
            Debug.Log("Knife hit the player!");
            playerScript.TakeDamage(3);
            // Destroy(gameObject); // Uncomment if you want to destroy the knife on impact

            // Reset the collision flag after a delay
            StartCoroutine(ResetCollision());
        }
    }

    private IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(collisionCooldown);
        hasCollided = false;
    }
}