using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public bool isGem;
    private bool isCollected;
    public bool isHealthPack;
    public GameObject pickupEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                levelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                UIController.instance.gemUpdateCount();
            }

            if (isHealthPack)
            {
                if (PlayerhealthController.instance.currentHealth != PlayerhealthController.instance.maxHealth)
                {
                    PlayerhealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}

