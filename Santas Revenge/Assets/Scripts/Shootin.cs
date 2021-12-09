using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootin : MonoBehaviour
{
    Vector3 worldPosition;
    float range = 1000f;
    public float bulletSpeed = 100f;
    public float shotsPerSecond = 10f;
    float lastFired;

    Inventory inventory;

    [SerializeField] Transform projectileSpawnPoint;
    public LayerMask layerToIgnore;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastFired > 1 / shotsPerSecond)
            {
                lastFired = Time.time;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, range, ~layerToIgnore))
        {
            worldPosition = hitData.point;
        }
        else
        {
            worldPosition = ray.GetPoint(range);
        }

        GameObject spawnedProj = Instantiate(inventory.GetCurrentProjectile(), projectileSpawnPoint.position, Quaternion.identity);
        spawnedProj.GetComponent<Rigidbody>().velocity = (worldPosition - projectileSpawnPoint.position).normalized * bulletSpeed;

        inventory.SetNextProjectile();
    }
}
