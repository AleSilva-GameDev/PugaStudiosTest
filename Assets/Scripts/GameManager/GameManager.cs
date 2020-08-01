using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Singleton")]
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("References")]
    public Transform pivotToRestart;
    public GameObject ship;

    [Header("Behaviour")]
    [HideInInspector] public float gameTime;
    [HideInInspector] public bool endGame;

    [Header("Time")]
    [SerializeField] float timeStartGame = 30f;
    [SerializeField] public float timeGame;

    [Header("Panels")]
    [SerializeField] GameObject panelGameLose;
    [SerializeField] GameObject panelGameWin;

    [Header("Status")]
    Status status;


    void Awake()
    {
        instance = this;

        status = FindObjectOfType<Status>();

        timeGame = timeStartGame;
        DesactiveAllPanels();

        status.maxHealth = status.GetHealthHero();
    }


    void Update()
    {
        if (Input.GetButton("Cancel") && endGame)
            RestartGame();

        UpdateTimeGame();
    }


    public void EndGame()
    {
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        gameTime = 0;
        
        if(status.GetHealthHero() > 0)
        {
            panelGameWin.SetActive(true);
        }
        else
        {
            panelGameLose.SetActive(true);
        }

        //Parar o tempo
        Time.timeScale = gameTime;
    }


    public void RestartGame()
    {
        DesactiveAllPanels();

        endGame = false;
        ship.transform.position = new Vector3(pivotToRestart.position.x, ship.transform.position.y, pivotToRestart.position.z);
        //Definir vida inicial do player quando o jogo reiniciar
        ship.GetComponent<ShipController>().allStatus[ship.GetComponent<ShipController>().healthLevel - 1].health = status.maxHealth;
        ship.GetComponent<ShipController>().EnebleMesh(true);
        SpawnManager.Instance.DestroyerAllEnemy();
        SpawnManager.Instance.spawnAble = true;

        //Resetando moedas
        CurrencyManager.Instance.totalCurrencys = 0;

        gameTime = 1;

        //Voltar a velocidade normal de jogo
        Time.timeScale = gameTime;

        // Resatar o tempo
        timeGame = timeStartGame;
    }

    void UpdateTimeGame()
    {
        timeGame -= Time.deltaTime;

        if(timeGame <= 0)
        {
            EndGame();
        }
    }

    void DesactiveAllPanels()
    {
        panelGameLose.SetActive(false);
        panelGameWin.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("SceneMenu");
    }
}
