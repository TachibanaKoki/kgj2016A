using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMove : MonoBehaviour {

    private float angle;
    private int rand;
    private int randWidth;
    private int randScale;

    public float destroyTime = 5;

    //public Vector3 destroyPosition = new Vector3(3,0,-4);
	// Use this for initialization
	void Start () {
        rand = Random.Range(0,10);
        randWidth = Random.Range(1,3);
        randScale = Random.Range(0, 20);

        if (randScale == 0)
            transform.localScale = new Vector3(3, 0.3f, 6);
	}

    // Update is called once per frame
    void Update() {

        angle += 0.1f;
        if (angle >= 179)
            angle = 0;

        //transform.Translate(-transform.forward * Mathf.Sin(angle));
        //transform.Translate(transform.right * Mathf.Cos(angle));
        if (rand < 4)
        {
            transform.Translate(new Vector3(0.1f * Mathf.Sin(angle) * (float)randWidth, 0, -0.05f));
        }
        else if (rand > 4 && rand < 8)
        {
            transform.Translate(new Vector3(0.05f, 0, -0.1f * Mathf.Sin(angle) * (float)randWidth));
        }
        else
        {
            transform.Translate(-transform.forward * 0.05f);
            transform.Translate(transform.right * 0.05f);
        }

        //if (transform.position.x >= destroyPosition.x || transform.position.z <= destroyPosition .z)
        Destroy(gameObject, destroyTime);

    }
}
