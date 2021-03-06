﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemysBehavior : MonoBehaviour
{
    [Header("References")]
    public Transform shipTransform;
    [SerializeField] protected Transform[] cannonsLocal = new Transform[0];
    [SerializeField] protected GameObject energ;

    [Header("Settings")]
    [SerializeField] EnemysType enemyType;
    //[SerializeField] protected List<EnemysStatus> status;
    [SerializeField] protected int level = 1;
    [SerializeField] protected int myCurrencyToDrop;
    [SerializeField] protected float MaxDistanceToDrop;

    [Header("UI")]
    [SerializeField] Image lifeBar;

    [Header("Behaviour")]
    public ShipType type = ShipType.ENEMY;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected int currentLife, currentBulletsToRecharg;
    protected float currentRechargTime, currentShieldRechargTime, currentMelleAttackDelay, currentMeleeAttackTime, currentFireDelayTime, fireDelayTime;
    protected bool walk, fire, rechargFire, meleeAttack, rangeAttack, suicide, playerToTarget, shield, rechargShield, stun;

    [Header("Status")]
    public List<EnemyStatus> enemyStatus;

    protected void StartStatus()
    {
        if (GetComponent<UnityEngine.AI.NavMeshAgent>())
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        //Level
        this.level = enemyStatus[level - 1].level;

        //Bools
        walk = enemyStatus[level - 1].walk;
        fire = enemyStatus[level - 1].fire;
        rechargFire = enemyStatus[level - 1].rechargFire;
        meleeAttack = enemyStatus[level - 1].meleeAttack;
        rangeAttack = enemyStatus[level - 1].rangeAttack;
        suicide = enemyStatus[level - 1].suicide;
        playerToTarget = enemyStatus[level - 1].playerToTarget;
        shield = enemyStatus[level - 1].shield;
        rechargShield = enemyStatus[level - 1].rechargShield;
        stun = enemyStatus[level - 1].stun;

        //Int
        currentLife = enemyStatus[level - 1].life;
        currentBulletsToRecharg = enemyStatus[level - 1].bulletsToRecharg;


        UpdateUI();
    }

    #region  StartStatus - Antigo
    /*- Essa parte será modificada por um Scriptable Object
    protected void StartStatus()
    {
        level = Mathf.Clamp(level, 1, status.Count);
        currentLife = status[level - 1].life;
        currentRechargTime = currentShieldRechargTime = currentMelleAttackDelay = currentMeleeAttackTime = currentFireDelayTime = 0;
        currentBulletsToRecharg = status[level - 1].bulletsToRecharg;

        UpdateUI();

        if (GetComponent<UnityEngine.AI.NavMeshAgent>())
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        switch (enemyType)
        {
            case EnemysType.SUICIDE:
                walk = true;
                fire = false;
                rechargFire = false;
                meleeAttack = false;
                rangeAttack = false;
                suicide = true;
                playerToTarget = true;
                shield = false;
                rechargShield = false;
                stun = false;

                status[level - 1].fireRate = 0;
                status[level - 1].fireDamage = 0;
                status[level - 1].fireRechargTime = 0;
                status[level - 1].bulletsToRecharg = 0;
                status[level - 1].meleeAttackTime = 0;
                status[level - 1].meleeAttackDelay = 0;
                status[level - 1].shieldResistence = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.RANGE:
                walk = true;
                fire = true;
                rechargFire = true;
                meleeAttack = false;
                rangeAttack = true;
                suicide = false;
                playerToTarget = true;
                shield = false;
                rechargShield = false;
                stun = false;

                status[level - 1].meleeDamage = 0;
                status[level - 1].meleeAttackTime = 0;
                status[level - 1].meleeAttackDelay = 0;
                status[level - 1].shieldResistence = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.MELEE:
                walk = true;
                fire = false;
                rechargFire = false;
                meleeAttack = true;
                rangeAttack = false;
                suicide = false;
                playerToTarget = true;
                shield = false;
                rechargShield = false;
                stun = false;

                status[level - 1].fireRate = 0;
                status[level - 1].fireDamage = 0;
                status[level - 1].fireRechargTime = 0;
                status[level - 1].bulletsToRecharg = 0;
                status[level - 1].shieldResistence = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.ROCKET:
                walk = true;
                fire = true;
                rechargFire = false;
                meleeAttack = false;
                rangeAttack = true;
                suicide = false;
                playerToTarget = true;
                shield = false;
                rechargShield = false;
                stun = false;

                status[level - 1].meleeDamage = 0;
                status[level - 1].meleeAttackTime = 0;
                status[level - 1].meleeAttackDelay = 0;
                status[level - 1].shieldResistence = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.MELEE_RANGE:
                walk = true;
                fire = true;
                rechargFire = true;
                meleeAttack = true;
                rangeAttack = true;
                suicide = false;
                playerToTarget = true;
                shield = false;
                rechargShield = false;
                stun = false;

                status[level - 1].shieldResistence = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.MELEE_STUN:
                walk = true;
                fire = false;
                rechargFire = false;
                meleeAttack = true;
                rangeAttack = false;
                suicide = false;
                playerToTarget = true;
                shield = false;
                rechargShield = false;
                stun = true;

                status[level - 1].fireRate = 0;
                status[level - 1].fireDamage = 0;
                status[level - 1].fireRechargTime = 0;
                status[level - 1].bulletsToRecharg = 0;
                status[level - 1].shieldResistence = 0;
                status[level - 1].shieldRechargTime = 0;

                break;
            case EnemysType.TOWER_FIRE:
                walk = false;
                fire = true;
                rechargFire = true;
                meleeAttack = false;
                rangeAttack = true;
                suicide = false;
                playerToTarget = false;
                shield = true;
                rechargShield = false;
                stun = false;

                status[level - 1].movimentSpeed = 0;
                status[level - 1].meleeDamage = 0;
                status[level - 1].meleeAttackTime = 0;
                status[level - 1].meleeAttackDelay = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.TOWER_RANGE:
                walk = false;
                fire = true;
                rechargFire = true;
                meleeAttack = false;
                rangeAttack = true;
                suicide = false;
                playerToTarget = true;
                shield = true;
                rechargShield = false;
                stun = false;

                status[level - 1].movimentSpeed = 0;
                status[level - 1].meleeDamage = 0;
                status[level - 1].meleeAttackTime = 0;
                status[level - 1].meleeAttackDelay = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.TOWER_ROCKET:
                walk = false;
                fire = true;
                rechargFire = true;
                meleeAttack = false;
                rangeAttack = true;
                suicide = false;
                playerToTarget = true;
                shield = true;
                rechargShield = false;
                stun = false;

                status[level - 1].movimentSpeed = 0;
                status[level - 1].fireRechargTime = 0;
                status[level - 1].bulletsToRecharg = 0;
                status[level - 1].meleeDamage = 0;
                status[level - 1].meleeAttackTime = 0;
                status[level - 1].meleeAttackDelay = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
            case EnemysType.HEALER:
                walk = false;
                fire = true;
                rechargFire = true;
                meleeAttack = false;
                rangeAttack = true;
                suicide = false;
                playerToTarget = true;
                shield = true;
                rechargShield = false;
                stun = false;

                status[level - 1].movimentSpeed = 0;
                status[level - 1].fireRechargTime = 0;
                status[level - 1].bulletsToRecharg = 0;
                status[level - 1].meleeDamage = 0;
                status[level - 1].meleeAttackTime = 0;
                status[level - 1].meleeAttackDelay = 0;
                status[level - 1].shieldRechargTime = 0;
                status[level - 1].stunTime = 0;

                break;
        }
    }*/
    #endregion

    protected void MoveToShip()
    {
        agent.SetDestination(shipTransform.position);
    }


    protected void UpdateMovimenteSpeed()
    {
        //agent.speed = status[level - 1].movimentSpeed * GameManager.Instance.gameTime;
        agent.speed = enemyStatus[level - 1].movimentSpeed * GameManager.Instance.gameTime;
    }


    protected void Shoot(GameObject bullet)
    {
        for (int i = 0; i < cannonsLocal.Length; i++)
            Instantiate(bullet, cannonsLocal[i].position, cannonsLocal[i].rotation);
    }


    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        UpdateUI();

        if (currentLife <= 0)
        {
            Dead();
        }
    }


    protected void Dead()
    {
        SpawnManager.Instance.currentEnemys--;

        int chance = Random.Range(0, 101);
        if (chance >= 100 - (int)(0.7f * 100))
        {
            if (energ != null)
                Instantiate(energ, transform.position, Quaternion.identity);
        }

        CheckMoney();

        Destroy(this.gameObject);
    }


    void CheckMoney()
    {
        if (myCurrencyToDrop > 0)
        {
            int numberCoin = (int)Mathf.Floor(myCurrencyToDrop / CurrencyManager.Instance.maxCountForCurrencys);
            int restMoneyToLastCoin = 0;

            if (myCurrencyToDrop - ((int)Mathf.Floor(myCurrencyToDrop / CurrencyManager.Instance.maxCountForCurrencys) * CurrencyManager.Instance.maxCountForCurrencys) > 0)
            {
                restMoneyToLastCoin = myCurrencyToDrop - (int)Mathf.Floor(myCurrencyToDrop / CurrencyManager.Instance.maxCountForCurrencys);
            }
            else
            {
                DropMoney(numberCoin);
                return;
            }

            DropMoney(numberCoin, true, restMoneyToLastCoin);

            myCurrencyToDrop = 0;
        }
    }


    void DropMoney(int coinsToDrop, bool rest = false, int restValue = 0)
    {
        for (int i = 0; i < coinsToDrop; i++)
        {
            Vector3 RandomLocal = new Vector3(transform.position.x + Random.Range(0f, MaxDistanceToDrop), transform.position.y, transform.position.z + Random.Range(0f, MaxDistanceToDrop));
            GameObject coin = (GameObject)Instantiate(CurrencyManager.Instance.coinMesh, RandomLocal, Quaternion.identity);
            coin.GetComponent<CurrencyBehaviour>().SetValue(CurrencyManager.Instance.maxCountForCurrencys);
        }

        if (rest)
        {
            Vector3 RandomLocal = new Vector3(transform.position.x + Random.Range(0f, MaxDistanceToDrop), transform.position.y, transform.position.z + Random.Range(0f, MaxDistanceToDrop));
            GameObject coin = (GameObject)Instantiate(CurrencyManager.Instance.coinMesh, RandomLocal, Quaternion.identity);
            coin.GetComponent<CurrencyBehaviour>().SetValue(restValue);
        }
    }

    public void UpdateUI()
    {
        if(lifeBar != null)
        {
            //lifeBar.fillAmount = (float)currentLife / (float)status[level - 1].life;
            lifeBar.fillAmount = (float)currentLife / (float)enemyStatus[level - 1].life;
        }
        
    }

    public void RechargeLife()
    {
        //currentLife = status[level - 1].life;
        currentLife = enemyStatus[level - 1].life;
        UpdateUI();
    }
}

/*
public class EnemysStatus
{
    public int life, fireDamage, bulletsToRecharg, shieldResistence, meleeDamage;
    public float movimentSpeed, fireRate, fireRechargTime, shieldRechargTime, meleeAttackDelay, meleeAttackTime, stunTime;
}
*/



