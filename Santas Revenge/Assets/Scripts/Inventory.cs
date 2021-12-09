using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]List<GameObject> projectiles;
    private GameObject currentProjectile;
    private GameObject nextProjectile;
    private void Start()
    {
        if (projectiles != null)
            currentProjectile = projectiles[Random.Range(0, projectiles.Count - 1)];

        SetNextProjectile();
    }

    public GameObject GetCurrentProjectile()
    {
        return currentProjectile;
    }

    private GameObject GetNextProjectile()
    {
        return nextProjectile;
    }

    private void SetNextProjectile()
    {
        currentProjectile = nextProjectile;

        if(projectiles != null)
            nextProjectile = projectiles[Random.Range(0, projectiles.Count - 1)];

    }


}
