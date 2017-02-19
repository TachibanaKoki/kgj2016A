using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

    [SerializeField]
    Text text;

	// Use this for initialization
	void Start () {
		if(GameData.WinnerIsIron)
        {
            text.text = "アイロン";
        }
        else
        {
            text.text = "Dirty-Chan";
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Input.GetButtonDown("Fire1"))
        {
            TransitionManager.I.FadeOut(1.0f);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Title");
        }
	}
}
