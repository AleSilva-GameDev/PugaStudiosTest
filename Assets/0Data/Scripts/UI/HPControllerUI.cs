using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControllerUI : MonoBehaviour
{
    Status status;

    Slider hpBar;
    [SerializeField] Text textHp;
    [SerializeField] Image fill;

    // Start is called before the first frame update
    void Start()
    {
        //Setup properties
        status = FindObjectOfType<Status>();
        hpBar = GetComponent<Slider>();
        hpBar.maxValue = status.GetCurrentHealthHero();

        //Start setup
        //Definir vida máxima no início do game
        hpBar.value = status.GetCurrentHealthHero();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeBarUI();
    }

    void UpdateLifeBarUI()
    {
        hpBar.value = status.GetCurrentHealthHero();
        textHp.text = hpBar.value.ToString();

        float percentBarLife = hpBar.value / hpBar.maxValue;

        if(percentBarLife >= 0.7f)
        {
            fill.color = Color.green;
        }
        else if(percentBarLife >= 0.3f)
        {
            fill.color = Color.yellow;
        }
        else
        {
            fill.color = Color.red;
        }
    }
}
