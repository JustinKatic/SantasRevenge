using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerMovement : MonoBehaviour
{
    private GameObject Player;

    public float moveSpeed;

    private GameObject objToMovetowards;

    public GameObject positionBehindPlayer;

    bool closeToPlayer = false;

    Health health;


    private void OnEnable()
    {
        objToMovetowards = Player;
        closeToPlayer = false;
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        positionBehindPlayer = GameObject.FindGameObjectWithTag("DeerFlyPos");
        health = GetComponent<Health>();

    }
    void Update()
    {
        if (!closeToPlayer)
        {
            transform.LookAt(Player.transform);
            float dist = Vector3.Distance(transform.position, Player.transform.position);
            if (dist <= 2f)
            {
                objToMovetowards = positionBehindPlayer;
                closeToPlayer = true;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, objToMovetowards.transform.position, moveSpeed * Time.deltaTime);
    }
}
