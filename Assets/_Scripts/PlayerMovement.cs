using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    Rigidbody2D rb;
    SpriteRenderer spr;

    private bool flipped = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            rb.gravityScale = rb.gravityScale * -1;
            flipSprite();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(moveHorizontal*speed, rb.velocity.y, 0.0f);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }
    }

    void flipSprite()
    {
        if (flipped)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
            flipped = false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            flipped = true;
        }
    }
}
