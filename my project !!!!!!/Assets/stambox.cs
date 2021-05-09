using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stambox : MonoBehaviour
{
    public GameObject death_effect;
    public GameObject gem;
    //[Range(0, 100)]
    public float chanceToDrop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Debug.Log("Asi toimib");
            collision.transform.parent.gameObject.SetActive(false);
            Instantiate(death_effect, collision.transform.position, collision.transform.rotation);
            //AudioManager.instance.PlaySound(3);
            PlayerScript.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);
            if (dropSelect <= chanceToDrop)
            {
                Instantiate(gem, collision.transform.position * 1.1f, collision.transform.rotation);
            }

        }
    }
}
