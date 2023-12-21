using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneScript : MonoBehaviour
{
    public Transform player;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.destination = player.position;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance && distanceToPlayer > 1)
        {
            print("IS WALKING TRUE");
            animator.SetBool("isWalking", true);
        }
        else
        {
            print("IS WALKING FALSE");
            animator.SetBool("isWalking", false);

        }
    }
}
