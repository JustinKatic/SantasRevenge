using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGunFromAnim : MonoBehaviour
{

    public GameObject gun;
    public void EnableGun()
    {
        gun.SetActive(true);
    }
}
