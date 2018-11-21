using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour {

    Rigidbody2D rb;
    SpriteRenderer spr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.gravityScale *= -1;
            if (spr.flipY)
            {
                spr.flipY = false;
            }
            else
            {
                spr.flipY = true;
            }
        }
    }
}
