using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{

    private Vector2 accelaration;
    private int accelarationCount;
    private AudioSource m_audioSource;

    // Use this for initialization
    void Start()
    {
        accelaration = Vector2.zero;
        accelarationCount = 0;
        m_audioSource = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 InputVec = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        //入力方向に向く
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0.01 || Math.Abs(Input.GetAxis("Vertical")) > 0.01)
        {
            //        transform.rotation = Quaternion.LookRotation(transform.position +
            //(Vector3.right * Input.GetAxisRaw("Horizontal")) +
            //(Vector3.forward * Input.GetAxisRaw("Vertical"))
            //- transform.position);

            transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Rad2Deg * Mathf.Atan2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), 0));

            Vector3 vec = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, -Input.GetAxisRaw("Vertical"));

            GetComponent<Rigidbody>().AddForce(vec * 10, ForceMode.Acceleration);
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.localEulerAngles.y, 0));
        }
        //入力してないときに勝手に回転,移動するのを防ぐ

       // Debug.Log(ForceMode.Acceleration.ToString());

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        Debug.Log(rigidbody.velocity.x);
        
        //加速度を毎回減速する


        //加速度が低いと加速度を消す
        if (Math.Abs(rigidbody.velocity.x) < 1 && Math.Abs(rigidbody.velocity.z) < 1)
        {
            // GetComponent<Rigidbody>().AddForce(vec * 10, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.zero, ForceMode.Force);
            rigidbody.freezeRotation = true;

        }
        else
        {
            rigidbody.freezeRotation = true;
        }

        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;

        if(!m_audioSource.isPlaying)
        {
            if(Vector2.Dot(InputVec,rigidbody.velocity)<0)
            {
                m_audioSource.Play();

            }
        }

    }
 

    void OnCollisionEnter(Collision col)
    {
    
        if (col.gameObject.tag == "Goal")
        {
            GetComponent<Rigidbody>().velocity *= 0.5f;
           
        }
    }


    public GameObject fireParticle;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Dummy")
        {
            SoundManager.PlayOneShot(AudioClips.HIT);
            Destroy(col.gameObject);

            FireParticle();
        }
    }
    void FireParticle()
    {
        Instantiate(fireParticle, new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z), Quaternion.identity);
    }

}
