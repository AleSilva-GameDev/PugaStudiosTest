using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeControllerUI : MonoBehaviour
{
    Text gameTimeUI;

    // Start is called before the first frame update
    void Start()
    {
        gameTimeUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        gameTimeUI.text = "Time: " + GameManager.Instance.timeGame.ToString("0");
    }
}
