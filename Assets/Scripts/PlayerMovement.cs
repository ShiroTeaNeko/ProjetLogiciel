using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public P1Health p1Health;

    public float runSpeed = 40f;

    public float p1Pos;
    public Player2Movement p2;

    float horizontalMove = 0f;
    bool jump = false;

    private Rigidbody2D rb;
    Collider2D swordCol;
    private float KnockbackTimeAfterHit = 3f;

    private void Start()
    {
        animator = GetComponent<Animator>();

        swordCol = GameObject.Find("swordGoldP1").GetComponent<Collider2D>();

        //p2 = GetComponent<Player2Movement>();

        rb = GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("HorizontalP1") * runSpeed;

        if (horizontalMove != 0 )
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        
        if (Input.GetButtonDown("Jump1"))
        {
            jump = true;
            animator.SetBool("isJumping",true);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            animator.SetTrigger("attack");
        }

        p1Pos = GameObject.Find("Player1").transform.position.x;
        //Debug.Log(p2.p2Pos);

        if (p1Health.gotHit && p2.p2Pos > p1Pos)
        {
            //StartCoroutine(HandleKnockbackDelay());
            KnockBackL();
            //rb.AddForce(new Vector2(5000f, 1000f));
            p1Health.gotHit = false;
        }
        else if (p1Health.gotHit && p2.p2Pos < p1Pos)
        {
            KnockBackR();
            p1Health.gotHit = false;
        }
    }
    public IEnumerator HandleKnockbackDelay()
    {
        //KnockBack();
        yield return new WaitForSeconds(KnockbackTimeAfterHit);
        
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

    void Attack()
    {
        swordCol.enabled = true;
    }

    void NoAttack()
    {
        swordCol.enabled = false;
        animator.ResetTrigger("attack");
    }
}
