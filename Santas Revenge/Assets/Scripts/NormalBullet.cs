using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public int damageAmount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.GetComponent<Health>().TakeDamage(damageAmount);
        }
        Destroy(gameObject);
    }
}
