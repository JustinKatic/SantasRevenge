using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootin : MonoBehaviour
{
    Vector3 worldPosition;
    [SerializeField] GameObject objectToShoot;

    [SerializeField] Transform projectileSpawnPoint;
    public LayerMask layerToIgnore;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000f, ~layerToIgnore))
        {
            worldPosition = hitData.point;
        }
        else
        {
            worldPosition = ray.GetPoint(1000f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject spawnedProj = Instantiate(objectToShoot, projectileSpawnPoint.position, Quaternion.identity);
            spawnedProj.GetComponent<Rigidbody>().velocity = (worldPosition - projectileSpawnPoint.position).normalized * 100f;
        }
    }
}
