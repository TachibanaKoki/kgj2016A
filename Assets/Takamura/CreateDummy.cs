using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDummy : MonoBehaviour {

    public GameObject chara;
    public float interval = 3;
    private float time;
    float coutTime;

    public Vector3 createPosition;

    // Use this for initialization
    void Update()
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
