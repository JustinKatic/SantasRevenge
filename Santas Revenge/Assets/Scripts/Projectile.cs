using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PerformAbility();
    }

    protected virtual void PerformAbility()
    {

    }

}
