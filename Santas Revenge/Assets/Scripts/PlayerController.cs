using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Vector3 moveDir;
    Animator anim;

    public GameObject model;

    [SerializeField] private float dodgeCooldown = 3f;
    private bool canDodge = true;

    public float RotOffset;

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

        if (canDodge && Input.GetKeyDown(KeyCode.Space))
        {
            if (moveDir.x < 0)
                anim.Play("RollLeft");
            else if (moveDir.x > 0)
                anim.Play("RollRight");
            else
                anim.Play("Duck");

            StartCoroutine(DodgeCooldown());
        }

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        model.transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


    IEnumerator DodgeCooldown()
    {
        canDodge = false;
        yield return new WaitForSeconds(dodgeCooldown);
        canDodge = true;
    }
}

