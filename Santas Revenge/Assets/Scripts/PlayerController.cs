using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Vector3 moveDir;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += moveDir * speed * Time.deltaTime;

        anim.SetFloat("X", moveDir.x, 0.2f, Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (moveDir.x < 0)
                anim.Play("RollLeft");
            else if (moveDir.x > 0)
                anim.Play("RollRight");
            else
                anim.Play("Duck");
        }
    }
}
