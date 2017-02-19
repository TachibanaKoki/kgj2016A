using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayrerCharacterOverLap : MonoBehaviour
{
    private int GoalNumber = 3;
    private int NowNumber = 0;
    bool isClear = false;

    void OnCollisionEnter(Collision col)
    {

        if (isClear) return;
        if (col.gameObject.tag == "Player")
        {
            TransitionManager.I.FadeOut(1.0f);
            GameData.WinnerIsIron = true;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Iron");
        }

        if (col.gameObject.tag == "Goal")
        {
            NowNumber++;
            Destroy(col.gameObject);
            SoundManager.PlayOneShot(AudioClips.GET);
            if (NowNumber == GoalNumber)
            {
                isClear = true;
                transform.localScale = Vector3.one*2.0f;
                LastParticles();
                StartCoroutine(Delay(2.0f,() =>
                {
                    TransitionManager.I.FadeOut(1.0f,()=>{   UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Darty");});
                    GameData.WinnerIsIron = false;
                }));
            }
            else
            {
                PlayParticles();
               // LastParticles();
              //  FireParticle();
            }
        }
    }

    IEnumerator Delay(float duration,System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback.Invoke();
    }

    //パーティクル

    public GameObject blackParticle;
    public GameObject lastStartParticle;
  
    void PlayParticles()
    {
        Instantiate(blackParticle, new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z), Quaternion.identity);
    }

    void LastParticles()
    {
        Instantiate(lastStartParticle, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
    }


}
