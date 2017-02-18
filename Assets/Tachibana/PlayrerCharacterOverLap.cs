using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayrerCharacterOverLap : MonoBehaviour
{
    private int GoalNumber = 3;
    private int NowNumber = 0;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            TransitionManager.I.FadeOut(1.0f);
            GameData.WinnerIsIron = true;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("result");
        }
        
        if(col.gameObject.tag == "Goal")
        {
            NowNumber++;
            Destroy(col.gameObject);

            if(NowNumber==GoalNumber)
            {
            TransitionManager.I.FadeOut(1.0f);
            GameData.WinnerIsIron = false;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("result");
            }
        }
    }
}
