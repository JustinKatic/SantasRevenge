using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject objectToShoot;

    [SerializeField] Transform projectileSpawnPoint;
    Vector3 aimPos;
    float distance = 10;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GetMousePos();
            ShootObject();
        }
      
    }

    public void ShootObject()
    {
        //Set objectToShoot to item from array
        GameObject spawnedProjectile;
        spawnedProjectile = Instantiate(objectToShoot, projectileSpawnPoint.position, Quaternion.identity);
        spawnedProjectile.transform.LookAt(aimPos);
    }

    private void GetMousePos()
    {
        aimPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        aimPos = Camera.main.ScreenToWorldPoint(aimPos);
    }
}
