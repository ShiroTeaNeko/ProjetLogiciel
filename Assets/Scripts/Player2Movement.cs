using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public P2Health p2Health;

    public float runSpeed = 40f;

    public float p2Pos;
    public PlayerMovement p1;

    float horizontalMove = 0f;
    bool jump = false;

    private Rigidbody2D rb;
    Collider2D swordColP2;

    private void Start()
    {
        animator = GetComponent<Animator>();

        swordColP2 = GameObject.Find("swordGoldP2").GetComponent<Collider2D>();

        //p1 = GetComponent<PlayerMovement>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("HorizontalP2") * runSpeed;
        if (horizontalMove != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("attack");
        }
        p2Pos = GameObject.Find("Player2").transform.position.x;
        //Debug.Log(playerPos);
        if (p2Health.gotHit && p1.p1Pos > p2Pos)
        {
            //StartCoroutine(HandleKnockbackDelay());
            KnockBackL();
            //rb.AddForce(new Vector2(5000f, 1000f));
            p2Health.gotHit = false;
        }
        else if (p2Health.gotHit && p1.p1Pos < p2Pos)
        {
            KnockBackR();
            p2Health.gotHit = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        animator.SetBool("isJumping", false);
    }

    void KnockBackR()
    {
        rb.AddForce(new Vector2(5000f, 1000f));
    }

    void KnockBackL()
    {
        rb.AddForce(new Vector2(-5000f, 1000f));
    }

    void AttackP2()
    {
        swordColP2.enabled = true;
    }

    void NoAttackP2()
    {
        swordColP2.enabled = false;
        animator.ResetTrigger("attack");
    }
}
