using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealh;
    bool dead = false;
    Rigidbody rb;

    public WaveDataSO waveDataSO;

    public TextMeshProUGUI scoreText;
    int numberOfKilled = 0;

    private Animator anim;
    private bool burning = false;

    public GameObject fire;




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
            burning = false;
            waveDataSO.ActiveEnemies--;
            numberOfKilled++;
            //anim.Play("Death");
            Invoke("Death", 1f);
            scoreText.text = "I have killed this many things: " + numberOfKilled;

        }
    }

    void Heal(int healAmount)
    {
        currentHealh = Mathf.Clamp(currentHealh + healAmount, 0, maxHealth);
    }

    void Death()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            GameObject RedSpark = ObjectPooler.SharedInstance.GetPooledObject("RedSpark");
            RedSpark.transform.position = transform.position;
            RedSpark.SetActive(true);
        }
        else
        {
            GameObject GreenSpark = ObjectPooler.SharedInstance.GetPooledObject("GreenSpark");
            GreenSpark.transform.position = transform.position;
            GreenSpark.SetActive(true);
        }

        gameObject.SetActive(false);

    }

    public void Burn(float waitTime, int damage)
    {
        burning = true;
        StartCoroutine(BurnBaby(waitTime, damage));
    }

    IEnumerator BurnBaby(float waitTime, int damage)
    {
        fire.SetActive(true);
        while (burning)
        {
            yield return new WaitForSeconds(waitTime);
            TakeDamage(damage);
        }
    }
}
