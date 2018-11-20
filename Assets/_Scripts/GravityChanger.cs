using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GravityChanger : MonoBehaviour {

	public void FlipGravity()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        rb.gravityScale *= -1;
        if (sr.flipY)
        {
            sr.flipY = false;
        }
        else
        {
            sr.flipY = true;
        }
    }
}
