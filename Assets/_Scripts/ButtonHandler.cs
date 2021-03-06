﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    [SerializeField]
    private Sprite onSprite;

    private Sprite offSprite;

    private SpriteRenderer spr;

    [SerializeField]
    private GameObject door;

	void Start () {
        spr = GetComponent<SpriteRenderer>();
        offSprite = spr.sprite;
	}

	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        spr.sprite = onSprite;
        door.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spr.sprite = offSprite;
        door.SetActive(false);
    }
}