using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public HealthBarP1 healthBar;
    public HealthBarP2 healthBarP2;

    public P1Health p1Health;
    public P2Health p2Health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("p1"))
        {
            healthBar.SetHealth(0);
            p1Health.currentHealth = 0;
        }
        if (collision.CompareTag("p2"))
        {
            healthBarP2.SetHealth(0);
            p2Health.currentHealth = 0;
        }
    }

}
