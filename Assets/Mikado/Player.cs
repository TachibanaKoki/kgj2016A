using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    private Vector2 accelaration;
    private int accelarationCount;

    // Use this for initialization
    void Start()
    {
        accelaration = Vector2.zero;
        accelarationCount = 0;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //accelaration.y += -Input.GetAxis("Vertical") * 0.004f;
        //accelaration.x += -Input.GetAxis("Horizontal") * 0.004f;


        //transform.Translate(new Vector3( accelaration.x, 0, accelaration.y));

        ////加速度の減少
        //if (Math.Abs(accelaration.x) < 0.001 && Math.Abs(accelaration.y) < 0.001)
        //{
        //    accelaration = Vector2.zero;
        //}
        //else if (accelarationCount > 100)
        //{
        //    accelaration.x /= 1.00f;
        //    accelaration.y /= 1.00f;
        //}
        //else
        //{
        //    accelaration.x /= 1.06f;
        //    accelaration.y /= 1.06f;
        //}
        ////        Debug.Log(accelaration.x);

        ////一定時間入力すると加速度が上がる
        //if (Math.Abs(Input.GetAxis("Horizontal")) > 0.02 || Math.Abs(Input.GetAxis("Vertical")) > 0.02)
        //{
        //    accelarationCount++;
        //}
        //else
        //    accelarationCount = 0;

        //入力方向に向く
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
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
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.localEulerAngles.y, 0));
        //入力してないときに勝手に回転,移動するのを防ぐ
        
            
            Vector3 pos = transform.position;
            pos.y = 0;
        transform.position = pos;

    }
 
    void OnCollisionEnter()
    {
        GetComponent<Rigidbody>().velocity *= 0.5f;
    }

}
