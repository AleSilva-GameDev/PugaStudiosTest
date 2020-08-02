using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerEffect : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemysBehavior>())
        {
            Debug.Log("Colidi - Inimigo");
            other.GetComponent<EnemysBehavior>().RechargeLife();
        }
        else if(other.gameObject.CompareTag("Ship"))
        {
            Debug.Log("Colidi - Ship");
            other.GetComponent<ShipController>().TakeDamage(100);
        }
    }

}
