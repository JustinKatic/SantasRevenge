using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Vector3 input;


    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += input * speed * Time.deltaTime;
    }
}
