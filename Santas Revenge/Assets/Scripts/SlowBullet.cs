using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowBullet : MonoBehaviour
{
    public int slowSpeed = 3;

    public float radius = 5.0f;
    public LayerMask enemyLayer;


    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (Collider nearbyObject in colliders)
        {
            nearbyObject.GetComponent<EnemyMove>().SlowSpeed(slowSpeed);
        }
        Destroy(gameObject);
    }
}
