using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLimitedDummy : MonoBehaviour
{

    public GameObject chara;
    public float interval = 3;
    private float time;
    //public int numberOfDummy;
    public int numberOfDummyMax = 5;
    private int count = 0;

    public Vector3 createPosition;

    // Use this for initialization
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interval && count < numberOfDummyMax)
        {
            time = 0;
            CreateCharacter();
        }
    }

    void CreateCharacter()
    {
        float randomWidth;
        float randomLength;
        randomWidth = Random.Range(-5, 5);
        randomLength = Random.Range(-5, 0);
        createPosition = new Vector3(randomWidth, 0, randomWidth);

        Instantiate(chara, createPosition, Quaternion.identity);
        count++;
    }
}
