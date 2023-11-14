using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject slashHitBox;
    public GameObject crossSlashHitBox;

    private bool attacking;
    public float attackDamage;

    [SerializeField] private float attackTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !attacking)
        {
            StartCoroutine(CrossSlash(attackTime));
        }
        if (Input.GetMouseButton(1) && !attacking)
        {
            StartCoroutine(WideSlash(attackTime));
        }
    }

    IEnumerator CrossSlash(float x)
    {
        attacking = true;
        slashHitBox.SetActive(true);
        yield return new WaitForSeconds(x);
        slashHitBox.SetActive(false);
        attacking = false;
    }

    IEnumerator WideSlash(float x)
    {
        attacking = true;
        crossSlashHitBox.SetActive(true);
        yield return new WaitForSeconds(x);
        crossSlashHitBox.SetActive(false);
        attacking = false;
    }
}
