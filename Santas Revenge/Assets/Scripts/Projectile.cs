using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage;

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            PerformAbility(health);
        }

        Destroy(this.gameObject);
    }

    protected virtual void PerformAbility(Health health)
    {

    }
}
