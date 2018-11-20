using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GravityChanger {

    public float speed;

    Rigidbody2D rb;
    SpriteRenderer spr;

    private bool flipped = false;
    private bool invulnerability = false;

    private float moveHorizontal;
    [SerializeField]
    private float maxHealth;

    private float health;

	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
	}
	
	// Update is called once per frame
	private void Update ()
    {       
        Flip();
        HorizontalMovement();
    }

    private void FixedUpdate()
    {

    }

    private void HorizontalMovement()
    {
        if (Input.GetButton("Horizontal"))
        {
            moveHorizontal = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, 0.0f);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }
    }

    private void Flip()
    {
        if (Input.GetButtonDown("Fire1"))
            FlipGravity();
    }    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damager" && !invulnerability)
        {
            invulnerability = true;
            health -= 1;
            print("health deducted");
            StartCoroutine(WaitInvulnerability(1.5f));
        }

        Dead();
    }

    private void Dead()
    {
        if (health == 0)
        {
            print("dead");
        }
    }

    public IEnumerator WaitInvulnerability(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        invulnerability = false;
        print("invuln gone");
    }
}
