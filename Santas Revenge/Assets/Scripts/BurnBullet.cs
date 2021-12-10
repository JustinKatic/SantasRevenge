using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BurnBullet : MonoBehaviour
{
    public int burnDamage = 1;
    public float radius = 5.0f;
    public float burnRate = .5f;
    public LayerMask enemy;


    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemy);

        foreach (Collider nearbyObject in colliders)
        {
            nearbyObject.GetComponent<Health>().Burn(burnRate, burnDamage);
        }
        Destroy(gameObject);
    }
}
