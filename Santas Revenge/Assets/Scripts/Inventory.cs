using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> projectiles;
    private GameObject currentProjectile;
    private GameObject nextProjectile;

    public TextMeshProUGUI currentPresentTxt;
    public TextMeshProUGUI nextPresentTxt;


    private void Start()
    {
        if (projectiles != null)
        {
            currentProjectile = projectiles[Random.Range(0, projectiles.Count)];
            currentPresentTxt.text = "Current present: " + currentProjectile.name;
            nextProjectile = projectiles[Random.Range(0, projectiles.Count)];
            nextPresentTxt.text = "Next present: " + nextProjectile.name;
        }
    }

    public GameObject GetCurrentProjectile()
    {
        return currentProjectile;
    }

    public GameObject GetNextProjectile()
    {
        return nextProjectile;
    }


    public void SetNextProjectile()
    {
        if (projectiles != null)
        {
            currentProjectile = nextProjectile;
            currentPresentTxt.text = "Current present: " + currentProjectile.name;

            nextProjectile = projectiles[Random.Range(0, projectiles.Count)];
            nextPresentTxt.text = "Next present: " + nextProjectile.name;
        }
    }
}
