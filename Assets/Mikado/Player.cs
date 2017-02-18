using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

    private Vector2 accelaration;


	// Use this for initialization
	void Start () {
        accelaration = Vector2.zero;
		
	}
	
   

	// Update is called once per frame
	void Update () {
    accelaration.y+= -Input.GetAxis("Vertical")*0.004f;
    accelaration.x += -Input.GetAxis("Horizontal") * 0.004f;

       Debug.Log(Input.GetAxis("Horizontal"));
        transform.position = new Vector3(transform.position.x+accelaration.x, transform.position.y, transform.position.z + accelaration.y);

        if (Math.Abs(accelaration.x) < 0.001 && Math.Abs(accelaration.y) < 0.001)
        {
            accelaration = Vector2.zero;
        }
        else
        {
            accelaration.x /= 1.02f;
            accelaration.y /= 1.02f;
        }
    
    }
   
	}
