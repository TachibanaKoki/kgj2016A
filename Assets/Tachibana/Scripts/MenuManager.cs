using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
    [SerializeField]
    Image Pentagon;

    [SerializeField]
    Image Square;

    bool isPentadgon = false;

	// Use this for initialization
	void Start () 
    {
        isPentadgon = true;
        UpdateImage();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Input.GetButtonDown("Fire1"))
        {
            TransitionManager.I.FadeOut(1.0f);
            if(isPentadgon)
            {
                SceneManager.LoadSceneAsync("main2");
            }
            else
            {
                SceneManager.LoadSceneAsync("main");
            }
        }

        if(Input.GetButtonDown("Fire2"))
        {
            TransitionManager.I.FadeOut(1.0f);
            SceneManager.LoadSceneAsync("Title");

        }

        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal < 0||Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            isPentadgon = true;
            UpdateImage();

        }
        else if (horizontal > 0 || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isPentadgon = false;
            UpdateImage();
        }

	}

    void UpdateImage()
    {
        if(isPentadgon)
        {
            Pentagon.color = Color.white;
            Square.color = Color.gray;
        }
        else
        {
            Pentagon.color = Color.gray;
            Square.color = Color.white;
        }
    }
}
