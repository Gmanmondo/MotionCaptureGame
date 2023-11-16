using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private Transform orientation;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerAttacks attack;

    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    public float groundDrag;

    public float health;

    float horizontal;
    float vertical;

    private EventInstance playerFootsteps;

    void Start()
    {
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootSteps);


        rb = GetComponent<Rigidbody>();
        LockCursor();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        Move();
        SpeedControl();
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        if (health <= 0)
        {
            Die();
        }
    }
    
    private void FixedUpdate()
    {
        UpdateSound();
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0 && !attack.attacking)
        {
            animator.SetBool("Running", true);
            direction = orientation.forward * vertical + orientation.right * horizontal;
            rb.AddForce(direction.normalized * speed, ForceMode.Force);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Die()
    {
        Destroy(this);
        //game over screen
        AudioManager.instance.PlayOneShot(FMODEvents.instance.die, this.transform.position);
    }

    private void UpdateSound()
    {
        if (horizontal != 0 || vertical != 0)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}