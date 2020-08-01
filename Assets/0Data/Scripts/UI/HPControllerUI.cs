using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControllerUI : MonoBehaviour
{
    Status status;

    Slider hpBar;
    [SerializeField] Text textHp;

    // Start is called before the first frame update
    void Start()
    {
        //Setup properties
        status = FindObjectOfType<Status>();
        hpBar = GetComponent<Slider>();
        hpBar.maxValue = status.GetHealthHero();

        //Start setup
        //Definir vida máxima no início do game
        hpBar.value = status.GetHealthHero();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeBarUI();
    }

    void UpdateLifeBarUI()
    {
        hpBar.value = status.GetHealthHero();
        textHp.text = hpBar.value.ToString();
    }
}
