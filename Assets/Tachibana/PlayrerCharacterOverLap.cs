using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayrerCharacterOverLap : MonoBehaviour
{
    private int GoalNumber = 3;
    private int NowNumber = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            TransitionManager.I.FadeOut(1.0f);
            GameData.WinnerIsIron = true;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("result");
        }

        if (col.gameObject.tag == "Goal")
        {
            NowNumber++;
            Destroy(col.gameObject);

            if (NowNumber == GoalNumber)
            {
                TransitionManager.I.FadeOut(1.0f);
                GameData.WinnerIsIron = false;
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("result");
                LastParticles();
            }
            else
            {
               // PlayParticles();
                //LastParticles();
                FireParticle();
            }
        }
    }


    //パーティクル

    public GameObject blackParticle;
    public GameObject lastStartParticle;
    public GameObject fireParticle;

    void PlayParticles()
    {
        Instantiate(blackParticle, new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z), Quaternion.identity);
    }

    void LastParticles()
    {
        Instantiate(lastStartParticle, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
    }

    void FireParticle()
    {
        Instantiate(fireParticle, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }
}
