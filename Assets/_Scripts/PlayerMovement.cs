using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    [SerializeField]
    private Text healthText;

    Rigidbody2D rb;
    SpriteRenderer spr;

    private bool invulnerability = false;

    private float moveHorizontal;
    [SerializeField]
    private float maxHealth;

    private float health;

	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        health = maxHealth;
        healthText.text = "Health: " + health;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        HorizontalMovement();
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (moveHorizontal >= 0)
        {
            spr.flipX = false;
        }
        else if (moveHorizontal < 0)
        {
            spr.flipX = true;
        }
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damager" && !invulnerability)
        {
            invulnerability = true;
            health -= 1;
            healthText.text = "Health: " + health;
            StartCoroutine(WaitInvulnerability(0.75f));
        }

        Dead();
    }

    private void Dead()
    {
        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public IEnumerator WaitInvulnerability(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        invulnerability = false;
    }
}
