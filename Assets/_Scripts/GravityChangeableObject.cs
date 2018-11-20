using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChangeableObject : GravityChanger {

	void Start () {
		
	}

	void Update () {
        if(Input.GetButtonDown("Fire1"))
            FlipGravity();
	}
}
