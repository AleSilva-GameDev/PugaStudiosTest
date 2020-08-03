using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text textTotalCurrencies;
    [SerializeField] GameObject panelChooseCharacter;
    [SerializeField] GameObject panelDeleteSave;

    // Start is called before the first frame update
    void Start()
    {
        panelChooseCharacter.SetActive(false);
        textTotalCurrencies.text = "Total Coins: " + PlayerPrefs.GetInt("TotalCurrencies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivePanelChooseCharacter(bool activePanel)
    {
        panelChooseCharacter.SetActive(activePanel);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SceneGame");
    }

    public void ActivePanelDeleteSave(bool activePanel)
    {
        panelDeleteSave.SetActive(activePanel);
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey("TotalCurrencies");
        textTotalCurrencies.text = "Total Coins: " + PlayerPrefs.GetInt("TotalCurrencies");
        panelDeleteSave.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
