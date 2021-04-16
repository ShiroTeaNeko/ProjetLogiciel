using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float runSpeed = 5.0f;

    public Rigidbody2D rb;
    public Camera c;

    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = c.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;

        float ang = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = ang;
    }
}
