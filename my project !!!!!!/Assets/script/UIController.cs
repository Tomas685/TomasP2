using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image heart1, heart2, heart3, heart4, heart5;
    public Sprite fullheart, emptyheart, halfheart;
    public Text gemText;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gemUpdateCount();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HealthDisplay()
    {
        Debug.Log(PlayerhealthController.instance.currentHealth);

        switch (PlayerhealthController.instance.currentHealth)
        {
            
            case 5:
                heart1.sprite = fullheart;
                heart2.sprite = fullheart;
                heart3.sprite = fullheart;
                heart4.sprite = fullheart;
                heart5.sprite = fullheart;
                break;
            case 4:
                heart1.sprite = fullheart;
                heart2.sprite = fullheart;
                heart3.sprite = fullheart;
                heart4.sprite = fullheart;
                heart5.sprite = emptyheart;
                break;

            case 3:
                heart1.sprite = fullheart;
                heart2.sprite = fullheart;
                heart3.sprite = fullheart;
                heart4.sprite = emptyheart;
                heart5.sprite = emptyheart;
                break;
            case 2:
                heart1.sprite = fullheart;
                heart2.sprite = fullheart;
                heart3.sprite = emptyheart;
                heart4.sprite = emptyheart;
                heart5.sprite = emptyheart;
                break;
            case 1:
                heart1.sprite = fullheart;
                heart2.sprite = emptyheart;
                heart3.sprite = emptyheart;
                heart4.sprite = emptyheart;
                heart5.sprite = emptyheart;
                break;

            case 0:
                heart1.sprite = emptyheart;
                heart2.sprite = emptyheart;
                heart3.sprite = emptyheart;
                heart4.sprite = emptyheart;
                heart5.sprite = emptyheart;
                break;
        }
    }

    public void gemUpdateCount()
    {
        gemText.text = levelManager.instance.gemsCollected.ToString();

    }
}
