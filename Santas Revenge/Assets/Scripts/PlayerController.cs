using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Vector3 input;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += input * speed * Time.deltaTime;

        anim.SetFloat("X", input.x, 0.2f, Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("roll");
        }
    }
}
