using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public PlayerAttacks attack;
    public float speed = 3f; //change speed if needed
    public float health = 5; // Change if neededneed
    public float knockbackForce; 

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
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
            if(attack.attacking)
                TakeDamage(1); //change number based on need

            // Knockback(); //knockback if needed

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        AudioManager.instance.PlayOneShot(FMODEvents.instance.hurt, this.transform.position);

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    void Knockback()
    {

        Vector3 knockbackDirection = (transform.position - player.position).normalized;
        GetComponent<Rigidbody>().AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        //knockback if needed
    }
    

    IEnumerator Die()
    {
        //death animation (if any)
        Knockback();

        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }
}