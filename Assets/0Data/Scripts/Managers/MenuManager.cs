﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text textTotalCurrencies;

    // Start is called before the first frame update
    void Start()
    {
        textTotalCurrencies.text = "Total Coins: " + PlayerPrefs.GetInt("TotalCurrencies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SceneGame");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
