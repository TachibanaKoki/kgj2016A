using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMove4 : MonoBehaviour
{

    private float angle;
    private int rand;
    private int randWidth;
    private int randScale;

    public float destroyTime = 5;
    public float radius;

    //public Vector3 destroyPosition = new Vector3(3,0,-4);
    // Use this for initialization
    void Start()
    {
        radius = (float)Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        angle += Time.deltaTime * 10;
        //if (angle >= 180)
        //    angle = 0;

        transform.Translate(new Vector3(radius* Mathf.Cos(angle), 0, radius * Mathf.Sin(angle)));

    }
}
