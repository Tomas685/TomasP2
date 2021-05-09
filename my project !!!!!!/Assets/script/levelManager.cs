using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public int gemsCollected;
    public float waitToRespawn;
    public static levelManager instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
    }
    public void respawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerhealthController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        PlayerhealthController.instance.gameObject.SetActive(true);
        PlayerScript.instance.transform.position = CPController.instance.spawnpoint;
        PlayerhealthController.instance.currentHealth = PlayerhealthController.instance.maxHealth;
        UIController.instance.HealthDisplay();
    }

}
