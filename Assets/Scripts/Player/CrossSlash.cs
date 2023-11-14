using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSlash : MonoBehaviour
{
    Enemy enemy;
    public PlayerAttacks playerAttacks;
    [SerializeField] private GameObject HitVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(playerAttacks.attackDamage);
            var collisionPoint=other.ClosestPoint(transform.position);
            var collision = transform.position - transform.forward;

            Instantiate(HitVFX, collisionPoint, transform.rotation);
        }
    }
}