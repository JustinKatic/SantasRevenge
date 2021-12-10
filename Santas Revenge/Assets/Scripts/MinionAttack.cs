using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
