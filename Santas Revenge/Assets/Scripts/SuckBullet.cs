using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SuckBullet : MonoBehaviour
{
    //public int damageAmount = 100;
    public float radius = 5.0f;
    //public float explosionForce = 10000.0f;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);


        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            Health health = nearbyObject.GetComponent<Health>();


            NavMeshAgent nav = nearbyObject.GetComponent<NavMeshAgent>();
            if (nav != null)
                nav.SetDestination(transform.position);
            //nav.enabled = false;

            if (rb != null && health != null)
            {
                //rb.isKinematic = false;
                //rb.AddExplosionForce(explosionForce, transform.position, radius);
                //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                //health.TakeDamage(damageAmount);
            }
        }

        //if (collision.rigidbody != null)
        //collision.rigidbody.AddForce(-collision.contacts[0].normal * 1000);
        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = true;
        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
