using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent agent;

    private GameObject[] rampDestinations;
    int rampDestIndex;
    Transform player;

    bool closeToPlayer = false;
    float dist;

    private void OnEnable()
    {
        closeToPlayer = false;
        rampDestIndex = Random.Range(0, rampDestinations.Length);
        agent.SetDestination(rampDestinations[rampDestIndex].transform.position);
    }

    private void Awake()
    {
        rampDestinations = GameObject.FindGameObjectsWithTag("RampPos");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!closeToPlayer)
        {
            dist = Vector3.Distance(transform.position, rampDestinations[rampDestIndex].transform.position);
            if (dist <= 2f)
            {
                closeToPlayer = true;
            }
        }
        else
            agent.SetDestination(player.position);

    }
}
