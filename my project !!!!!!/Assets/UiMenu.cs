using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenu : MonoBehaviour
    
{
    // Start is called before the first frame update
    public static UiMenu instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Upgrade()
    {
        //if (levelManager.instance.gemsCollected >= 0)
       // {
            PlayerhealthController.instance.currentHealth++;
            PlayerScript.instance.moveSpeed++;
        if (PlayerhealthController.instance.currentHealth <= 3)
        {
            UIController.instance.HealthDisplay();
        }
              
        // }
    }
        
}
