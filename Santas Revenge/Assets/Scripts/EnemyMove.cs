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
    private int defaultSpeed;

    bool Slowed = false;

    private void OnEnable()
    {
        closeToPlayer = false;
        rampDestIndex = Random.Range(0, rampDestinations.Length);
        agent.enabled = true;
        agent.SetDestination(rampDestinations[rampDestIndex].transform.position);
    }

    private void Awake()
    {
        rampDestinations = GameObject.FindGameObjectsWithTag("RampPos");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        defaultSpeed = (int)agent.speed;
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
            if (agent.enabled)
            agent.SetDestination(player.position);
    }

    public void SlowSpeed(float slowSpeed)
    {
        agent.speed = slowSpeed;
    }
}
