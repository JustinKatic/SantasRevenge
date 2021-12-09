using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Animator anim;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        if (agent.destination != null)
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);


    }
}
