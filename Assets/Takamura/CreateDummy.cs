using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDummy : MonoBehaviour {

    public GameObject chara;
    public float interval = 3;
    private float time;
    float coutTime;

    public Vector3 createPosition;

    void Start()
    {
        for (int i = 0; i < 3; i++)
            CreateCharacter();
    }

    // Use this for initialization
    void FixedUpdate()
    {
        time += Time.deltaTime;
        coutTime += Time.deltaTime;

        if(time >= interval)
        {
            time = 0;
            CreateCharacter();
        }
    }

    void CreateCharacter()
    {
        Instantiate(chara, createPosition, Quaternion.identity);
    }
}
