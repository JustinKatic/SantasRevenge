using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplosiveBullet : MonoBehaviour
{
    public int damageAmount = 100;
    public float radius = 5.0f;
    public float explosionForce = 10000.0f;
    public LayerMask enemyLayer;
    public GameObject explosionPrefab;


    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);


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
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                health.TakeDamage(damageAmount, 1f);
            }
        }

        if (collision.rigidbody != null)
            collision.rigidbody.AddForce(-collision.contacts[0].normal * 1000);

        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
