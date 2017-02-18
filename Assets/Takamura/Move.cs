using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    //private Animator animator;
    private float rotationSpeed = 0.1f;
	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("up"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(-transform.forward * 0.1f);
        }
        if (Input.GetKey("down"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(transform.forward * 0.1f);
        }
        if (Input.GetKey("right"))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(transform.right * 0.1f);
        }
        if (Input.GetKey("left"))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            transform.Translate(-transform.right * 0.1f);
        }
    }
}
