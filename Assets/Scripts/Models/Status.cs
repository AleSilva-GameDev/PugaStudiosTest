using UnityEngine;
using System.Collections.Generic;

public class Status : MonoBehaviour
{

    [Header("Settings")]
    public ShipType myType;
    public List<StatusLevel> allStatus;
    [Range(1, 5)] public int healthLevel;
    [Range(1, 5)] public int attackLevel;
    [Range(1, 5)] public int speedLevel;
    public int maxHealth;

    [Header("Behaviour")]
    protected int damage;
    protected int currentLife;


    private void Start()
    {
        maxHealth = allStatus[healthLevel - 1].health;
    }

    public void TakeDamage(float applyDamage)
    {
        allStatus[healthLevel - 1].health -= (int)applyDamage;
    }


    public void Death(float dropTax = 0, GameObject ob = null)
    {
        Destroy(this.gameObject);
        //Terminar o jogo quando o herói for destruído
        GameManager.Instance.EndGame();

        if (myType == ShipType.ENEMY)
        {
            int chance = Random.Range(0, 101);
            if (chance >= 100 - (int)(dropTax * 100))
            {
                Instantiate(ob, transform.position, Quaternion.identity);
            }
        }
    }

    public int GetHealthHero()
    {
        if(myType == ShipType.HERO)
            return allStatus[healthLevel - 1].health;

        return 0;
    }

    public int InitialHealthHero()
    {
        return allStatus[healthLevel - 1].health;
    }
}

[System.Serializable]
public class StatusLevel 
{
    public int health;
    public int attack;
    public float speed;
}