using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealh;
    [SerializeField] private Slider HealthBar;
    bool dead = false;

    private Animator anim;

    private void OnEnable()
    {
        currentHealh = maxHealth;
        HealthBar.maxValue = maxHealth;
        HealthBar.value = currentHealh;
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
        HealthBar.value = currentHealh;
        
        if (currentHealh <= 0)
        {
            dead = true;
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
}
