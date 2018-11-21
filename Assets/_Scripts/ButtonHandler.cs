using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    [SerializeField]
    private Sprite onSprite;

    private Sprite offSprite;

    private SpriteRenderer spr;
    private BoxCollider2D bCol2D;

    [SerializeField]
    private GameObject door;

	void Start () {
        spr = GetComponent<SpriteRenderer>();
        bCol2D = GetComponent<BoxCollider2D>();
        offSprite = spr.sprite;
	}

	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spr.sprite = onSprite;
        door.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spr.sprite = offSprite;
        door.SetActive(false);
    }
}