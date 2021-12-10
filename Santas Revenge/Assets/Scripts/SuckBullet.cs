using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SuckBullet : MonoBehaviour
{
    public float radius = 5.0f;
    private new Rigidbody rigidbody;
    public LayerMask enemy;
    public float waitTime = 1f;
    public float explosionForce = 10000.0f;
    public int damageAmount = 100;


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

        StartCoroutine(BlowUp());
    }

    IEnumerator BlowUp()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemy);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            Health health = nearbyObject.GetComponent<Health>();


            NavMeshAgent nav = nearbyObject.GetComponent<NavMeshAgent>();
            if (nav != null)
                nav.enabled = false;

            if (rb != null && health != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(explosionForce, transform.position, radius);
                //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                health.TakeDamage(damageAmount);
            }
        }
    }
}
