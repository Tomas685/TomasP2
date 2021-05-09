using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerhealthController : MonoBehaviour
{
    public GameObject deathEffect;
    public static PlayerhealthController instance;
    public int currentHealth, maxHealth;
    public float invLength; //Kui kaua on meie tegelane surematu
    private float timer;
    private SpriteRenderer sr;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentHealth = 3;
        Debug.Log(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }

        }

    }

    public void Damage()
    {
        if (timer <= 0)
        {
            currentHealth--;
            Debug.Log("controll");
            UIController.instance.HealthDisplay();
            if (currentHealth <= 0)
            {
                //gameObject.SetActive(false);
                Debug.Log("Cont");
                //Instantiate(deathEffect, transform.position, transform.rotation);
                levelManager.instance.respawnPlayer();
            }
            else
            {
                timer = invLength;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }

    }

    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.HealthDisplay();
    }

}



