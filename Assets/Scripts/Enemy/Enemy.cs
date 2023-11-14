using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; //change speed if needed
    public int health = 5; // Change if needed
    // public float knockbackForce = 2f; 

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.LookAt(player.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            TakeDamage(1); //change number based on need

            // Knockback(); //knockback if needed

        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    /* void Knockback()
    {

        Vector3 knockbackDirection = (transform.position - player.position).normalized;
        GetComponent<Rigidbody>().AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        //knockback if needed
    }
    */

    void Die()
    {
        //death animation (if any)
        Destroy(gameObject);
    }
}