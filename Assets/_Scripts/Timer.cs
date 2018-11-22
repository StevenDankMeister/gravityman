using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float time;
    private Text timerText;

	void Start () {
        time = Time.time;
        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timerText.text = "Time: " + time;
        time = Mathf.FloorToInt(Time.time);
	}
}
