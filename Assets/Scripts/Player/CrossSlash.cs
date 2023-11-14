using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSlash : MonoBehaviour
{
    //Public EnemyBaseScript enemyBaseScript
    public PlayerAttacks playerAttacks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //enemyBaseScript.health-=playerAttacks.attackDamage
        }
    }
}