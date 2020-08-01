using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyControllerUI : MonoBehaviour
{
    Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        coinsText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        coinsText.text = "Coins: " + CurrencyManager.Instance.totalCurrencys.ToString();
    }
}
