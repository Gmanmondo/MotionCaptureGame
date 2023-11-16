using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject slashHitBox;
    public GameObject crossSlashHitBox;
    public Animator animator;

    public bool attacking;
    public float attackDamage;
    float a;

    [SerializeField] private float attackTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !attacking)
        {
            StartCoroutine(CrossSlash(attackTime));
            
            Debug.Log("Swing1");
        }
        if (Input.GetMouseButton(1) && !attacking)
        {
            StartCoroutine(WideSlash(attackTime));
            Debug.Log("Swing2");
        }
    }

    IEnumerator CrossSlash(float x)
    {
        attacking = true;
        slashHitBox.SetActive(true);
        a = 1f;
        animator.SetLayerWeight(animator.GetLayerIndex("Swing1"), a);
        animator.SetBool("Swing1", true);

        AudioManager.instance.PlayOneShot(FMODEvents.instance.attack, this.transform.position);

        yield return new WaitForSeconds(x);

        slashHitBox.SetActive(false);
        animator.SetBool("Swing1", false);
        attacking = false;
        a = 0;
    }

    IEnumerator WideSlash(float x)
    {
        attacking = true;
        crossSlashHitBox.SetActive(true);
        a = 1f;
        animator.SetLayerWeight(animator.GetLayerIndex("Swing2"), a);
        animator.SetBool("Swing2", true);

        AudioManager.instance.PlayOneShot(FMODEvents.instance.attack, this.transform.position);

        yield return new WaitForSeconds(x);

        crossSlashHitBox.SetActive(false);
        animator.SetBool("Swing2", false);
        attacking = false;
        a = 0;
    }
}
