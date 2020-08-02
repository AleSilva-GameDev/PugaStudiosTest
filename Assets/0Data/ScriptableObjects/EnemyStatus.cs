using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "EnemyStatus")]
public class EnemyStatus : ScriptableObject
{
    public string nameShip;
    public int level;
    public bool walk, fire, rechargFire, meleeAttack, rangeAttack, suicide, playerToTarget, shield, rechargShield, stun;
    public int life, fireDamage, bulletsToRecharg, shieldResistence, meleeDamage;
    public float movimentSpeed, fireRate, fireRechargTime, shieldRechargTime, meleeAttackDelay, meleeAttackTime, stunTime;
}
