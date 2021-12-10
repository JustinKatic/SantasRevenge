using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealh;
    bool dead = false;
    Rigidbody rb;

    public WaveDataSO waveDataSO;


    private Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.isKinematic = true;
        currentHealh = maxHealth;
        dead = false;
    }

    private void Start()
    {
        currentHealh = maxHealth;
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        if (dead)
            return;

        currentHealh = Mathf.Clamp(currentHealh - damage, 0, maxHealth);

        if (currentHealh <= 0)
        {
            dead = true;
            waveDataSO.ActiveEnemies--;
            //anim.Play("Death");
            Invoke("Death", 1f);
        }
    }

    void Heal(int healAmount)
    {
        currentHealh = Mathf.Clamp(currentHealh + healAmount, 0, maxHealth);
    }

    void Death()
    {
        gameObject.SetActive(false);
    }
    public void Burn(float waitTime, int damage)
    {
        StartCoroutine(BurnBaby(waitTime, damage));
    }

    IEnumerator BurnBaby(float waitTime, int damage)
    {
        yield return new WaitForSeconds(waitTime);
        TakeDamage(damage);
    }
}
