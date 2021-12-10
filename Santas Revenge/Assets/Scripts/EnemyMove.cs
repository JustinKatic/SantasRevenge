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

    public GameObject ice;



    bool closeToPlayer = false;
    float dist;
    private int defaultSpeed;


    private void OnEnable()
    {
        ice.SetActive(false);
        closeToPlayer = false;
        agent.speed = defaultSpeed;
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
        ice.SetActive(true);
        agent.speed = slowSpeed;
    }
}
