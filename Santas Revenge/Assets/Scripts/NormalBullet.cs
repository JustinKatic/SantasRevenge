using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalBullet : MonoBehaviour
{
    public int damageAmount = 1;
    public float radius = 5.0f;
    private new Rigidbody rigidbody;
    public LayerMask enemy;
    public float waitTime = 3f;
    public float explosionForce = 1000.0f;
    public int explosionDamageAmount = 100;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damageAmount, 1f);
        }
        //Destroy(gameObject);
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
                health.TakeDamage(damageAmount, 1f);
            }
        }
    }
}
