using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMove5 : MonoBehaviour
{
    private float angle;

    // Use this for initialization
    void Start()
    {
        transform.localRotation = Quaternion .Euler(0,90,0);
    }

    // Update is called once per frame
    void Update()
    {

        angle += Time.deltaTime * 10;
        //if (angle >= 179)
        //    angle = 0;

        transform.Translate(new Vector3(0, 0, Mathf.Sin(angle) * 0.3f));
    }
}
