﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMove3 : MonoBehaviour {   
    private float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        angle += Time.deltaTime * 10;
        //if (angle >= 179)
        //    angle = 0;

        transform.Translate(new Vector3(0, 0, Mathf.Sin(angle) * 0.3f));
    }
}
