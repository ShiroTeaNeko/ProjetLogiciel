using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPowerUp : MonoBehaviour
{
    public GameObject self;
    float timer = 0f;
    bool oneTime;

    public int healthPoints;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10 && !oneTime)
        {
            Instantiate(self, new Vector2(0f, 10f), Quaternion.identity);
            oneTime = true;
        }
        Debug.Log(oneTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("p1"))
        {
            P1Health.instance.HealPlayer(healthPoints);
            Destroy(gameObject);
        }

        if (collision.CompareTag("p2"))
        {
            P2Health.instance.HealPlayer(healthPoints);
            Destroy(gameObject);
        }
    }
}
