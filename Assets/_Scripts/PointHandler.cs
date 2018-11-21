using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointHandler : MonoBehaviour {

    [SerializeField]
    private float score = 0;

    public Text scoreText;


	private void Start () {
        SetScoreText();
	}
	
	private void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            score += 1;
            SetScoreText();
            Destroy(collision.gameObject);
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
