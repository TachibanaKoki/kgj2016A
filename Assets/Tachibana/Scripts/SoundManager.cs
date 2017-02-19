using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClips
{
    DRIFT,HIT,DEATH,CLEAR,GET
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    public static SoundManager I;
    [SerializeField]
    AudioClip Drift;
    [SerializeField]
    AudioClip[] Hit;
    [SerializeField]
    AudioClip Death;
    [SerializeField]
    AudioClip Clear;
    [SerializeField]
    AudioClip Get;

    AudioSource audioSorce;

	// Use this for initialization
	void Start () 
    {
        I = this;
        audioSorce = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A)) PlayOneShot(AudioClips.HIT);
	}

    public static void PlayOneShot(AudioClips e_Clips)
    {
        switch(e_Clips)
        {
            case AudioClips.DRIFT:
                I.audioSorce.PlayOneShot(I.Drift);
                break;
            case AudioClips.HIT:
                
                    I.audioSorce.PlayOneShot(I.Hit[Random.Range(0,3)]);
                break;
            case AudioClips.DEATH:
                I.audioSorce.PlayOneShot(I.Death);
                break;
            case AudioClips.CLEAR:
                I.audioSorce.PlayOneShot(I.Clear);
                break;
            case AudioClips.GET:
                I.audioSorce.PlayOneShot(I.Get);
                break;
        }
    }
}
