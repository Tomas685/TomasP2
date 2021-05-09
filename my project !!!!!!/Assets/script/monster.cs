using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public GameObject bullet;
    public float FireRate;
    public float nextFire;
    

    
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeForFire();
    }


    void CheckTimeForFire()
{
    if(Time.time> nextFire)
    {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + FireRate;
    }
}
}

