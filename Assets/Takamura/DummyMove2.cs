using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMove2 : MonoBehaviour
{

    private float angle;
    private int rand;
    private int randWidth;

    public float destroyTime = 5;

    //public Vector3 destroyPosition = new Vector3(3,0,-4);
    // Use this for initialization
    void Start()
    {
        rand = Random.Range(0, 10);
        randWidth = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {

        angle += 0.1f;
        if (angle >= 179)
            angle = 0;

        if (rand < 4)
        {
            transform.Translate(new Vector3(-0.1f * Mathf.Sin(angle) * (float)randWidth, 0, 0.05f));
        }
        else if (rand > 4 && rand < 8)
        {
            transform.Translate(new Vector3(-0.05f, 0, 0.1f * Mathf.Sin(angle) * (float)randWidth));
        }
        else
        {
            transform.Translate(transform.forward * 0.05f);
            transform.Translate(-transform.right * 0.05f);
        }

        Destroy(gameObject, destroyTime);

    }
}
