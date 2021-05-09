using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint instance;
    private SpriteRenderer sr;
    public Sprite cpOn, cpOff;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            FindObjectOfType<CPController>().DeactivateCp();
            sr.sprite = cpOn;
            CPController.instance.SetSpawnPoint(transform.position);
        }


    }
    public void Reset()
    {
        sr.sprite = cpOff;
    }
}
