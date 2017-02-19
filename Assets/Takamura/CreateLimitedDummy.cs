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

    void Start()
    {
        for(int i = 0; i< 3; i++)
            CreateCharacter();
    } 

    // Use this for initialization
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= interval && count < numberOfDummyMax)
        {
            time = 0;
            CreateCharacter();
        }
    }

    void StartCreateCharacter()
    {
        float randomWidth;
        float randomLength;
        randomWidth = Random.Range(-5, 5);
        randomLength = Random.Range(-5, 0);
        createPosition = new Vector3(randomWidth, 0, randomWidth);

        Instantiate(chara, createPosition, Quaternion.identity);
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
