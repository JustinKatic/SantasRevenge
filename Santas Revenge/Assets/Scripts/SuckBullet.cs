using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SuckBullet : MonoBehaviour
{
    public float radius = 5.0f;
    private new Rigidbody rigidbody;
    public LayerMask enemy;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemy);

        foreach (Collider nearbyObject in colliders)
        {
            NavMeshAgent nav = nearbyObject.GetComponent<NavMeshAgent>();
            EnemyMove em = nearbyObject.GetComponent<EnemyMove>();
            if (em != null)
                em.sucking = true;
            if (nav != null && nav.enabled)
                nav.SetDestination(transform.position);
        }
        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = true;
    }
}
